using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearIcons : MonoBehaviour {

	[SerializeField] private Image[] iconsImages;
	[SerializeField] private Button[] iconsButtons;
	[SerializeField] private float timeToAppear;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < iconsButtons.Length; i++) {
			iconsButtons [i].enabled = false;
		}
		for (int i = 0; i < iconsImages.Length; i++) {
			Color tempColor = iconsImages [i].color;
			tempColor.a = 0;
			iconsImages [i].color = tempColor;
		}
	}

	void OnEnable()
	{
		SceneController.onLoadAdd += DisableButtonClick;
		SceneController.onUnload += EnableButtonClick;
	}

	void OnDisable()
	{
		SceneController.onLoadAdd -= DisableButtonClick;
		SceneController.onUnload -= EnableButtonClick;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnAppearImages()
	{
		StartCoroutine (AppearingIcons ());
	}

	IEnumerator AppearingIcons()
	{
		float timer = 0;
		float currentColorValur;
		Color tempColor = iconsImages [0].color;
		while (timer < timeToAppear) {
			timer += Time.deltaTime;
			currentColorValur = Mathf.Lerp (0, 1, timer / timeToAppear);
			tempColor.a = currentColorValur;
			for (int i = 0; i < iconsImages.Length; i++) {
				iconsImages [i].color = tempColor;
			}
			yield return null;
		}
		EnableButtonClick();
	}

	private void EnableButtonClick()
	{
		for (int i = 0; i < iconsButtons.Length; i++) {
			iconsButtons [i].enabled = true;
		}
	}

	private void DisableButtonClick()
	{
		for (int i = 0; i < iconsButtons.Length; i++) {
			iconsButtons [i].enabled = false;
		}
	}
}
