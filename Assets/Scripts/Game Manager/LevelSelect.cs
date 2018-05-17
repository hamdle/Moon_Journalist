using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public int[] levels;

	// Use this for initialization
	void Start () {

		// Check for Level Select scene
		Scene thisScene = SceneManager.GetActiveScene();
		if (thisScene.name == "LevelSelect")
		{
			// More comments go here
			Debug.Log(levels.Length);
			for (int i = 0; i < levels.Length; i++)
			{
				Debug.Log(levels[i]);
				if (levels[i] == 0)
				{
					GameObject level1 = GameObject.FindGameObjectWithTag("Level " + (i+1));
					Button button1 = level1.GetComponent<Button>();
					button1.interactable = false;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
