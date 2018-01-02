using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health;
	public float killTimer;
	[Range(0,1)] public float flashTimer;

	public AudioClip deathSound;
	public AudioSource deathAudioSource;

	bool dying = false;
	List<int> hitIDs;

	// Use this for initialization
	void Start () {
		deathAudioSource.clip = deathSound;
		hitIDs = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsDying()
	{
		return dying;
	}

	public void StartKill()
	{
		// Destroy object after killTimer seconds
		deathAudioSource.Play();
		dying = true;
		Invoke("Kill", killTimer + deathSound.length);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Projectile"))
		{
			int id = collision.gameObject.GetInstanceID();
			// todo this is broken
			// Disable all further collisions
			collision.collider.enabled = false;

			// Flash sprite to indicate hit damage
			StartCoroutine(Flash(this.gameObject, flashTimer));

			if (hitIDs.Contains(id))
				health--;

			if (health < 1 && !dying)
			{
				StartKill();
			}

			hitIDs.Add(id);
		}
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

	private void Kill()
	{
		Destroy(this.gameObject);
	}
}
