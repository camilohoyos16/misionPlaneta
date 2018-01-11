using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction{
	left,
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

	public static int globalScore;

	void Awake()
	{
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

	public void PlusScore(int score)
	{
		globalScore += score;
		print (globalScore);
	}
}
