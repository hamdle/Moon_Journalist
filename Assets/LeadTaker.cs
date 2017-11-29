using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadTaker : MonoBehaviour {

	public Vector3 offset;
	
	GameObject player;
	PlayerMove playerHealth;
	bool prevPlayerFacingRight;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerMove>();
		prevPlayerFacingRight = playerHealth.facingRight;
	}
	
	// Update is called once per frame
	void Update () {
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
