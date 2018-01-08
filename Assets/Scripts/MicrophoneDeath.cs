using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneDeath : MonoBehaviour {

	public float timeLeftToLive = 1f;
	float timeLeftTimer = 0;

	AudioSource[] hitAudioSource;

	float deathDelay = 0.5f;
	SpriteRenderer sr;
	Collider2D col;
	Color currentColor;
	bool fadeOut = false;
	float timer = 0;

	bool playedDeathSound = false;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		col = GetComponent<Collider2D>();
		currentColor = sr.color;

		hitAudioSource = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeOut)
		{
			if (timer < deathDelay)
			{
				timer += Time.deltaTime;
				currentColor.a = deathDelay - timer;
				sr.color = currentColor;
			}
		}
		else
		{
			timeLeftTimer += Time.deltaTime;

			if (timeLeftTimer > timeLeftToLive)
			{
				Invoke("KillSelf", 0f);
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (!playedDeathSound)
		{
			int random = Random.Range(0, 3);
			hitAudioSource[random].Play();
			playedDeathSound = true;
		}
		

		fadeOut = true;
		col.enabled = false;

		Invoke("KillSelf", deathDelay);
	}

	private void KillSelf()
	{
		Destroy(this.gameObject);
	}
}
