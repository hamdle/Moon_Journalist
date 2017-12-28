using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour {

	public float horSpeed;
	public float vertSpeed;
	public float amplitude;

	public Vector3 tempPosition;

	// Use this for initialization
	void Start () {
		tempPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tempPosition.x += horSpeed;
		tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * vertSpeed) * amplitude;
		transform.position = tempPosition;
	}
}
