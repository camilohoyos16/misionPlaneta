using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "TrashData", menuName = "TrashData", order = 1)]
public class TrashData : ScriptableObject {
	[SerializeField] public List<TrashInformation> data;
}

[Serializable]
public class TrashInformation
{
	public string name;
	public Sprite sprite;
	public trashType type;
}
