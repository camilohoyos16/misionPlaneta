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
	
	public static bool CheckAnimalHabitat(animals animals, habitat habitat)
	{
		switch(habitat)
		{
			case habitat.bosque:
			if(animals == animals.armadillo)
					return true;
				break;
			case habitat.campo:
				break;
			case habitat.jungla:
				break;
			case habitat.rio:
				break;
		}
		return false;
	}
}
