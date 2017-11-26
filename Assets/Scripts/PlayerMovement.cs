using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb;

	public float horizontalForce = 50f;
	public float jumpForce = 50f;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey("d"))
		{
			rb.AddForce(new Vector2(horizontalForce * Time.deltaTime, 0), ForceMode2D.Impulse);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(new Vector2(-horizontalForce * Time.deltaTime, 0), ForceMode2D.Impulse);
		}
		if (Input.GetKeyDown("w"))
		{
			rb.AddForce(new Vector2(0, jumpForce * Time.deltaTime), ForceMode2D.Impulse);
		}
	}
}
