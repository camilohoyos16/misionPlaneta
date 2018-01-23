using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VehicleMovement : MonoBehaviour {

	[SerializeField] public Direction directionOfMovement;
	public float speedOfMovement;
	[SerializeField] private Vehicles typeOfVehicle;
	[SerializeField] private GameObject fixedVehicle;
	private Vector2 movementVector;
	private int score;
	private Rigidbody2D c_rigidBody;
	private Animator c_vehicleAnimator;
	public string vehicleLayer;
	public int isFixed;
	public GameObject needToFixedImage;
	public GameObject needToFixedImage2;
	public bool isInSemaforo;
	public bool isMove;

	// Use this for initialization
	void Start () {
		Semaforo.redLight += StopVehicle;
		Semaforo.greenLight += MoveVehicleAgain;		
		isInSemaforo = false;
		isMove = true;
		isFixed = Random.Range ((int)0, (int)2);
		c_rigidBody = GetComponent<Rigidbody2D> ();
		c_vehicleAnimator = GetComponentInChildren<Animator> ();
		GetComponentInChildren<SpriteRenderer> ().sortingLayerName = vehicleLayer;
		needToFixedImage.GetComponent<SpriteRenderer> ().sortingLayerName = vehicleLayer;
		needToFixedImage2.GetComponent<SpriteRenderer> ().sortingLayerName = vehicleLayer;
		AssignScoreValue ();
		AssignMovementVector ();
		if (isFixed == 1)
			OnMouseDown ();
	}

	void OnEnable()
	{
	}

	void OnDisable()
	{
		Semaforo.redLight -= StopVehicle;
		Semaforo.greenLight -= MoveVehicleAgain;
	}

	// Update is called once per frame
	void Update () {
		if(isMove)
			Move ();
	}

	private void Move()
	{
		c_rigidBody.velocity = movementVector;
	}

	void OnMouseDown()
	{
		c_vehicleAnimator.SetTrigger ("isFixed");
		needToFixedImage.SetActive (false);
		if (isFixed == 0) {
			isFixed = 1;
			//GetComponent<BoxCollider2D> ().enabled = false;
			Instantiate (fixedVehicle, transform.position + Vector3.up * 1, fixedVehicle.transform.rotation);
			VehiclesGameManager.Instance.PlusScore (score);
		}
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
			Vector3 newScale = new Vector3 (-1, transform.localScale.y, transform.localScale.z);
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

	public void StopVehicle()
	{
		if (isInSemaforo) {
			c_rigidBody.velocity = Vector2.zero;
			isMove = false;
		}
	}

	public void MoveVehicleAgain()
	{
		if (isInSemaforo) {
			c_rigidBody.velocity = movementVector;
			isMove = true;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.CompareTag ("semaforo")) {
			isInSemaforo = true;
			if (!Semaforo.canMove)
				StopVehicle ();
		}
	}

	/*void OnTriggerStay2D(Collider2D coll){
		if (coll.CompareTag ("semaforo")) {
			if (!Semaforo.canMove)
				StopVehicle ();
			isInSemaforo = true;
		}
	}*/

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.CompareTag ("semaforo")) {
			isInSemaforo = false;
		}
	}
}
