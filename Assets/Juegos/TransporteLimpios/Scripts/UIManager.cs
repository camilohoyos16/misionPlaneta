using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[Header ("GameOverElements")]
	[SerializeField] private GameObject gameOver;
	[SerializeField] private Image imageRanked;
	[SerializeField] private Sprite carsLevel1;
	[SerializeField] private Sprite carsLevel2;
	[SerializeField] private Sprite carsLevel3;
	[SerializeField] private Text gameOverText;

	[Header("Tutorial elements")]
	[SerializeField] private GameObject tutorial;
	[SerializeField] private int tutorialTime;
	[SerializeField] private PopUpsController popup;

	public AudioSource spokenTutorial;

	void OnEnable()
	{
	}

	void OnDisable()
	{
		VehiclesGameManager.Instance.onGameOver -= GameOver;
	}

	void Start () {
		VehiclesGameManager.Instance.onGameOver += GameOver;
		tutorial.SetActive (true);
		gameOver.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickDissapearTutorial()
	{
		tutorial.SetActive (false);
		spokenTutorial.Stop ();
		popup.OnStartPopUps ();
	}

	private void GameOver()
	{
		gameOver.SetActive (true);
		gameOverText.text = string.Format ("Lograste cambiar el emisor de gases de {0} vehículos, ¡inténtalo de nuevo y oxigena tu ciudad! \n " +
			"Tu puntuación fue de {1}", VehiclesGameManager.amountOfVehiclesFixed, VehiclesGameManager.globalScore);

		if (VehiclesGameManager.amountOfVehiclesFixed > 10 && VehiclesGameManager.amountOfVehiclesFixed <= 20) {
			imageRanked.sprite = carsLevel1;
		}

		if (VehiclesGameManager.amountOfVehiclesFixed > 20 && VehiclesGameManager.amountOfVehiclesFixed <= 30) {
			imageRanked.sprite = carsLevel2;
		}

		if (VehiclesGameManager.amountOfVehiclesFixed > 30) {
			imageRanked.sprite = carsLevel3;
		}
	}
}
