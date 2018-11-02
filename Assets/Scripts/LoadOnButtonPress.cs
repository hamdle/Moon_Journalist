using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnButtonPress : MonoBehaviour {

	public int sceneIndex;

	public void LoadScene()
	{
		Debug.Log("button press");
		GameObject go = GameObject.FindGameObjectWithTag("GM");
		GameManager gm = go.GetComponent<GameManager>();

		if (sceneIndex != 0)
			gm.PlayGamePlayMusic();

		SceneManager.LoadScene(sceneIndex);
	}
}
