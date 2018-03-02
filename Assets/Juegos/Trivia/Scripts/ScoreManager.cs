using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public static ScoreManager Instance {
		get{ return instance; }
	}

	public delegate void ChangeGame();
	public event ChangeGame onStartTrivia;
	public event ChangeGame onStartTrash;

	public static int score;
	public static int howManyAnswered;

	[Header ("GameOver Ranked Player")]
	[SerializeField] private GameObject level1;
	[SerializeField] private GameObject level2;
	[SerializeField] private GameObject level3;
	[SerializeField] private GameObject level4;
	[SerializeField] private GameObject buttonsFinal;

	[Header ("Tutorial Manager")]
	[SerializeField] private GameObject tutorial;
		
	private bool gameIsFinished;
	[Header ("Sound")]
	[SerializeField] private AudioSource c_audioLisener;
	[SerializeField] private AudioClip correctAnswer;
	[SerializeField] private AudioClip wrongAnswer;
	[SerializeField] private AudioClip abucheo;
	[SerializeField] private AudioClip felicitaciones;
	public AudioSource spokenTutorial;

	[Header ("Two games components")]
	[Space (10)]
	[SerializeField] private CanvasGroup triviaCanvas;
	[SerializeField] private float timeToFade;

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void OnDestroy()
	{
		score = 0;
		howManyAnswered = 0;
	}

	// Use this for initialization
	void Start () {
		tutorial.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	}
	public void OnDissapearTutorial()
	{
		tutorial.SetActive (false);
		spokenTutorial.Stop ();
	}

	public void CheckAnswer(bool isCorrect)
	{
		howManyAnswered++;
		if (isCorrect) {
			score++;
			c_audioLisener.clip = correctAnswer;
			c_audioLisener.time = 0f;
			DissapearTrivia ();
		} else {
			c_audioLisener.clip = wrongAnswer;
			c_audioLisener.time = 1f;
		}
		c_audioLisener.Play ();
		if (howManyAnswered == 10)
			RankedPlayer ();
		print (score);
	}

	private void ActiveEndGame(AudioClip sound, float timeToStartSound, GameObject finalImage)
	{
		c_audioLisener.clip = sound;
		c_audioLisener.time = 0.7f;
		c_audioLisener.Play ();
		finalImage.SetActive(true);
	}

	private void RankedPlayer()
	{
		buttonsFinal.SetActive (true);
		switch (score) {
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
			ActiveEndGame (abucheo, 0.7f, level1);
			break;
		case 7:
		case 8:
		case 9:
		case 10:
			ActiveEndGame (felicitaciones, 0.7f, level4);
			break;
		}
	}

	public void AppearTrivia()
	{
		StartCoroutine (DoAppearTrivia ());
	}

	IEnumerator DoAppearTrivia()
	{
		triviaCanvas.blocksRaycasts = false;
		float timer = 0;
		float currentAlpha = 0;
		while (timer < timeToFade) {

			currentAlpha = Mathf.Lerp (0, 1, timer / timeToFade);
			triviaCanvas.alpha = currentAlpha;
			yield return null;
			timer += Time.deltaTime;
		}
		triviaCanvas.blocksRaycasts = true;
		if (onStartTrivia != null) {
			onStartTrivia ();
		}
	}

	public void DissapearTrivia ()
	{
		StartCoroutine (DoDissappearTrivia ());
	}

	IEnumerator DoDissappearTrivia()
	{
		triviaCanvas.blocksRaycasts = false;
		float timer = 0;
		float currentAlpha = 0;
		while (timer < timeToFade) {

			currentAlpha = Mathf.Lerp (1, 0, timer / timeToFade);
			triviaCanvas.alpha = currentAlpha;
			yield return null;
			timer += Time.deltaTime;
		}
		if (onStartTrash != null) {
			onStartTrash ();
		}
	}

}
