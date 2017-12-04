using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour {

	public Button startButton;

	// Use this for initialization
	void Start () {
		Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		bool start = Input.GetButtonDown("Submit");

		if (start)
		{
			StartGame();
		}
	}

	private void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	void TaskOnClick()
	{
		StartGame();
	}
}
