using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	bool paused = false;
	public Canvas canvas;

	// Use this for initialization
	void Start () {
		canvas.enabled = false;
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
			canvas.enabled = true;
		}
		else
		{
			Time.timeScale = 1.0f;
			canvas.enabled = false;
		}
	}
}
