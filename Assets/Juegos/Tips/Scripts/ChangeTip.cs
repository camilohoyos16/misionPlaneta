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

	void Start()
	{
		curentPosition = position.left;
	}

	void Update()
	{
	}

	public void OnChangePage()
	{
		if (curentPosition == position.right) {
			curentPosition = position.left;
			c_animator.SetTrigger ("toLeft");
		}else if (curentPosition == position.left) {
			curentPosition = position.right;
			c_animator.SetTrigger ("toRight");
		}
	}
}
