using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public GameObject dialogBox;
	public ProcessDialog dialogProcessor;

	public Text nameText;
	public Text dialogText;

	public Animator animator;

	private Queue<string> sentences;
	private bool stopTime = true;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialog(Dialog dialog, bool freezeGame)
	{
		//animator.SetBool("IsOpen", true);
		stopTime = freezeGame;
		
		nameText.text = dialog.name;

		sentences.Clear();

		//Debug.Log("Open dialog");
		OpenDialog();

		foreach (string sentence in dialog.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialog();
			return;
		}

		string sentence = sentences.Dequeue();

		// Make sure we stop animating current dialog before we start animating new one.
		// If typeSentence is already running we will stop doing so
		// so we can start a new one.
		StopAllCoroutines();

		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogText.text += letter;
			// Wait a single frame
			yield return null;
		}
	}

	void EndDialog()
	{
		//animator.SetBool("IsOpen", false);
		
		// Hide the dialog box
		GameObject.FindGameObjectWithTag("Dialog Box").SetActive(false);
		// Let process dialog know this dialog has been processed
		dialogProcessor.DialogEnded();
		// Turn time back on
		if (stopTime)
			Time.timeScale = 1.0f;
	}

	private void OpenDialog()
	{
		// Turn off time to pause the game objects
		if (stopTime)
			Time.timeScale = 0.0f;

		// show the dialog box
		dialogBox.SetActive(!dialogBox.activeInHierarchy);
	}

}
