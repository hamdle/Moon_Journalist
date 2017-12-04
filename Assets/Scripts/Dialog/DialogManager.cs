﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogText;

	public Animator animator;

	private Queue<string> sentences;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialog(Dialog dialog)
	{
		animator.SetBool("IsOpen", true);

		nameText.text = dialog.name;

		sentences.Clear();

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
		animator.SetBool("IsOpen", false);
	}


}
