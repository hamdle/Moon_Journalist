using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedKillOnCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		Invoke("KillSelf", 1f);
	}

	private void KillSelf()
	{
		Destroy(this.gameObject);
	}
}
