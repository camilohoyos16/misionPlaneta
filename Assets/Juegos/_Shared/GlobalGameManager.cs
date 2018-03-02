using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour {

	private static GlobalGameManager instance;
	public static GlobalGameManager Instance
	{
		get{ return instance; }
	}

	[SerializeField] private int lifes;
	public int Lifes
	{
		get{ return lifes; }
	}

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		DontDestroyOnLoad (this.gameObject);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoseLife()
	{
		lifes--;
	}
}
