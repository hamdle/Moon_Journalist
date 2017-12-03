using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] int health = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		CheckFallDeath();

		if (health < 0)
		{
			Die();
		}
	}

	void CheckFallDeath()
	{
		if (gameObject.transform.position.y < -7)
		{
			PlayerHit(health + 1);
		}
	}

	void Die()
	{
		SceneManager.LoadScene("Main");
	}

	public void PlayerHit(int damage)
	{
		health -= damage;
	}

	public void HealthCollected()
	{
		health++;
	}
}
