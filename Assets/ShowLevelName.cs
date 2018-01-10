using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowLevelName : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text text = gameObject.GetComponent<Text>();
		text.text = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
