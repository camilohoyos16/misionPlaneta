using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShake : MonoBehaviour {

	[SerializeField] private float minRandomValue;
	[SerializeField] private float maxRandomValue;

	private Animator c_animator;
	private float timeToShake;

	// Use this for initialization
	void Start () {
		c_animator = GetComponent<Animator> ();
		Shake ();
	}

	private void Shake()
	{
		timeToShake = Random.Range (minRandomValue, maxRandomValue);
		StartCoroutine (Shaking ());
	}

	IEnumerator Shaking()
	{
		yield return new WaitForSeconds (timeToShake);
		c_animator.SetTrigger ("shake");
		Shake ();
	}
}
