using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsMovement : MonoBehaviour {

	public bool isBeClicking;

	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMoseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		isBeClicking = true;

	}

	void OnMouseUp()
	{
		isBeClicking = false;
	}

	void OnMouseDrag()
	{
		isBeClicking = true;
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		curPosition.z = 0;
		transform.position = curPosition;

	}

	public void MoveToStartPosition()
	{
		transform.position = startPosition;
	}

	private void ImageMovement()
	{
		//transform.position
	}
}
