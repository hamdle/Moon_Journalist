using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	bool paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool pause = Input.GetButtonDown("Submit");
		
		if (pause)
		{
			paused = !paused;
			Pause();
		}
	}

	private void Pause()
	{
		if (paused)
		{
			Time.timeScale = 0.0f;
		}
		else
		{
			Time.timeScale = 1.0f;
		}
	}
}
