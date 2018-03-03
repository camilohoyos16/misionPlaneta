using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipInformation : MonoBehaviour {

	public int view = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PluView()
	{
		if (!VideoManager.instance.isPlaying) {
			if(view == 0)
				view++;
			VideoManager.instance.StartTimer ();
		}
	}
}
