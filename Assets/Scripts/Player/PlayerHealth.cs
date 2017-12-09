using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] int health = 0;
	[SerializeField] [Range(0, 1)] float flashTimer = 0.1f;
	[SerializeField] int fallDistance = -7;

	public AudioClip dieSound;
	public AudioSource dieAudioSource;
	float dieWaitLength;
	
	// Use this for initialization
	void Start () {
		dieAudioSource.clip = dieSound;
		dieWaitLength = dieSound.length;
	}
	
	// Update is called once per frame
	void Update () {

		CheckFallDeath();

		if (health < 0)
		{
			dieAudioSource.Play();
			Invoke("Die", dieWaitLength);
		}
	}

	void CheckFallDeath()
	{
		if (gameObject.transform.position.y < fallDistance)
		{
			PlayerHit(health + 1);
		}
	}

	void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void PlayerHit(int damage)
	{
		health -= damage;
		StartCoroutine(Flash(this.gameObject, flashTimer));
	}

	private IEnumerator Flash(GameObject gameObject, float flashTimer)
	{
		SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

		//for (int i = 0; i < 10; i++)
		//{
		spriteRenderer.enabled = false;
		yield return new WaitForSeconds(flashTimer);
		spriteRenderer.enabled = true;
		yield return new WaitForSeconds(flashTimer);
		//}
	}

	public void HealthCollected()
	{
		health++;
	}
}
