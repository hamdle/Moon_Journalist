using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCommand : MonoBehaviour {

	public float launchTriggerDistance = 5.0f;

	[SerializeField] Vector2 fireForce;

	public AudioClip fireSound;
	public AudioSource fireAudioSource;

	bool inRange = false;
	bool fire = false;
	bool firing = false;
	Transform other;
	Rigidbody2D rb;

	// Track stages of the rocket launch
	bool fallingBackDown = false;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		other = GameObject.FindGameObjectWithTag("Player").transform;
		fireAudioSource.clip = fireSound;
	}
	
	// Update is called once per frame
	void Update () {
		// STAGE 1: Handle when to fire
		if (inRange && !firing)
		{
			// Only do the extra target processing
			// if the rocket is visible to the player
			CheckTargetDistance();
		}

		// STAGE 2: Firing up. Check for falling
		if (firing && !fallingBackDown)
		{
			// Triggered once when starts falling
			if (rb.velocity.y < 0)
			{
				fallingBackDown = true;
				transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
			}
		}

		// STAGE 3: Is falling
		if (fallingBackDown)
		{
			// Move towards player while falling
			float x = transform.position.x;
			float px = other.transform.position.x;
			// Start with a base of 1
			float moveFactor = 1f;
			int moveFactorStep = 4;

			if (x > px)
			{
				// For every 5 x distance add 1 to the base moveFactor
				moveFactor += Mathf.Abs(Mathf.Round((px - x) / moveFactorStep));
				transform.position = new Vector3(transform.position.x - moveFactor * Time.deltaTime, transform.position.y, transform.position.z);
			}
			else
			{
				moveFactor += Mathf.Abs(Mathf.Round((x - px) / moveFactorStep));
				transform.position = new Vector3(transform.position.x + moveFactor * Time.deltaTime, transform.position.y, transform.position.z);
			}
		}
		
	}

	private void FixedUpdate()
	{
		if (fire)
		{
			firing = true;

			rb.AddRelativeForce(fireForce);

			// The rocket has been fired
			fire = false;
		}
	}

	private void OnBecameVisible()
	{
		inRange = true;
	}

	private void OnBecameInvisible()
	{
		inRange = false;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Todo: explode
	}

	void CheckTargetDistance()
	{
		if (other)
		{
			float dist = Vector3.Distance(other.position, transform.position);
			if (dist < launchTriggerDistance)
			{
				fire = true;
				fireAudioSource.Play();
			}
		}
	}
}
