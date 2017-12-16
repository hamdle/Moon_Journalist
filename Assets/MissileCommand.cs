using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCommand : MonoBehaviour {

	public float launchTriggerDistance = 5.0f;

	[SerializeField] Vector2 fireForce;

	bool inRange = false;
	bool fire = false;
	bool firing = false;
	Transform other;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		other = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange && !firing)
		{
			CheckTargetDistance();
		}
	}

	private void FixedUpdate()
	{
		if (fire)
		{
			firing = true;

			rb.AddForce(fireForce);

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
			if (dist < launchTriggerDistance)
			{
				fire = true;
				Debug.Log("HIT");
			}
		}
	}
}
