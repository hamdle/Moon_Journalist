using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessDialog : MonoBehaviour {

	public GameObject dialogBox;

	Queue<StoryElement> storyQueue;
	bool dialogDataLoaded;
	bool waitingOnDialog;
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
				se.TriggerDialog();
				waitingOnDialog = true;
			}
			else
			{
				// CONSUME THE DIALOG
				Destroy(dialogToDestroy);
				storyQueue = new Queue<StoryElement>();
				dialogDataLoaded = false;
				waitingOnDialog = false;
			}
		}
	}

	public void DialogEnded()
	{
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
