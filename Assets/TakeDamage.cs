using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

	public float killTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Projectile"))
		{
			Invoke("Kill", killTimer);
		}
	}

	private void Kill()
	{
		Destroy(this.gameObject);
	}
}
