using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneDeath : MonoBehaviour {

	float deathDelay = 0.5f;
	SpriteRenderer sr;
	Collider2D col;
	Color currentColor;
	bool fadeOut = false;
	float timer = 0;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		col = GetComponent<Collider2D>();
		currentColor = sr.color;
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
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		fadeOut = true;
		col.enabled = false;

		Invoke("KillSelf", deathDelay);
	}

	private void KillSelf()
	{
		Destroy(this.gameObject);
	}
}
