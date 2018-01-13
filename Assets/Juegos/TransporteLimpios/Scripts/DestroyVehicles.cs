using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVehicles : MonoBehaviour {

	void OnBecameInvisible()
	{
		Destroy (GetComponentInParent<VehicleMovement>().gameObject);
	}
}
