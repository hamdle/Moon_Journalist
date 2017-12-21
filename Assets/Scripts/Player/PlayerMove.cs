using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float maxPlayerSpeed = 10;
	public float curPlayerSpeed;
	public bool facingRight = false;
	public PlayerHealth health;

	[Header("Jump Mechanics")]
	public int playerJumpPower = 100;
	public bool isGrounded;
	public LayerMask groundLayer;
	public LayerMask platformLayer;
	public float isGroundedBleed = 0;
	public int maxExtraJumps = 0;
	public int curExtraJumps;

	[Header("Sound Effects")]
	public AudioClip jumpSound;
	public AudioSource jumpAudioSource;

	float xMovement;
	Rigidbody2D rb;

	private void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();

		curPlayerSpeed = maxPlayerSpeed;
		curExtraJumps = maxExtraJumps;

		jumpAudioSource.clip = jumpSound;
	}

	// Update is called once per frame
	void Update () {
		PlayerMovement();
	}

	bool IsGrounded()
	{
		if (rb.velocity.y == 0.0f)
		{
			isGroundedBleed = 0f;
			curExtraJumps = maxExtraJumps;
		}
		else
		{
			if (curExtraJumps <= 0)
			{
				isGroundedBleed = -0.45f;
			}
			curExtraJumps--;
		}

		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 1.0f;
		float width = GetComponent<SpriteRenderer>().bounds.size.x;

		Vector2 leftPosition = position - (new Vector2(width / 2 + isGroundedBleed, 0));
		Vector2 rightPosition = position + (new Vector2(width / 2 + isGroundedBleed, 0));

		// DEBUG
		Debug.DrawRay(leftPosition, direction, Color.green, 5.0f);
		Debug.DrawRay(rightPosition, direction, Color.green, 5.0f);
		Debug.DrawRay(position, direction, Color.red, 5.0f);

		// Check col with DefaultRaycastLayers which is
		// all layers except for Ignore Raycast layer
		RaycastHit2D centerHit = Physics2D.Raycast(position, direction, distance, Physics.DefaultRaycastLayers);
		RaycastHit2D leftHit = Physics2D.Raycast(leftPosition, direction, distance, Physics.DefaultRaycastLayers);
		RaycastHit2D rightHit = Physics2D.Raycast(rightPosition, direction, distance, Physics.DefaultRaycastLayers);

		if (centerHit.collider != null || leftHit.collider != null || rightHit.collider != null)
		{
			return true;
		}

		return false;
	}

	void PlayerMovement()
	{
		if (health.HasDied())
			return;

		// Controls
		xMovement = Input.GetAxis("Horizontal");
		bool jump = Input.GetButtonDown("Jump");

		if (jump || Input.GetKeyDown("w"))
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

	private void FixedUpdate()
	{
		// Physics
		rb.velocity = new Vector2(xMovement * curPlayerSpeed, rb.velocity.y);

		BuildUpToMaxSpeed();
	}

	void Jump()
	{
		if (IsGrounded())
		{
			jumpAudioSource.Play();
			rb.AddForce(Vector2.up * playerJumpPower);
		}
	}

	void FlipPlayer()
	{
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
			curPlayerSpeed += 0.1f;
			Mathf.Clamp(curPlayerSpeed, 0, maxPlayerSpeed);
		}
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
