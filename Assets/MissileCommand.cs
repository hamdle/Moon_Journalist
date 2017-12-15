using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCommand : MonoBehaviour {

	public float launchDistance = 5.0f;

	[SerializeField]
	float initialAngle;

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
			var rigid = rb;

			Vector3 p = other.position;

			float gravity = Physics.gravity.magnitude;
			// Selected angle in radians
			float angle = initialAngle * Mathf.Deg2Rad;

			// Positions of this object and the target on the same plane
			Vector3 planarTarget = new Vector3(p.x, 0, p.z);
			Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);

			// Planar distance between objects
			float distance = Vector3.Distance(planarTarget, planarPostion);
			// Distance along the y axis between objects
			float yOffset = transform.position.y - p.y;

			float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

			Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

			// Rotate our velocity to match the direction between the two objects
			float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion);
			Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

			// Fire!
			rigid.velocity = finalVelocity;

			// Alternative way:
			// rigid.AddForce(finalVelocity * rigid.mass, ForceMode.Impulse);
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
