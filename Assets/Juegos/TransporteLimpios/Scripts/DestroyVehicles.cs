using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVehicles : MonoBehaviour {

	void OnBecameInvisible()
	{
		VehiclesGameManager.totalVehiclesGameobjects.Remove(GetComponentInParent<VehicleMovement>().gameObject);
		DestroyObject(GetComponentInParent<VehicleMovement>().gameObject);
	}
}
