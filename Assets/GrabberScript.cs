using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberScript : MonoBehaviour {

	public float distance = 2f;
	public Transform holdPoint;

	[SerializeField] bool grabbed;
	RaycastHit2D hit;
	Collider2D grabberCollider;

	// Use this for initialization
	void Start () {
		grabberCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Vector3 lineStart = new Vector3(transform.position.x + grabberCollider.bounds.size.x / 2 + 0.01f, transform.position.y, transform.position.z);

			hit = Physics2D.Raycast(lineStart, Vector2.right * transform.localScale.x, distance);

			Debug.Log(hit.collider.name);

			

			if (!grabbed)
			{
				//Physics2D.raycastsStartInColliders = false;
				

				if (hit.collider != null)
				{
					grabbed = true;
				}
			}
			else
			{
				// throw
			}
		}

		if (grabbed)
		{
			hit.collider.gameObject.transform.position = holdPoint.position;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Vector3 lineStart = new Vector3(transform.position.x + 0.5f + 0.01f, transform.position.y, transform.position.z);
		Gizmos.DrawLine(lineStart, transform.position + Vector3.right * transform.localScale.x * distance);
	}
}
