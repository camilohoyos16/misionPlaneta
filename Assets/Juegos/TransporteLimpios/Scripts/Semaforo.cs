using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Semaforo : MonoBehaviour {

	public delegate void SemaforoBehaviour();
	public static event SemaforoBehaviour redLight;
	public static event SemaforoBehaviour greenLight;
	public static bool canMove;
	[SerializeField] private SpriteRenderer semaforo;
	[SerializeField] private Sprite green;
	[SerializeField] private Sprite yellow;
	[SerializeField] private Sprite red;

	[SerializeField] private float timeOfRedLight;
	[SerializeField] private float timeOfGreenLight;

	void OnEnable()
	{
	}

	void OnDisable()
	{
		VehiclesGameManager.Instance.onGameStart -= RedLight;
	}

	// Use this for initialization
	void Start () {
		VehiclesGameManager.Instance.onGameStart += RedLight;
		semaforo.sprite = green;
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void GreenLight()
	{
		StartCoroutine (ChangeToGreenLight ());
	}

	IEnumerator ChangeToGreenLight()
	{
		yield return new WaitForSeconds (timeOfRedLight/1.5f);
		semaforo.sprite = yellow;
		yield return new WaitForSeconds (timeOfRedLight);
		semaforo.sprite = green;
		if (greenLight != null)
			greenLight ();
		canMove = true;
		RedLight ();
	}

	private void RedLight()
	{
		StartCoroutine (ChangeToRedLight ());
	}

	IEnumerator ChangeToRedLight()
	{
		yield return new WaitForSeconds (timeOfGreenLight);
		semaforo.sprite = red;
		if (redLight != null)
			redLight ();
		canMove = false;
		GreenLight ();
	}
}
