using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public delegate void ScenesBehaviour();
	public static event ScenesBehaviour onLoadAdd;
	public static event ScenesBehaviour onUnload;
	public Camera menuCamera;
	[SerializeField] private string levelName;
	[SerializeField] private float timeToLoadLevel;
	[SerializeField] private bool changeInStart;

	// Use this for initialization
	void Start () {
		if (changeInStart) {
			LoadScene ();
		}
	}

	void OnEnable()
	{
		onLoadAdd += TurnOffCamera;
		onUnload += TurnOnCamera;
	}

	void OnDisable()
	{
		onLoadAdd -= TurnOffCamera;
		onUnload -= TurnOnCamera;
	}

	private void TurnOffCamera()
	{
		if(menuCamera != null)
			menuCamera.enabled = false;
	}

	private void TurnOnCamera()
	{
		if(menuCamera != null)
			menuCamera.enabled = true;
	}

	public void OnPlayAgain()
	{
		Scene level = SceneManager.GetSceneAt (1);
		SceneManager.UnloadSceneAsync (level);
		SceneManager.LoadScene (level.name, LoadSceneMode.Additive);
	}

	public void RemoveScene()
	{
		SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt (1));
		if (onUnload != null)
			onUnload ();
	}

	public void LoadSceneAdd()
	{
		StartCoroutine (ChangeSceneAdd ());
	}

	IEnumerator ChangeSceneAdd()
	{
		yield return new WaitForSeconds (timeToLoadLevel);
		SceneManager.LoadScene (levelName, LoadSceneMode.Additive);
		if (onLoadAdd != null)
			onLoadAdd ();
	}

	public void LoadScene()
	{
		StartCoroutine (ChangeScene ());
	}

	IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds (timeToLoadLevel);
		SceneManager.LoadScene (levelName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
