using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum animals
{
	elefante,
	foca,
	gallina,
	cocodrilo,
	leon,
	armadillo,
	tortuga
}

public enum habitat
{
	granja,
	mar,
	selva
}

public class HabitatGameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static bool CheckAnimalHabitat(animals animals, habitat habitat)
	{
		switch(habitat)
		{
			case habitat.granja:
				if(animals == animals.gallina)
					return true;
				break;
			case habitat.mar:
				break;
			case habitat.selva:
				break;
		}
		return false;
	}
}
