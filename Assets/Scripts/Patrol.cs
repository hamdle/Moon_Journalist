using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

	// Tilemap to collide with
	public LayerMask groundLayer;
	// Hit detection distance, 0.5f is width of sprite
	public float distance = 0.6f;

	// Used to move this object
	float xMovement;
	[SerializeField] float speed;

	// Used for raycast hit detection
	Vector2 position;
	Vector2 direction;
	bool movingLeft;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		xMovement = 1.0f;
		position = transform.position;

		MoveLeft();
	}
	
	// Update is called once per frame
	void Update () {
		position = transform.position;
		RaycastHit2D centerHit = Physics2D.Raycast(position, direction, distance, groundLayer);
		if (centerHit.collider != null)
		{
			// DEBUG
			// Debug.DrawRay(position, direction, Color.green, 1.0f);

			TurnAround();
		}
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);
	}

	private void TurnAround()
	{
		if (movingLeft)
		{
			MoveRight();
		}
		else
		{
			MoveLeft();
		}
	}

	private void MoveLeft()
	{
		// Set speed negative
		speed = -1 * Mathf.Abs(speed);
		direction = Vector2.left;
		movingLeft = true;
	}

	private void MoveRight()
	{
		// Set speed negative
		speed = Mathf.Abs(speed);
		direction = Vector2.right;
		movingLeft = false;
	}
}
