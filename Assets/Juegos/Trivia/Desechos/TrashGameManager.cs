using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum trashType
{
	nothing
}

public enum containerType
{
}

public class TrashGameManager : MonoBehaviour {

	private static TrashGameManager instance;
	public static TrashGameManager Instance
	{
		get{ return instance; }
	}

	private trashType currentTrashType;
	public trashType CurrentTrash
	{
		set{ currentTrashType = value; }
	}

	void OnDisable()
	{
		instance = null;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckTrashContainer(containerType container)
	{
		if (currentTrashType == trashType.nothing) {
			return;
		} else {
			switch (container) {

			}
		}
	}

	private void AppearTrivia()
	{
		ScoreManager.Instance.AppearTrivia ();
	}

}
