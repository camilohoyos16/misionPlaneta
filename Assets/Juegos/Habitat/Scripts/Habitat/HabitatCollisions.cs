using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitatCollisions : MonoBehaviour {

	private HabitatInformation data;
	private bool isColliding;
	private AnimalInformation animalTarget;
	private Animator c_animator;
	private RandomShake shake;

	void Awake()
	{
		data = GetComponent<HabitatInformation> ();
		c_animator = GetComponent<Animator> ();
		shake = GetComponent<RandomShake> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		animalTarget = target.GetComponent<AnimalInformation> ();
		if (animalTarget != null) {
			isColliding = true;
			shake.enabled = false;
			c_animator.SetBool ("hover", true);
		}
		else{
			isColliding = false;
		}
	}

	void OnTriggerExit2D(Collider2D target)
	{
		AnimalInformation exitAnimal = target.GetComponent<AnimalInformation> ();
		if (exitAnimal != null) {
			isColliding = false;
			shake.enabled = true;
			c_animator.SetBool ("hover", false);
		}
	}

	void OnMouseUp()
	{
		if (isColliding) {
			if (HabitatGameManager.CheckAnimalHabitat (animalTarget.animalType, data.habitatType)) {
				c_animator.SetTrigger("correctAnimal");
			}
		}
	}
}
