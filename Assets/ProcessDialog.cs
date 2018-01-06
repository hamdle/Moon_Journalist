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
	int dialogID;

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

		GameObject go = GameObject.FindGameObjectWithTag("GM");
		go.GetComponent<DialogRegistrar>().ConsumedDialog(dialogID);
		//go.GetComponent<GameManager>().EnableFireForDialog();

		waitingOnDialog = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		

		if (collision.gameObject.tag.Equals("Dialog"))
		{
			GameObject collisionGameObject = collision.gameObject;
			bool forceThisDialog = collisionGameObject.GetComponent<DialogForcer>().forceDialogToPlay;

			
			// already loaded dialog data
			if (dialogDataLoaded && !forceThisDialog)
				return;

			RegisterDialog registerDialog = collisionGameObject.GetComponent<RegisterDialog>();
			dialogID = registerDialog.dialogID;
			GameObject go = GameObject.FindGameObjectWithTag("GM");
			bool hasBeenPlayed = go.GetComponent<DialogRegistrar>().HasDialogBeenPlayed(dialogID);
			if (hasBeenPlayed)
			{
				DialogEnded();
				return;
			}

			if (forceThisDialog)
			{
				PlayerMove playerMove = gameObject.GetComponent<PlayerMove>();
				playerMove.DisableMove();
			}

			// Turn waiting on dialog off
			// and clear up player movment flags
			if (!forceThisDialog)
				waitingOnDialog = false;

			dialogToDestroy = collisionGameObject;
			storyQueue.Clear();
			// Grab all the story elements
			StoryElement[] storyElements = collision.gameObject.GetComponents<StoryElement>();
			// Process the elements
			for (int i = 0; i < storyElements.Length; i++)
			{
				storyQueue.Enqueue(storyElements[i]);
			}

			dialogDataLoaded = true;
			
		}
	}

	public bool DialogDisableControls()
	{
		return disableControls;
	}
}
