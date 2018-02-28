using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum trashType
{
	glass,
	organic,
	paper,
	plastic
}

public enum containerType
{
	glass,
	organic,
	paper,
	plastic
}

public class TrashGameManager : MonoBehaviour {

	public delegate void TrashSelectionBehaviour(TrashMovement trash);
	public event TrashSelectionBehaviour onSelectTrash;

	private static TrashGameManager instance;
	public static TrashGameManager Instance
	{
		get{ return instance; }
	}

	private TrashMovement currentTrash;
	public TrashMovement CurrentTrash
	{
		get{ return currentTrash; }
		set{ currentTrash = value; if (onSelectTrash != null) {
				onSelectTrash (currentTrash);
			}}
	}

	private int amountOfCurrentTrash;
	public int AmountOfCurrentTrash
	{
		get{ return amountOfCurrentTrash; }
		set{ amountOfCurrentTrash = value; }
	}

	public GameObject parenToSpawn;


	void OnDisable()
	{
		instance = null;
	}

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);

		ScoreManager.instance.onStartTrivia += EraseScreen;
	}

	void OnDestroy()
	{
		ScoreManager.instance.onStartTrivia -= EraseScreen;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckTrashContainer(containerType container)
	{
		if (currentTrash == null)
			return;
		if (currentTrash.type.ToString() == container.ToString()) {
			amountOfCurrentTrash--;
			Destroy (currentTrash.gameObject);
			currentTrash = null;
			print ("bien");
			if (amountOfCurrentTrash <= 0)
				PlusScore ();
			return;
		}
		amountOfCurrentTrash = 0;
		PlusScore ();
		print ("mal");
	}

	private void PlusScore()
	{
		AppearTrivia ();
	}

	private void EraseScreen()
	{
		TrashMovement[] trashers = parenToSpawn.GetComponentsInChildren<TrashMovement> ();
		for (int i = 0; i < trashers.Length; i++) {
			Destroy (trashers [i].gameObject);
		}
	}

	private void AppearTrivia()
	{
		ScoreManager.Instance.AppearTrivia ();
	}

}
