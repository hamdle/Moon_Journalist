using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterDialog : MonoBehaviour {

	public int dialogID;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("GM");
		go.GetComponent<DialogRegistrar>().RegisterDialog(dialogID);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
