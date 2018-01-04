using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour {

	public bool freezeGame = true;
	public bool zoomIn = false;
	public float zoomToPosition = 0f;
	public bool disableControls = true;

	public Dialog dialog;
	// A way to feed this to the dialog manager
	public void TriggerDialog()
	{
		FindObjectOfType<DialogManager>().StartDialog(dialog, freezeGame, zoomIn, zoomToPosition);
	}

	public bool DisableControls()
	{
		return disableControls;
	}
}
