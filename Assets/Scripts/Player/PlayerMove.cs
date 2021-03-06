﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float maxPlayerSpeed = 10;
	public float curPlayerSpeed;
	public float buildToSpeedFactor = 0.2f;
	public bool facingRight = false;
	public PlayerHealth health;

	[Header("Jump Mechanics")]
	public int playerJumpPower = 100;
	public bool isGrounded;
	public LayerMask groundLayer;
	public LayerMask platformLayer;
	public float isGroundedBleed = 0;

	int extraJumps = 0;

	[Header("Sound Effects")]
	public AudioClip jumpSound;
	public AudioSource jumpAudioSource;
	public AudioSource flipAudioSource;

	float xMovement;
	Rigidbody2D rb;
	bool disableMove = false;

	GameManager gm;

	private void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();

		curPlayerSpeed = maxPlayerSpeed;

		jumpAudioSource.clip = jumpSound;

		GameObject go = GameObject.FindGameObjectWithTag("GM");
		gm = go.GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		PlayerMovement();
	}

	private void FixedUpdate()
	{
		if (disableMove)
			xMovement = 0f;
		// Physics
		rb.velocity = new Vector2(xMovement * curPlayerSpeed, rb.velocity.y);

		BuildUpToMaxSpeed();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.name == "Tilemap_ground")
		{
			isGrounded = true;
		}
		if (collision.gameObject.CompareTag("Moving Platform"))
		{
			isGrounded = true;
		}
	}

	public void DisableMove()
	{
		disableMove = true;
		rb.velocity = new Vector2(0f, rb.velocity.y);
		//rb.angularDrag = 0f;
		//rb.isKinematic = true;
	}

	public void EnableMove()
	{
		disableMove = false;
	}

	bool AllowPlayerJump()
	{
		// Something has diabled move, probably a dialog box
		// so do not allow jumps to process
		if (disableMove)
			return false;

		/*
		// If player is moving up or down
		if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
		{
			// Allow one extra jump using collision area that
			// is wider than player, for fun gameplay
			if (extraJumps != 0)
			{
				// Restrict jump col test to player width
				// to stop player from jump hovering on a vertical wall
				isGroundedBleed = -0.45f;
			}
			extraJumps++;

			// This restricts the extra Jumps but the tilemap is too buggy
			if (extraJumps > 1)
			{
				return false;
			}
			
		}
		else
		{
			extraJumps = 0;
		}
		*/
		extraJumps = 0;

		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 1.0f;
		float width = GetComponent<SpriteRenderer>().bounds.size.x;

		Vector2 leftPosition = position - (new Vector2(width / 2 + isGroundedBleed, 0));
		Vector2 rightPosition = position + (new Vector2(width / 2 + isGroundedBleed, 0));
		//isGroundedBleed = 0f;

		// DEBUG
		Debug.DrawRay(leftPosition, direction, Color.green, 5.0f);
		Debug.DrawRay(rightPosition, direction, Color.green, 5.0f);
		Debug.DrawRay(position, direction, Color.red, 5.0f);

		// Check col with DefaultRaycastLayers which is
		// all layers except for Ignore Raycast layer
		RaycastHit2D centerHit = Physics2D.Raycast(position, direction, distance, Physics.DefaultRaycastLayers);
		RaycastHit2D leftHit = Physics2D.Raycast(leftPosition, direction, distance, Physics.DefaultRaycastLayers);
		RaycastHit2D rightHit = Physics2D.Raycast(rightPosition, direction, distance, Physics.DefaultRaycastLayers);

		// If any colliders have a hit, there is ground under the player
		// so allow player to jump
		if (centerHit.collider != null || leftHit.collider != null || rightHit.collider != null)
		{
			return true;
		}

		return false;
	}

	void PlayerMovement()
	{
		if (health.HasDied() || disableMove || gm.IsPaused())
			return;

		// Controls
		xMovement = Input.GetAxis("Horizontal");
		bool jump = Input.GetButtonDown("Jump");

		if (jump || Input.GetKeyDown("w") || Input.GetKeyDown("k"))
		{
			Jump();
		}

		// Animations

		// Player direction
		if (xMovement < 0.0f && facingRight == false)
		{
			FlipPlayer();
		}
		else if (xMovement > 0.0f && facingRight == true)
		{
			FlipPlayer();
		}

	}

	void Jump()
	{
		if (AllowPlayerJump())
		{
			jumpAudioSource.Play();
			rb.AddForce(Vector2.up * playerJumpPower);
		}
	}

	void FlipPlayer(bool playFlipSound = false)
	{
		if (playFlipSound)
			flipAudioSource.Play();

		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;

		// Sapp speed
		curPlayerSpeed = maxPlayerSpeed / 2f;
	}

	void BuildUpToMaxSpeed()
	{
		if (curPlayerSpeed < maxPlayerSpeed)
		{
			// Build speed back up
			curPlayerSpeed += buildToSpeedFactor;
			Mathf.Clamp(curPlayerSpeed, 0, maxPlayerSpeed);
		}
	}

}
