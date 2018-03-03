using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour {

	public RawImage rawImage;
	public VideoPlayer videoPlayer;
	public GameObject GameOver;
	public List<TipInformation> tips = new List<TipInformation>();

	public bool isPlaying = false;

	public static VideoManager instance;

	public void VictoryCondition()
	{
		if (CheckAMountOfTipsViewed()) {
			GameOver.SetActive (true);
		}
	}

	float timer=0;
	void Update()
	{
		timer += Time.deltaTime;
		if (timer >= 20) {
			GameOver.SetActive (true);
		}
	}

	public void StartTimer()
	{
		timer = 0;
	}

	public bool CheckAMountOfTipsViewed()
	{
		bool result;
		for (int i = 0; i < tips.Count; i++) {
			if (tips [i].view == 0) {
			
				return false;	
			}
		}
		return true;
	}

	IEnumerator timeToGameover;
	IEnumerator TimeToGameover()
	{
		yield return new WaitForSeconds (20);
		GameOver.SetActive (true);
	}

	void Start()
	{
		instance = this;
		rawImage.enabled = false;
	}

	public void StartVideo(VideoClip video)
	{
		if (!rawImage.isActiveAndEnabled) {
			StartCoroutine (PlayVideo (video));
		}
	}

	IEnumerator PlayVideo(VideoClip video)
	{
		yield return new WaitForSeconds (0.2f);
		isPlaying = true;
		rawImage.enabled = (true);
		videoPlayer.clip = video;
		videoPlayer.Play ();
		StartCoroutine (DisactiveRawImage ());
	}

	IEnumerator DisactiveRawImage()
	{
		yield return new WaitForSeconds (0.5f);
		while (videoPlayer.isPlaying) {
			yield return null;
		}
		rawImage.enabled = (false);
		isPlaying = false;
		VictoryCondition ();
	}
}
