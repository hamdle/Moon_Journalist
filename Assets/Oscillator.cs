using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

	[SerializeField] Vector3 movementVector = new Vector3(0, 0, 0);
	[SerializeField] float timePeriod = 2f;

	float movementFactor; // 0 for not moved, 1 for fully moved
	Vector3 startingPosition;

	bool moving = false;

	// Use this for initialization
	void Start () {
		startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// Protect against period of zero
		if (timePeriod <= Mathf.Epsilon)
			return;

		float cycles = Time.time / timePeriod; // grows continually from 0

		const float tau = Mathf.PI * 2f;
		float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

		movementFactor = rawSinWave / 2f + 0.5f;
		Vector3 offset = movementFactor * movementVector;
		transform.position = startingPosition + offset;

	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			moving = true;
			collision.collider.transform.SetParent(transform);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Player")
		{
			moving = false; ;
			collision.collider.transform.SetParent(null);
		}
	}
}
