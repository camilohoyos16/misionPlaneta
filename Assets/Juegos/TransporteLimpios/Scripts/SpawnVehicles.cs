using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicles : MonoBehaviour {

	[SerializeField] private GameObject[] vehiclesPrefabs;
	[SerializeField] private GameObject[] spawnPoint;
	[SerializeField] private Direction spawnDirection;
	[SerializeField] private SortingLayer spriteLayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Spawning()
	{
		int randomNumber = Random.Range (0, 3);
		GameObject currentVehiculToSpawn = Instantiate (vehiclesPrefabs [randomNumber], transform.position, transform.rotation);
		currentVehiculToSpawn.GetComponent<VehicleMovement> ().directionOfMovement = spawnDirection;
		currentVehiculToSpawn.GetComponentInChildren<SpriteRenderer> ().sortingLayerName = spriteLayer.name;
	}
}
