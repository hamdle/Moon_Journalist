using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCommand : MonoBehaviour {

	public float launchDistance = 5.0f;

	bool inRange = false;
	bool fire = false;
	Transform other;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		other = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange)
		{
			CheckTargetDistance();
		}
	}

	private void FixedUpdate()
	{
		if (fire)
		{
			rb.AddForce(new Vector2(0, 10f));
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

	void CheckTargetDistance()
	{
		if (other)
		{
			float dist = Vector3.Distance(other.position, transform.position);
			if (dist < launchDistance)
			{
				fire = true;
				Debug.Log("HIT");
			}
		}
	}
}
