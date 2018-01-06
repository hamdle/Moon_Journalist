using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public AudioSource OKAudio;

	private bool disableFire;

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
		disableFire = false;
	}

	public void ToggleSound()
	{
		if (soundOn)
		{
			// Turn sound off
			AudioListener.volume = 0.0f;
			soundOn = false;
			Debug.Log("MUTE");
		}
		else
		{
			// Turn sound on
			AudioListener.volume = 1.0f;
			soundOn = true;
			Debug.Log("UNMUTE");
		}
	}

	public void PlayOKSound()
	{
		OKAudio.Play();
	}

	public void DisableFireForDialog()
	{
		Debug.Log("Disabled fire");
		disableFire = true;
	}

	public void EnableFireForDialog()
	{
		disableFire = false;
	}

	public bool IsFireDisabled()
	{
		return disableFire;
	}

}
