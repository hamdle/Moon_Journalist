using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gate : MonoBehaviour {

	public int sceneIndex = -1;

	public PlayerMove playerMove;

	public AudioClip gateSound;
	public AudioClip melodySound;
	public AudioSource gateAudioSource;
	public AudioSource melodyAudioSource;

	public Camera mainCamera;
	public float sizeStep;
	public float stopOnDepth;

	public Canvas clearCanvas;
	private Text clearText;
	bool zoomIn = false;

	private void Awake()
	{
		gameObject.GetComponent<ParticleSystem>().Play();
	}
	// Use this for initialization
	void Start () {
		gateAudioSource.clip = gateSound;
		melodyAudioSource.clip = melodySound;

		clearCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (zoomIn)
		{
			mainCamera.orthographicSize -= sizeStep * Time.deltaTime;
		}

		if (mainCamera.orthographicSize < stopOnDepth)
		{
			mainCamera.orthographicSize = stopOnDepth;
			zoomIn = false;
			clearCanvas.gameObject.SetActive(true);
			//SceneManager.LoadScene(getSceneIndex());
		}
	}

	public void EnterGate()
	{
		GameObject go = GameObject.FindGameObjectWithTag("GM");
		GameManager gm = go.GetComponent<GameManager>();
		gm.LevelComplete(SceneManager.GetActiveScene().buildIndex);
		Debug.Log(gm.levelsComplete);
		SceneManager.LoadScene(getSceneIndex());
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
			zoomIn = true;
			clearCanvas.enabled = true;
			clearText = gameObject.GetComponent<Text>();
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
		/* doesnt have correct count?
		if (sceneIndex > SceneManager.sceneCount)
		{
			return 0;
		}
		*/

		return sceneIndex;
	}
}
