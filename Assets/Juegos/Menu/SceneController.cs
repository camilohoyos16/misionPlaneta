using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	[SerializeField] private string levelName;
	[SerializeField] private AsyncOperation asyncProcess;

	public void LoadAsyncLevel(string levelName)
	{
		StartCoroutine (LevelLoading (levelName));
	}

	IEnumerator LevelLoading(string levelName)
	{
		SceneManager.LoadSceneAsync (levelName, LoadSceneMode.Additive);
		yield return null;
	}

}
