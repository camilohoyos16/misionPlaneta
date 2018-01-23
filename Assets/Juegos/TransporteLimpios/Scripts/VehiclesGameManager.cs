using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction{
	left ,
	right,
	up,
	down
}

public enum Vehicles{
	motorcycle,
	car, 
	truck
}

public class VehiclesGameManager : MonoBehaviour {

	private static VehiclesGameManager instance;
	public static VehiclesGameManager Instance{ get { return instance; } }

	public delegate void GameStats();
	public event GameStats onGameStart;
	public event GameStats onGameOver;

	public static int globalScore;
	public float gameTime;
	public static float timer;
	public bool isPlaying;
	public static int amountOfVehiclesFixed;
	public static List<GameObject> totalVehiclesGameobjects = new List<GameObject>();

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	void OnDisable()
	{
		globalScore = 0;
		timer = 0;
		amountOfVehiclesFixed = 0;
		for (int i = 0; i < totalVehiclesGameobjects.Count; i++) {
			GameObject currentVehicle= totalVehiclesGameobjects [0];
			currentVehicle.SetActive (false);
			totalVehiclesGameobjects.Remove(currentVehicle);
			Destroy (currentVehicle);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isPlaying) {
			timer += Time.deltaTime;
			if (timer >= gameTime) {
				isPlaying = false;
				if (onGameOver != null) {
					onGameOver();
				}
			}
		}
	}

	public void OnGameStart()
	{
		if (onGameStart != null) {
			onGameStart ();
			isPlaying = true;
		}
	}
		

	public void PlusScore(int score)
	{
		if (isPlaying) {
			amountOfVehiclesFixed++;
			globalScore += score;
		}
	}
}
