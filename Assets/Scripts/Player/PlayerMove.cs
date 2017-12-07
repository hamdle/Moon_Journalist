using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public int playerSpeed = 10;
	public bool facingRight = false;

	[Header("Jump Mechanics")]
	public int playerJumpPower = 100;
	public bool isGrounded;
	public LayerMask groundLayer;
	public LayerMask platformLayer;
	public float isGroundedBleed = 0;

	[Header("Sound Effects")]
	public AudioSource jumpAudioSource;

	float xMovement;
	Rigidbody2D rb;

	private void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		PlayerMovement();
	}

	bool IsGrounded()
	{
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 1.0f;
		float width = GetComponent<SpriteRenderer>().bounds.size.x;

		Vector2 leftPosition = position - (new Vector2(width / 2 + isGroundedBleed, 0));
		Vector2 rightPosition = position + (new Vector2(width / 2 + isGroundedBleed, 0));

		// DEBUG
		//Debug.DrawRay(leftPosition, direction, Color.green, 5.0f);
		//Debug.DrawRay(rightPosition, direction, Color.green, 5.0f);
		//Debug.DrawRay(position, direction, Color.red, 5.0f);

		// Check col with ground layer
		RaycastHit2D centerHit = Physics2D.Raycast(position, direction, distance, groundLayer);
		RaycastHit2D leftHit = Physics2D.Raycast(leftPosition, direction, distance, groundLayer);
		RaycastHit2D rightHit = Physics2D.Raycast(rightPosition, direction, distance, groundLayer);

		if (centerHit.collider != null || leftHit.collider != null || rightHit.collider != null)
		{
			return true;
		}

		// Check col with platform layer
		centerHit = Physics2D.Raycast(position, direction, distance, platformLayer);
		leftHit = Physics2D.Raycast(leftPosition, direction, distance, platformLayer);
		rightHit = Physics2D.Raycast(rightPosition, direction, distance, platformLayer);

		if (centerHit.collider != null || leftHit.collider != null || rightHit.collider != null)
		{
			return true;
		}

		return false;
	}

	void PlayerMovement()
	{
		// Controls
		xMovement = Input.GetAxis("Horizontal");
		bool jump = Input.GetButtonDown("Jump");

		if (jump || Input.GetKeyDown("w"))
		{
			jumpAudioSource.Play();
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

	private void FixedUpdate()
	{
		// Physics
		rb.velocity = new Vector2(xMovement * playerSpeed, rb.velocity.y);
	}

	void Jump()
	{
		if (IsGrounded())
		{
			rb.AddForce(Vector2.up * playerJumpPower);
		}
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
		if (collision.gameObject.CompareTag("Moving Platform"))
		{
			isGrounded = true;
		}
	}
}
