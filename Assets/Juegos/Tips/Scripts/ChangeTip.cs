using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTip : MonoBehaviour {

	[SerializeField] private Animator c_animator;
	public enum position{
		right,
		left
	}

	public position curentPosition;
	private int pushButton;

	void Start()
	{
		pushButton = 0;
		curentPosition = position.left;
	}

	void Update()
	{
	}

	public void OnChangePage()
	{
		if (pushButton != 0) {
			if (curentPosition == position.right) {
				curentPosition = position.left;
				c_animator.SetTrigger ("toRight");
			} else if (curentPosition == position.left) {
				curentPosition = position.right;
				c_animator.SetTrigger ("toLeft");
			}
		} else {
			c_animator.SetTrigger ("firstMove");
			pushButton++;
		}
	}
}
