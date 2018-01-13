using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VehicleMovement : MonoBehaviour {

	[SerializeField] public Direction directionOfMovement;
	[SerializeField] private float speedOfMovement;
	[SerializeField] private Vehicles typeOfVehicle;

	private Vector2 movementVector;
	private int score;
	private Rigidbody2D c_rigidBody;
	private Animator c_vehicleAnimator;

	// Use this for initialization
	void Start () {
		c_rigidBody = GetComponent<Rigidbody2D> ();
		c_vehicleAnimator = GetComponentInChildren<Animator> ();
		AssignScoreValue ();
		AssignMovementVector ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	private void Move()
	{
		c_rigidBody.velocity = movementVector;
	}

	void OnMouseDown()
	{
		c_vehicleAnimator.SetTrigger ("isFixed");
		GetComponent<BoxCollider2D> ().enabled = false;
		VehiclesGameManager.Instance.PlusScore (score);
	}

	private void AssignScoreValue()
	{
		switch (typeOfVehicle) {
		case Vehicles.motorcycle:
			score = 1;
			break;
		case Vehicles.car:
			score = 2;
			break;
		case Vehicles.truck:
			score = 3;
			break;
		}
	}

	private void AssignMovementVector()
	{
		Vector2 movement = Vector2.zero;

		switch (directionOfMovement) {
		case Direction.down:
			movementVector = movement + (Vector2.down * speedOfMovement);
			break;
		case Direction.left:
			movementVector = movement + (Vector2.left * speedOfMovement);
			Vector3 newScale = new Vector3 (-1,transform.localScale.y, transform.localScale.z);
			transform.localScale = newScale;
			break;
		case Direction.right:
			movementVector = movement + (Vector2.right * speedOfMovement);
			break;
		case Direction.up:
			movementVector = movement + (Vector2.up * speedOfMovement);
			break;
		}
	}
}
