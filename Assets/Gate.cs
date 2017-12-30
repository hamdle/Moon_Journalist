using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour {

	public int sceneIndex = -1;

	public PlayerMove playerMove;

	public AudioClip gateSound;
	public AudioClip melodySound;
	public AudioSource gateAudioSource;
	public AudioSource melodyAudioSource;

	// Use this for initialization
	void Start () {
		gateAudioSource.clip = gateSound;
		melodyAudioSource.clip = melodySound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			// Load next level
			Debug.Log("Gate");
			gateAudioSource.Play();
			melodyAudioSource.Play();
			playerMove.DisableMove();
			//SceneManager.LoadScene(getSceneIndex());
		}
	}

	// Load scene 0 if index is less than 0
	// or greater than the number of scenes
	private int getSceneIndex()
	{
		if (sceneIndex < 0)
		{
			return 0;
		}
		if (sceneIndex > SceneManager.sceneCount)
		{
			return 0;
		}

		return sceneIndex;
	}
}
