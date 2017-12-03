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
		/*Debug.Log(Color.red);
		Color color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
		Debug.Log(color);
		sr.color = color;
		*/
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeOut)
		{
			if (timer < deathDelay)
			{
				timer += Time.deltaTime;
				currentColor.a = deathDelay - timer;
				Debug.Log(currentColor.a);
				sr.color = currentColor;
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// todo setup fade to alpha based on deathDelay
		fadeOut = true;
		col.enabled = false;
		Invoke("KillSelf", deathDelay);
	}

	private void FadeOut()
	{
		//transform.position = startingPosition + offset;

		/*
		Debug.Log("Fade out...");
		Color color = sr.color;
		float waitTime = deathDelay * Time.deltaTime / 255;
		Debug.Log(waitTime);

		for (int x = 255; x > 0; x--)
		{

			color.a = x * waitTime;
			Debug.Log(color);
			sr.color = color;
			yield return new WaitForSeconds(waitTime);
		}
		*/
	}

	private void KillSelf()
	{
		
		Destroy(this.gameObject);
	}
}
