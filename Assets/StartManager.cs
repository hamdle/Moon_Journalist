using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour {

	public Button startButton;
	public Button quitButton;

	// Use this for initialization
	void Start () {
		Button btnStart = startButton.GetComponent<Button>();
		btnStart.onClick.AddListener(StartOnClick);

		Button btnQuit = quitButton.GetComponent<Button>();
		btnQuit.onClick.AddListener(QuitOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		bool start = Input.GetButtonDown("Submit");
		bool quit = Input.GetButtonDown("Cancel");

		if (start)
		{
			StartGame();
		}
		if (quit)
		{
			QuitGame();
		}
	}

	private void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	private void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}

	void StartOnClick()
	{
		StartGame();
	}

	void QuitOnClick()
	{
		QuitGame();
	}
}
