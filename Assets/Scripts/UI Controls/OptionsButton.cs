using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour {

	public GameObject optionsMenu;

	private bool showOptionsMenu;

	// Use this for initialization
	void Start () {
		showOptionsMenu = false;
		optionsMenu.SetActive(showOptionsMenu);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleOptionsMenu()
	{
		showOptionsMenu = !showOptionsMenu;
		optionsMenu.SetActive(showOptionsMenu);
	}
}
