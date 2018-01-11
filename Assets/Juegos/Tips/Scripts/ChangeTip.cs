using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTip : MonoBehaviour {

	[SerializeField] private GameObject[] tips;
	[SerializeField] private Text tipsPositionInformation;

	private GameObject currentActiveTip;
	private int currentActiveTipIndex;

	void Start()
	{
		currentActiveTipIndex = 0;
		//currentActiveTip = tips [currentActiveTipIndex];
		tips [0].SetActive (true);

		for (int i = 1; i < tips.Length; i++) {
			tips [i].SetActive (false);
		}
	}

	void Update()
	{
		tipsPositionInformation.text = string.Format ("{0} / {1}", currentActiveTipIndex + 1, tips.Length);
	}

	public void ChangeTipRight()
	{
		tips [currentActiveTipIndex].SetActive (false);
		currentActiveTipIndex++;

		if (currentActiveTipIndex > tips.Length -1) {
			currentActiveTipIndex = 0;
		}

		tips [currentActiveTipIndex].SetActive (true);
	}

	public void ChangeTipLeft()
	{
		tips [currentActiveTipIndex].SetActive (false);
		currentActiveTipIndex--;

		if (currentActiveTipIndex < 0) {
			currentActiveTipIndex = tips.Length - 1;
		}

		tips [currentActiveTipIndex].SetActive (true);
	}
}
