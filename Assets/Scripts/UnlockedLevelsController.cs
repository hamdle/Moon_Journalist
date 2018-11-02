using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockedLevelsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("GM");
		GameManager gm = go.GetComponent<GameManager>();
		//gm.LevelComplete(SceneManager.GetActiveScene().buildIndex);
		//Debug.Log(gm.unlockedLevels[0]);
		//Debug.Log(gm.unlockedLevels[1]);

		//GameObject Level1 = GameObject.FindGameObjectWithTag("Level 1");
		//Button Level1Button = Level1.GetComponent<Button>();
		//Level1Button.interactable = gm.unlockedLevels[0] == 0 ? false: true;

		for (int i = 0; i < 8; i++)
		{
			GameObject Level = GameObject.FindGameObjectWithTag("Level " + (i + 1).ToString());
			Button LevelButton = Level.GetComponent<Button>();
			LevelButton.interactable = gm.unlockedLevels[i] == 0 ? false : true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
