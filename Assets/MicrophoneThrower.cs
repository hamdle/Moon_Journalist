using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneThrower : MonoBehaviour {

	public Transform prefab;
	public Vector2 throwForce;
	public float torque;
	public Vector3 throwOffset;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(transform.position);
		
		if (Input.GetButtonDown("Fire1"))
		{
			Vector2 newThrowForce = new Vector2(throwForce.x * transform.localScale.x, throwForce.y);
			Vector3 newThrowOffset = new Vector3(throwOffset.x * transform.localScale.x, throwOffset.y, 0);

			Transform microphone = Instantiate(prefab, transform.position + newThrowOffset, Quaternion.identity);
			microphone.GetComponent<Rigidbody2D>().AddForce(newThrowForce, ForceMode2D.Impulse);
			microphone.GetComponent<Rigidbody2D>().AddTorque(torque, ForceMode2D.Impulse);
		}
	}
}
