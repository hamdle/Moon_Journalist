using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	public PlayerHealth playerHealth;
	public float hitRecoveryTime = 1.0f;
	public bool hitRecovery = false;

	public AudioClip hurtSound;
	public AudioSource hurtAudioSource;


	// Use this for initialization
	void Start () {
		hurtAudioSource.clip = hurtSound;
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
				// Make sure the enemy is not already dead
				// Could happen if while killTimer is counting down
				EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
				if (!enemyHealth.IsDying())
				{
					hurtAudioSource.Play();
					playerHealth.PlayerHit(1);
					hitRecovery = true;
					Invoke("RecoverFromHit", hitRecoveryTime);
				}
			}
		}
	}

	private void RecoverFromHit()
	{
		hitRecovery = false;
	}
}
