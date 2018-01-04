using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessDialog : MonoBehaviour {

	public GameObject dialogBox;

	Queue<StoryElement> storyQueue;
	bool dialogDataLoaded;
	bool waitingOnDialog;
	bool disableControls;
	GameObject dialogToDestroy;

	// Use this for initialization
	void Start () {
		dialogDataLoaded = false;
		waitingOnDialog = false;

		// dont forget to instantiate the stack!
		storyQueue = new Queue<StoryElement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (waitingOnDialog)
			return;

		if (dialogDataLoaded)
		{
			// Dialog has been loaded
			if (storyQueue.Count != 0)
			{
				// We have more story elements in the queue
				StoryElement se = storyQueue.Dequeue();
				if (se.zoomIn)
				{
					// Set position here
					//se.zoomToPosition;
				}

				// Let the Player Move script know we need to
				// disable controls if the Story Element wants to
				disableControls = se.DisableControls();
				if (disableControls)
				{
					PlayerMove playerMove = gameObject.GetComponent<PlayerMove>();
					playerMove.DisableMove();
				}

				// Tell the Story Element notify the Dialog Manager
				// to begin loading dialog attached to this element
				se.TriggerDialog();
				waitingOnDialog = true;
			}
			else
			{
				// consume (DESTROY) the dialog after processing
				Destroy(dialogToDestroy);
				storyQueue = new Queue<StoryElement>();
				dialogDataLoaded = false;
				waitingOnDialog = false;
			}
		}
	}

	public void DialogEnded()
	{
		if (disableControls)
		{
			PlayerMove playerMove = gameObject.GetComponent<PlayerMove>();
			playerMove.EnableMove();
			disableControls = false;
		}

		waitingOnDialog = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// already loaded dialog data
		if (dialogDataLoaded)
			return;

		if (collision.gameObject.tag.Equals("Dialog"))
		{
			dialogToDestroy = collision.gameObject;
			// Grab all the story elements
			StoryElement[] storyElements = collision.gameObject.GetComponents<StoryElement>();
			// Process the elements
			for (int i = 0; i < storyElements.Length; i++)
			{
				storyQueue.Enqueue(storyElements[i]);
				Debug.Log("pushed " + i);
			}

			dialogDataLoaded = true;

			// Load lines into dialog box
			//storyElements[0].TriggerDialog();

			// Open dialog box
			//OpenDialog();



			//dialog.TriggerDialog();
			//shDialog.ShowHideToggle(dialogBox);
			//toggled = true;
		}
	}
}
