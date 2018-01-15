﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUIManager : MonoBehaviour {


	[Header ("GameOverElements")]
	[SerializeField] private GameObject gameOver;
	[SerializeField] private Image batteryImage;
	[SerializeField] private Sprite[] battery;
	[SerializeField] private Text gameOverText;

	[Header("Tutorial elements")]
	[SerializeField] private GameObject tutorial;
	[SerializeField] private int tutorialTime;

	public int level1;
	public int level2;
	public int level3;
	private float stepsTochangeBattery;

	void OnEnable()
	{
	}

	void OnDisable()
	{
		EnergyGameManager.Instance.onGameOver -= GameOver;
	}

	void Start () {
		EnergyGameManager.Instance.onGameOver += GameOver;
		tutorial.SetActive (true);
		gameOver.SetActive (false);
		dissapearTutorial = DissapearTutorial ();
		StartCoroutine (dissapearTutorial);
		stepsTochangeBattery = level3 / battery.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator dissapearTutorial;
	IEnumerator DissapearTutorial()
	{
		yield return new WaitForSeconds (tutorialTime);
		tutorial.SetActive (false);
		EnergyGameManager.Instance.ControlFirstTurnOn ();
		EnergyGameManager.Instance.OnGameStart ();
		dissapearTutorial = null;
	}

	public void OnClickDissapearTutorial()
	{
		if (dissapearTutorial != null)
			StopCoroutine (dissapearTutorial);
		tutorial.SetActive (false);
		EnergyGameManager.Instance.OnGameStart ();
	}

	public void UpdateBatteryCharge()
	{
		switch (EnergyGameManager.amountOfLightTurnOff) {
		case 5:
			batteryImage.sprite = battery [0];			
			break;
		case 10:
			batteryImage.sprite = battery [1];
			break;
		case 15:
			batteryImage.sprite = battery [2];
			break;
		case 20:
			batteryImage.sprite = battery [3];
			break;
		case 25:
			batteryImage.sprite = battery [4];
			break;
		case 30:
			batteryImage.sprite = battery [5];
			break;
		case 35:
			batteryImage.sprite = battery [6];
			break;
		case 40:
			batteryImage.sprite = battery [7];
			break;
		}
	}

	private void GameOver()
	{
		gameOver.SetActive (true);
		gameOverText.text = string.Format ("Lograste cambiar el emisor de gases de {0} vehículos, ¡inténtalo de nuevo y oxigena tu ciudad! \n " +
			"Tu puntuación fue de {1}", VehiclesGameManager.amountOfVehiclesFixed, VehiclesGameManager.globalScore);

		if (EnergyGameManager.amountOfLightTurnOff <= level1) {
			gameOverText.text = string.Format ("Lograste apagar {0} luces, muy pocas, no has ahorrado suficiente energía para ayudar al planeta, ¡inténtalo de nuevo!", EnergyGameManager.amountOfLightTurnOff);
		}

		if (EnergyGameManager.amountOfLightTurnOff > level2 && EnergyGameManager.amountOfLightTurnOff <= level3) {
			gameOverText.text = string.Format ("Lo hiciste muy bien, {0} luces, pero puedes hacerlo mejor, completa la carga de la batería para utilizar la energía cuando sea realmente necesario, ¡inténtalo de nuevo!", EnergyGameManager.amountOfLightTurnOff);
		}

		if (EnergyGameManager.amountOfLightTurnOff > level3) {
			gameOverText.text = string.Format ("Increíble, has hecho un trabajo perfecto, {0} luces, no solo ayudaste el planeta, sino que ahorraste dinero en los servicios de energía", EnergyGameManager.amountOfLightTurnOff);
		}
	}
}
