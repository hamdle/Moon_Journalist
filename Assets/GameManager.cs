using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public AudioSource OKAudio;
	public bool mute = false;

	//public AudioClip menuAudioClip;
	public AudioSource menuAudioSource;
	public AudioSource gameplayAudioSource;
	public AudioSource gameplayAudioSource1;
	public AudioSource gameplayAudioSource2;
	public AudioSource gameplayAudioSource3;

	//public List<int> levelsComplete;
	// New
	public int[] unlockedLevels;
	Dictionary<int, int> buildSettingsMap;

	private bool soundOn;

	public Canvas pauseCanvas;
	private bool paused = false;

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
		//levelsComplete = new List<int>();
		if (mute)
			AudioListener.volume = 0f;

		pauseCanvas.enabled = false;

		unlockedLevels = new int[] { 1, 0, 0, 0, 0, 0, 0, 0 };
		buildSettingsMap = new Dictionary<int, int>();

		buildSettingsMap.Add(3, 0);
		buildSettingsMap.Add(4, 1);
		buildSettingsMap.Add(5, 2);
		buildSettingsMap.Add(6, 3);
		buildSettingsMap.Add(7, 4);
		buildSettingsMap.Add(8, 5);
		buildSettingsMap.Add(9, 6);
		buildSettingsMap.Add(10, 7);

		soundOn = true;
	}

	public void Start()
	{
		//menuAudioSource.clip = menuAudioClip;
		menuAudioSource.Play();
	}
	public void Update()
	{
		bool pauseRelease = Input.GetButtonUp("Fire3") || Input.GetButtonDown("Cancel");

		if (pauseRelease)
		{
			int sceneIndex = SceneManager.GetActiveScene().buildIndex;
			Debug.Log("Scene " + sceneIndex);

			if (buildSettingsMap.ContainsKey(sceneIndex))
			{
				if (paused)
				{
					Time.timeScale = 1;
					paused = false;
					pauseCanvas.enabled = false;
					gameplayAudioSource.UnPause();
				}
				else
				{
					// Pause the game
					Time.timeScale = 0;
					paused = true;
					pauseCanvas.enabled = true;
					gameplayAudioSource.Pause();
				}
			}
		}
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

	public void PlayGamePlayMusic()
	{
		// Gameplay music is decided here
		menuAudioSource.Stop();
		
		int i = Random.Range(0, 3);
		Debug.Log(i);
		switch (i)
		{
			case 0:
				gameplayAudioSource = gameplayAudioSource1;
				Debug.Log(i);
				break;
			case 1:
				gameplayAudioSource = gameplayAudioSource2;
				Debug.Log(i);
				break;
			case 2:
				gameplayAudioSource = gameplayAudioSource3;
				Debug.Log(i);
				break;
			default:
				gameplayAudioSource = gameplayAudioSource1;
				Debug.Log("d");
				break;
		}
		//gameplayAudioSource.Play();
		//gameplayAudioSource2
		//gameplayAudioSource3
		gameplayAudioSource.Play();
	}

	public void PlayWinGameMusic()
	{
		menuAudioSource.Play();
		gameplayAudioSource.Stop();
	}

	public void LevelComplete(int i)
	{
		Debug.Log("Level completed " + unlockedLevels.Length);
		if (buildSettingsMap.ContainsKey(i + 1))
		{
			unlockedLevels[buildSettingsMap[i + 1]] = 1;
			// Music transition from gameplay to menu
			gameplayAudioSource.Stop();
			menuAudioSource.Play();
		}

		//levelsComplete.Add(i);
	}

	public bool IsPaused()
	{
		return paused;
	}

}
