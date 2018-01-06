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

		//sceneDialogIDs;
	}
	
	// Update is called once per frame
	void Update () {
		
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
		}

		lastLoadedSceneIndex = scene.buildIndex;
	}

	public void RegisterDialog(int id)
	{
		sceneDialogIDs[id] = id;
	}
}
