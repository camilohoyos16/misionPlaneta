using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HabitatStartAnimals : MonoBehaviour {

	[SerializeField] private GameObject[] animalObjects;

	[SerializeField] private List<AnimalData> data = new List<AnimalData>();
	private List<AnimalData> tempData= new List<AnimalData>();

	// Use this for initialization
	void Start () {
		tempData.AddRange (data);
		StartAnimals ();
	}
	
	private void StartAnimals()
	{
		int randomIndex = 0;
		for (int i = 0; i < animalObjects.Length; i++) {
			randomIndex = UnityEngine.Random.Range (0, tempData.Count);
			animalObjects [i].GetComponent<SpriteRenderer> ().sprite = tempData [randomIndex].sprite;
			animalObjects [i].GetComponent<AnimalInformation> ().animalType= tempData [randomIndex].animalType;
			tempData.RemoveAt (randomIndex);
		}
	}
}

[Serializable]
public class AnimalData
{
	public Sprite sprite;
	public animals animalType;
}
