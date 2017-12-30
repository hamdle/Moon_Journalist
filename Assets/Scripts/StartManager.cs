using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour {

	public Button startButton;
	public Button quitButton;
	public Button optionsButton;

	// Use this for initialization
	void Start () {
		Button btnStart = startButton.GetComponent<Button>();
		btnStart.onClick.AddListener(StartOnClick);

		Button btnQuit = quitButton.GetComponent<Button>();
		btnQuit.onClick.AddListener(QuitOnClick);

		Button btnOptions = optionsButton.GetComponent<Button>();
		btnOptions.onClick.AddListener(OptionsOnClick);
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
		Invoke("LoadFirstScene", 1f);
	}

	private void LoadFirstScene()
	{
		SceneManager.LoadScene("Level1-1");
	}

	private void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}

	private void OptionsGame()
	{
		Debug.Log("OPTIONS");
		// todo show optiosn menu
	}

	void StartOnClick()
	{
		StartGame();
	}

	void QuitOnClick()
	{
		QuitGame();
	}

	void OptionsOnClick()
	{
		OptionsGame();
	}
}
