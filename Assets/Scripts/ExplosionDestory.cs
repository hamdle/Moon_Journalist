using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestory : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag.Equals("Crate") || collision.tag.Equals("PatrolEnemy"))
		{
			// Destory it
			EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
			enemyHealth.StartKill();
		}

		if (collision.tag.Equals("Player"))
		{
			// Remove health
			EnemyCollision enemyCollision = collision.gameObject.GetComponent<EnemyCollision>();
			enemyCollision.RemoveHitPoints();
		}
	}
}
