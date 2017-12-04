using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	public PlayerHealth playerHealth;
	public float hitRecoveryTime = 1.0f;
	public bool hitRecovery = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// If we havent been hit recently
		if (!hitRecovery)
		{
			if (collision.gameObject.CompareTag("PatrolEnemy"))
			{
				playerHealth.PlayerHit(1);
				hitRecovery = true;
				Invoke("RecoverFromHit", hitRecoveryTime);
			}
		}
	}

	private void RecoverFromHit()
	{
		hitRecovery = false;
	}
}
