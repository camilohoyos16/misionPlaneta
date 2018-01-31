using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public static ScoreManager Instance {
		get{ return instance; }
	}

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

	void OnEnable()
	{
		score = 0;
		howManyAnswered = 0;
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
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
		} else {
			c_audioLisener.clip = wrongAnswer;
			c_audioLisener.time = 1f;
		}
		c_audioLisener.Play ();
		if (howManyAnswered == 10)
			RankedPlayer ();
		print (score);
	}

	private void RankedPlayer()
	{
		buttonsFinal.SetActive (true);
		switch (score) {
		case 0:
		case 1:
		case 2:
			c_audioLisener.clip = abucheo;
			c_audioLisener.time = 0.7f;
			c_audioLisener.Play ();
			level1.SetActive(true);
			break;
		case 3:
		case 4:
		case 5:
			c_audioLisener.clip = abucheo;
			c_audioLisener.time = 0.7f;
			level2.SetActive(true);
			c_audioLisener.Play ();

			break;
		case 6:
		case 7:
		case 8:
			c_audioLisener.clip = felicitaciones;
			c_audioLisener.time = 0.7f;
			level3.SetActive(true);
			c_audioLisener.Play ();

			break;
		case 9:
		case 10:
			c_audioLisener.clip = felicitaciones;
			c_audioLisener.time = 0.7f;
			level4.SetActive(true);
			c_audioLisener.Play ();

			break;
		}
	}

}
