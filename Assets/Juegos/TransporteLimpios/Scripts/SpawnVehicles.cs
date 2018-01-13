using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVehicles : MonoBehaviour {

	[SerializeField] private GameObject[] vehiclesPrefabs;
	[SerializeField] private SpawnPointInformation[] spawnPoint;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < spawnPoint.Length; i++) {
			spawnPoint [i].isAvailable = true;
		}
		Spawning ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Spawning()
	{
		int randomCar = 0;
		int randomPoint = 0;

		if (!CheckIsUnless1IsAvailable()) 
		{
			StartCoroutine(CallToSpawn ());
			return;
		}

		do {
			randomPoint = Random.Range (0, spawnPoint.Length);
			
		} while(!spawnPoint [randomPoint].isAvailable);

		randomCar = Random.Range (0, vehiclesPrefabs.Length);
		GameObject currentVehiculToSpawn = vehiclesPrefabs [randomCar];

		spawnPoint [randomPoint].isAvailable = false;
		currentVehiculToSpawn.GetComponent<VehicleMovement> ().directionOfMovement = spawnPoint[randomPoint].spawnDirection;

		Instantiate (currentVehiculToSpawn, spawnPoint [randomPoint].transform.position, transform.rotation);

		StartCoroutine (ActiveSpawnPoint(spawnPoint [randomPoint]));
		StartCoroutine (CallToSpawn ());
	}

	private bool CheckIsUnless1IsAvailable()
	{
		for (int i = 0; i < spawnPoint.Length; i++) {
			if (spawnPoint [i].isAvailable)
				return true;
		}
		return false;
	}

	IEnumerator CallToSpawn()
	{
		yield return new WaitForSeconds (0.5f);
		Spawning ();
	}

	IEnumerator ActiveSpawnPoint(SpawnPointInformation spawnPoint)
	{
		yield return new WaitForSeconds (3);
		spawnPoint.isAvailable = true;
	}
}
