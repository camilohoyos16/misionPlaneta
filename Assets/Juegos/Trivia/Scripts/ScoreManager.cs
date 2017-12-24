using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public static ScoreManager Instance {
		get{ return instance; }
	}

	public static int score;

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
		if (isCorrect) {
			score++;
		}
		print (score);
	}

}
