using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawning : MonoBehaviour {

	[Header ("Tash Data")]
	public TrashData trashData;
	public TrashMovement prefab;

	[Header ("Spawn data")]
	[Space (10)]
	[SerializeField] private int amountOfObjectsToSpawn;
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private Transform parentToSpawn;

	private List<int> indexesTrashToUse = new List<int>();
	private List<int> indexesSpawnPointsToUse = new List<int>();

	void Awake()
	{
		ScoreManager.instance.onStartTrash += StartToSpawn;
	}

	void OnDestroy()
	{
		ScoreManager.instance.onStartTrash -= StartToSpawn;
	}

	// Use this for initialization
	void Start () {
		TrashGameManager.Instance.parenToSpawn = parentToSpawn.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void StartToSpawn()
	{
		float something = indexesTrashToUse.Count;
		float tempValueIndexesPoints = indexesSpawnPointsToUse.Count;
		for (int i = 0; i < something; i++) {
			indexesTrashToUse.RemoveAt(0);
		}

		for (int i = 0; i < tempValueIndexesPoints; i++) {
			indexesSpawnPointsToUse.RemoveAt(0);
		}
			
		for (int i = 0; i < trashData.data.Count; i++) {
			indexesTrashToUse.Add (i);
		}

		for (int i = 0; i < spawnPoints.Length; i++) {
			indexesSpawnPointsToUse.Add (i);
		}

		Spawning ();
	}

	private void Spawning()
	{
		int randomNumber = 0;
		int randomPoint = 0;
		for (int i = 0; i < amountOfObjectsToSpawn; i++) {
			TrashGameManager.Instance.AmountOfCurrentTrash++;
			randomNumber = Random.Range (0, indexesTrashToUse.Count);
			randomPoint = Random.Range (0, indexesSpawnPointsToUse.Count);
			TrashMovement newTrash = Instantiate (prefab, spawnPoints [indexesSpawnPointsToUse[randomPoint]].transform.position, prefab.gameObject.transform.rotation);
			newTrash.gameObject.transform.SetParent (parentToSpawn);
			newTrash.name = trashData.data[indexesTrashToUse[randomNumber]].name;
			newTrash.sprite = trashData.data[indexesTrashToUse[randomNumber]].sprite;
			newTrash.type = trashData.data[indexesTrashToUse[randomNumber]].type;
			indexesTrashToUse.RemoveAt (randomNumber);
			indexesSpawnPointsToUse.RemoveAt (randomPoint);
		}
	}
}
