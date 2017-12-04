using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryElement : MonoBehaviour {

	public Dialog dialog;

	// A way to feed this to the dialog manager
	public void TriggerDialog()
	{
		FindObjectOfType<DialogManager>().StartDialog(dialog);
	}
}
