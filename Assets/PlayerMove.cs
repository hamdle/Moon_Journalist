using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public int playerSpeed = 10;
	public bool facingRight = false;
	public int playerJumpPower = 1250;
	public float moveX;
	public bool isGrounded;
	
	// Update is called once per frame
	void Update () {
		PlayerMovement();
	}

	void PlayerMovement()
	{
		// Controls
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump") || Input.GetKeyDown("w"))
		{
			if (isGrounded)
			{
				Jump();
			}
		}

		// Animations

		// Player direction
		if (moveX < 0.0f && facingRight == false)
		{
			FlipPlayer();
		}
		else if (moveX > 0.0f && facingRight == true)
		{
			FlipPlayer();
		}

		// Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void Jump()
	{
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
		isGrounded = false;
	}

	void FlipPlayer()
	{
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.name == "Tilemap_ground")
		{
			isGrounded = true;
		}
	}
}
