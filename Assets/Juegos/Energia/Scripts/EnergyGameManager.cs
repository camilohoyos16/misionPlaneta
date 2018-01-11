using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGameManager : MonoBehaviour {

	private static EnergyGameManager instance;
	public static EnergyGameManager Instance{ get { return instance; } }

	public static int globalScore;
	public static int amountOfLightTurnOff;
	public static int amountOfLightTurnOn;

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
		amountOfLightTurnOff = 0;
	}

	public void PlusScore(int score)
	{
		amountOfLightTurnOff ++;
		print ("TurnOff: " + amountOfLightTurnOff);
		globalScore += score;
	}

	public void PlusLghTurnOn()
	{
		amountOfLightTurnOn++; 
		print ("TurnOn: " + amountOfLightTurnOn);
	}
}
