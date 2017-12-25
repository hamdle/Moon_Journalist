using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	private bool soundOn;

	void Awake () {

		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		InitGame();
	}

	public void InitGame()
	{
		soundOn = true;
	}

	public void ToggleSound()
	{
		if (soundOn)
		{
			// Turn sound off
			AudioListener.volume = 0.0f;
			soundOn = false;
		}
		else
		{
			// Turn sound on
			AudioListener.volume = 1.0f;
			soundOn = false;
		}
	}

}
