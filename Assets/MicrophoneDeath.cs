using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneDeath : MonoBehaviour {

	float deathDelay = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// todo setup fade to alpha based on deathDelay
		//Color color = this.gameObject.GetComponent<Renderer>().material.color;

		Invoke("KillSelf", deathDelay);
	}

	private void KillSelf()
	{
		
		Destroy(this.gameObject);
	}
}
