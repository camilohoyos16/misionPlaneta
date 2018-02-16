using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	public trashType type;
	private Rigidbody2D rigidBody;
	private Vector2 moveVector;

	public bool algo;

	void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	private void Movement()
	{
		moveVector = Vector2.up * -moveSpeed;
		rigidBody.velocity = moveVector * Time.deltaTime;
	}

	void OnMouseDown()
	{
		TrashGameManager.Instance.CurrentTrash = type;
	}
}
