using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerBehaviour : MonoBehaviour {

	public containerType type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown()
	{
		TrashGameManager.Instance.CheckTrashContainer (type);
	}
}
