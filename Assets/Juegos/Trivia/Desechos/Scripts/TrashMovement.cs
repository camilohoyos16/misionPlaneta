using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] 
	[HideInInspector] public trashType type;
	[HideInInspector] public Sprite sprite;
	[HideInInspector] public string name;
	private SpriteRenderer spriteRender;
	private Rigidbody2D rigidBody;
	private Vector2 moveVector;

	void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D> ();
		spriteRender = GetComponent<SpriteRenderer> ();
		TrashGameManager.Instance.onSelectTrash += DelesectedTrash;
	}

	void OnDestroy()
	{
		TrashGameManager.Instance.onSelectTrash -= DelesectedTrash;
	}

	void Start () {
		spriteRender.sprite = sprite;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	private void Movement()
	{
		moveVector = Vector2.up * -moveSpeed;
		rigidBody.velocity = moveVector * Time.deltaTime;
	}

	void DelesectedTrash(TrashMovement trash)
	{
		if (trash.gameObject.GetInstanceID() != this.gameObject.GetInstanceID()) {
			spriteRender.color = Color.white;
		}
	}

	void OnMouseDown()
	{
		TrashGameManager.Instance.CurrentTrash = this;
		spriteRender.color = Color.gray;
	}
}
