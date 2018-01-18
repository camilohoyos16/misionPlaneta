using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerMenu : MonoBehaviour {

	[Header ("Sound")]
	[SerializeField] private AudioSource c_audioLisener;
	[SerializeField] private AudioClip selva;
	[SerializeField] private AudioClip staticSound;
	[SerializeField] private float tiemrToChange;

	void OnEnable()
	{
		SceneController.onLoadAdd += TurnOffMusic;
		SceneController.onUnload += TurnOnMusic;
	}

	void OnDisable()
	{
		SceneController.onLoadAdd -= TurnOffMusic;
		SceneController.onUnload -= TurnOnMusic;
	}

	private void  TurnOffMusic()
	{
		c_audioLisener.Stop();
	}

	private void TurnOnMusic()
	{
		c_audioLisener.Play();
	}

	// Use this for initialization
	void Start () {
		c_audioLisener.clip = selva;
		c_audioLisener.volume = 1;
		c_audioLisener.Play ();
		StartCoroutine (ChangeMenuSound ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ChangeMenuSound()
	{
		//!c_audioLisener.isPlaying
		while (c_audioLisener.time < selva.length) {
			yield return null;
		}

		c_audioLisener.clip = staticSound;
		c_audioLisener.loop = true;
		c_audioLisener.volume = 0;
		c_audioLisener.Play ();

		float timer=0;
		float tempVolume = 0;

		while (timer < tiemrToChange) {
			timer += Time.deltaTime;
			tempVolume = Mathf.Lerp (0, 1, timer / tiemrToChange);
			c_audioLisener.volume = tempVolume;
			yield return null;
		}
	}
}
