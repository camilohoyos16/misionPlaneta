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

	private bool gameIsFinished;

	void OnEnable()
	{
		score = 0;
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void CheckAnswer(bool isCorrect)
	{
		howManyAnswered++;
		if (isCorrect) {
			score++;
		}
		if (howManyAnswered == 10)
			RankedPlayer ();
		print (score);
	}

	private void RankedPlayer()
	{
		switch (score) {
		case 1:
		case 2:
			level1.SetActive(true);
			break;
		case 3:
		case 4:
		case 5:
			level2.SetActive(true);
			break;
		case 6:
		case 7:
		case 8:
			level3.SetActive(true);
			break;
		case 9:
		case 10:
			level4.SetActive(true);
			break;
		}
	}

}
