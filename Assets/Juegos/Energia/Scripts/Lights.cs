using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lights : MonoBehaviour {

	[SerializeField] private float minTime;
	[SerializeField] private float maxTime;
	[SerializeField] private int amountOfScore;
	private float timeToTurnOn;



	[Header("")]
	[SerializeField] private Color offColor;
	[SerializeField] private Color onColor;
	private Button c_button;

	private Image c_image;
	private bool isOn;
	private bool turnOnFirstTime;
	// Use this for initialization
	void Start () {
		turnOnFirstTime = false;
		isOn = false;
		c_button = GetComponent<Button> ();
		c_button.interactable = false;
		c_image = GetComponent<Image> ();
		c_image.color = offColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator turnOnLight;
	IEnumerator TurnOnLight()
	{
		yield return new WaitForSeconds (timeToTurnOn);
		EnergyGameManager.Instance.PlusLghTurnOn ();
		c_image.color = onColor;
		isOn = true;
		c_button.interactable = true;

		if (!turnOnFirstTime) 
		{
			turnOnFirstTime = true;
			EnergyGameManager.Instance.ControlFirstTurnOn ();
		}
	}

	public void StartTurnOnAgain()
	{
		timeToTurnOn = Random.Range (minTime, maxTime);
		if (!turnOnFirstTime) 
		{
			timeToTurnOn = minTime;
		}
		turnOnLight = TurnOnLight ();
		StartCoroutine (turnOnLight);
	}

	public void OnLightClick()
	{
		EnergyGameManager.Instance.PlusScore (amountOfScore);
		c_image.color = offColor;
		isOn = false;
		c_button.interactable = false;
		StartTurnOnAgain ();
	}
}
