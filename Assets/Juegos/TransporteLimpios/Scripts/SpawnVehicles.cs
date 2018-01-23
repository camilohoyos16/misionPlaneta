using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnVehicles : MonoBehaviour {

	[SerializeField] private VehicleMovement[] vehiclesPrefabs;
	[SerializeField] private SpawnPointInformation[] spawnPoint;

	[SerializeField] private List<VehicleMovement> vehiclesSmeaforo = new List<VehicleMovement>();

	void OnEnable()
	{
	}

	void OnDisable()
	{
		VehiclesGameManager.Instance.onGameOver -= DisableSpawnPoints;
		VehiclesGameManager.Instance.onGameStart -= Spawning;
		Semaforo.redLight -= DisableSpawnPointsCauseSemaforo;
		Semaforo.greenLight -= EnableSpawnPointsCauseSemaforo;
	}

	// Use this for initialization
	void Start () {
		VehiclesGameManager.Instance.onGameOver += DisableSpawnPoints;
		Semaforo.redLight += DisableSpawnPointsCauseSemaforo;
		Semaforo.greenLight += EnableSpawnPointsCauseSemaforo;
		VehiclesGameManager.Instance.onGameStart += Spawning;
		for (int i = 0; i < spawnPoint.Length; i++) {
			spawnPoint [i].isAvailable = true;
		}
	}

	void EnableSpawnPointsCauseSemaforo()
	{
		for (int i = 0; i < spawnPoint.Length; i++) {
			if (spawnPoint [i].spawnDirection == Direction.right) {
				spawnPoint [i].gameObject.SetActive (true);
				spawnPoint [i].isAvailable = true;
			}
		}
	}

	void DisableSpawnPointsCauseSemaforo()
	{
		StopAllCoroutines ();

		/*for (int i = 0; i < vehiclesSmeaforo.Count; i++) {
			vehiclesSmeaforo [i].StopVehicle ();
		}*/

		for (int i = 0; i < spawnPoint.Length; i++) {
			if (spawnPoint [i].spawnDirection == Direction.right) {
				spawnPoint [i].isAvailable = false;
				spawnPoint [i].gameObject.SetActive (false);
			} else {
				StartCoroutine (ActiveSpawnPoint (spawnPoint[i]));
			}
		}
		Spawning ();
	}

	void DisableSpawnPoints()
	{
		for (int i = 0; i < spawnPoint.Length; i++) {
			spawnPoint [i].isAvailable = false;
		}
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
		VehicleMovement currentVehiculToSpawn = vehiclesPrefabs [randomCar];
		spawnPoint [randomPoint].isAvailable = false;
		currentVehiculToSpawn.directionOfMovement = spawnPoint[randomPoint].spawnDirection;

		currentVehiculToSpawn.speedOfMovement = spawnPoint [randomPoint].speed;
		currentVehiculToSpawn.vehicleLayer = spawnPoint [randomPoint].vehicleLayer;
		VehicleMovement car = Instantiate (currentVehiculToSpawn, spawnPoint [randomPoint].transform.position, transform.rotation);
		if (car.directionOfMovement == Direction.right)
			vehiclesSmeaforo.Add (car);
		VehiclesGameManager.totalVehiclesGameobjects.Add (car.gameObject);
		car.gameObject.SetActive (true);

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
		yield return new WaitForSeconds (1.5f); 
		spawnPoint.isAvailable = true;
	}
}
