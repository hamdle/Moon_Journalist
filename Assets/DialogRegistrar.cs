using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogRegistrar : MonoBehaviour {

	public int lastLoadedSceneIndex = -1;

	public bool reloadedSameLevel;

	public int[] sceneDialogIDs;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool HasDialogBeenPlayed(int id)
	{
		return sceneDialogIDs[id] == 0 ? true : false;
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (lastLoadedSceneIndex == scene.buildIndex)
		{
			reloadedSameLevel = true;
		}
		else
		{
			reloadedSameLevel = false;
			ClearDialogIDs();
		}

		lastLoadedSceneIndex = scene.buildIndex;
	}

	private void ClearDialogIDs()
	{
		for (int i = 0; i < sceneDialogIDs.Length; i++)
		{
			sceneDialogIDs[i] = 0;
		}
	}

	public void RegisterDialog(int id)
	{
		if (!reloadedSameLevel)
			sceneDialogIDs[id] = 1;
	}

	public void ConsumedDialog(int id)
	{
		sceneDialogIDs[id] = 0;
	}
}
