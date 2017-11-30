using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadTaker : MonoBehaviour {

	public Vector3 offset;
	public Rigidbody2D rb;
	public Vector2 thrust;
	public float torque;

	GameObject player;
	PlayerMove playerHealth;
	bool prevPlayerFacingRight;
	[SerializeField] bool attachToPlayer = true;
	BoxCollider2D boxCollider;
	bool applyForces = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerMove>();
		prevPlayerFacingRight = playerHealth.facingRight;

		rb = GetComponent<Rigidbody2D>();
		boxCollider = GetComponent<BoxCollider2D>();
		boxCollider.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (attachToPlayer)
			AttachToPlayer();

		//ProcessControls();
	}

	private void FixedUpdate()
	{
		if (applyForces)
		{
			rb.AddForce(thrust, ForceMode2D.Impulse);
			rb.AddTorque(torque, ForceMode2D.Impulse);
			applyForces = false;
		}
	}

	private void ProcessControls()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			ThrowLeadTaker();
		}
	}

	private void ThrowLeadTaker()
	{
		attachToPlayer = false;

		boxCollider.enabled = true;

		applyForces = true;
		
	}

	private void AttachToPlayer()
	{
		bool currFacingRight = playerHealth.facingRight;
		if (prevPlayerFacingRight != currFacingRight)
		{
			FlipLeadTaker();
		}

		// Attach lead taker to player's back
		this.transform.position = player.transform.position + offset;

		prevPlayerFacingRight = currFacingRight;
	}

	private void FlipLeadTaker()
	{
		offset = new Vector3(-offset.x, offset.y, offset.z);
	}
}
