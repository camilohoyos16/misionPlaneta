using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum animals
{
	bagre,
	armadillo,
	delfin,
	pato,
	titi,
	tortuga
}

public enum habitat
{
	bosque,
	campo,
	rio,
	jungla
}

public class HabitatGameManager : MonoBehaviour {

	public static HabitatGameManager instance;

	public List<GameObject> animalsAndHabitats = new List<GameObject>();
	private int score;
	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

	public bool CheckAnimalHabitat(animals animals, habitat habitat, Animator animator)
	{
		bool result = false;
		switch(habitat)
		{
		case habitat.bosque:
			if (animals == animals.armadillo) {
				result = true;
				animator.SetTrigger("correctAnimal");
			}
				break;
		case habitat.campo:
			if (animals == animals.pato) {
				result = true;
				animator.SetTrigger ("correctAnimalPato");
			}
			if (animals == animals.tortuga) {
				result = true;
				animator.SetTrigger("correctAnimalTortuga");
			}
				break;
		case habitat.jungla:
			if (animals == animals.titi) {
				result = true;
				animator.SetTrigger("correctAnimal");
			}
				break;
		case habitat.rio:
			if (animals == animals.bagre) {
				result =  true;
				animator.SetTrigger("correctAnimalBagre");
			}
			if(animals == animals.delfin)
			{
				result =  true;
				animator.SetTrigger("correctAnimalDelfin");
			}
				break;
		}
		ActiveSound (result);
		return result;
	}

	public AudioSource collisionSounds;
	public AudioClip good;
	public AudioClip bad;

	private void ActiveSound(bool result)
	{
		if (result) {
			collisionSounds.clip = good;
			collisionSounds.Play ();
		} else {
			collisionSounds.clip = bad;
			collisionSounds.Play ();
		}
	}

	public GameObject gameOver;
	public void PlusScore()
	{
		score++;
		if (score >= 4) {
			gameOver.SetActive (true);
		}
	}

	public void SetActiveAllObjects(bool activeState, GameObject animal= null)
	{
		for (int i = 0; i < animalsAndHabitats.Count; i++) {
			HabitatCollisions habitat = animalsAndHabitats [i].GetComponent<HabitatCollisions> ();
			if (habitat != null) {
				if(!habitat.isCorrectAndAnimating)
					animalsAndHabitats [i].SetActive (activeState);
			} else {
				animalsAndHabitats [i].SetActive (activeState);
				if (animal != null) {
					if (animalsAndHabitats [i].GetInstanceID () == animal.GetInstanceID ()) {
						animalsAndHabitats.Remove (animal);
						i--;
					}
				}
			}
		}
	}

	public GameObject tutorial;
	public void DissapearTutorial()
	{
		tutorial.SetActive (false);
	}


}
