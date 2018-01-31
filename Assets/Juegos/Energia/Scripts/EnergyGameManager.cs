using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGameManager : MonoBehaviour {

	public delegate void GameStats();
	public event GameStats onGameStart;
	public event GameStats onGameOver;

	private static EnergyGameManager instance;
	public static EnergyGameManager Instance{ get { return instance; } }

	public static int globalScore;
	public static int amountOfLightTurnOff;
	public static int amountOfLightTurnOn;
	public EnergyUIManager energyUI;
	public float gameTime;
	public static float timer;
	public bool isPlaying;
	public AudioSource apagabombillo;

	public List<Lights> lights = new List<Lights>();

	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
		Lights[] tempLights = FindObjectsOfType<Lights> ();
		for (int i = 0; i < tempLights.Length; i++) {
			lights.Add (tempLights [i]);
		}
	}

	void OnEnable()
	{
		amountOfLightTurnOn = 0;
		amountOfLightTurnOff = 0;
		globalScore = 0;
		timer = 0;
	}
	void OnDisable()
	{
		instance = null;
	}

	void Update()
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

	public void PlusScore(int score)
	{
		if (isPlaying) {
			apagabombillo.Play ();
			energyUI.UpdateBatteryCharge ();
			amountOfLightTurnOff++;
			print ("TurnOff: " + amountOfLightTurnOff);
			globalScore += score;
		}
	}

	public void ControlFirstTurnOn(){
		int randomNumber = Random.Range (0, lights.Count-1);
		Lights currentLight = lights [randomNumber];
		currentLight.StartTurnOnAgain ();
		lights.RemoveAt (randomNumber);
	}

	public void OnGameStart()
	{
		if (onGameStart != null) {
			onGameStart ();
		}
		isPlaying = true;
		ControlFirstTurnOn ();
	}

	public void PlusLghTurnOn()
	{
		amountOfLightTurnOn++; 
		print ("TurnOn: " + amountOfLightTurnOn);
	}
}
