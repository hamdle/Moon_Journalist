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
		Debug.Log(collision.tag);
		if (collision.tag.Equals("Crate") || collision.tag.Equals("PatrolEnemy"))
		{
			// break it
			EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
			enemyHealth.StartKill();
		}

		if (collision.tag.Equals("Player"))
		{
			EnemyCollision enemyCollision = collision.gameObject.GetComponent<EnemyCollision>();
			enemyCollision.RemoveHitPoints();
		}
	}
}
