using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialogOnTrigger : MonoBehaviour {

	public GameObject dialogBox;
	ShowHideDialog shDialog;
	StoryElement dialog;
	bool toggled = false;

	// Use this for initialization
	void Start () {
		shDialog = GetComponent<ShowHideDialog>();
		dialog = GetComponent<StoryElement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!toggled)
		{
			if (collision.gameObject.tag.Equals("Player"))
			{
				dialog.TriggerDialog();
				shDialog.ShowHideToggle(dialogBox);
				toggled = true;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		// toggled = false;
	}
}
