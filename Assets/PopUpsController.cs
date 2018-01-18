using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpsController : MonoBehaviour {

	[SerializeField] private Animator c_animator;

	// Use this for initialization
	void Start () {
		c_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnStartGame()
	{
		VehiclesGameManager.Instance.OnGameStart();
	}

	public void OnStartPopUps()
	{
		c_animator.SetTrigger ("start");
	}
}
