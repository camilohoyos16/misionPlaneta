using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabitatCollisions : MonoBehaviour {

	private HabitatInformation data;
	private bool isColliding;
	private AnimalInformation animalTarget;
	private Animator c_animator;
	private RandomShake shake;
	private bool isChecking=false;
	public bool isCorrectAndAnimating=false;

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
		if (isChecking && isColliding && !animalTarget.gameObject.GetComponent<AnimalsMovement> ().isBeClicking) {
			isChecking = false;
			CheckCollision ();
		}
	}

	void OnTriggerEnter2D(Collider2D target)
	{
		if (!isCorrectAndAnimating) {
			animalTarget = target.GetComponent<AnimalInformation> ();
			if (animalTarget != null) {
				isColliding = true;
				shake.enabled = false;
				c_animator.SetBool ("hover", true);
				isChecking = true;
			}
			else{
				isColliding = false;
			}
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

	void CheckCollision()
	{
		if (isColliding) {
			if (HabitatGameManager.instance.CheckAnimalHabitat (animalTarget.animalType, data.habitatType, c_animator)) {
				isCorrectAndAnimating = true;
			} else {
				animalTarget.gameObject.GetComponent<AnimalsMovement> ().MoveToStartPosition ();
			}
		}
	}

	public void StartAnimation()
	{
		HabitatGameManager.instance.SetActiveAllObjects (false, animalTarget.gameObject);
	}

	public void EndAnimation()
	{
		HabitatGameManager.instance.SetActiveAllObjects (true);
		animalTarget.gameObject.SetActive (false);
		isCorrectAndAnimating = false;
		HabitatGameManager.instance.PlusScore ();
	}
}
