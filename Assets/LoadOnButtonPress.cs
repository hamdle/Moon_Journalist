﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnButtonPress : MonoBehaviour {

	public int sceneIndex;

	public void LoadScene()
	{

		SceneManager.LoadScene(sceneIndex);
	}
}
