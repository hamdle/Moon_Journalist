using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public AudioSource OKAudio;

	//public List<int> levelsComplete;
	// New
	public int[] unlockedLevels;
	Dictionary<int, int> buildSettingsMap;

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
		//levelsComplete = new List<int>();

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

	public void LevelComplete(int i)
	{
		Debug.Log("Level completed " + unlockedLevels.Length);
		if (buildSettingsMap.ContainsKey(i + 1))
		{
			unlockedLevels[buildSettingsMap[i + 1]] = 1;
		}

		//levelsComplete.Add(i);
	}

}
