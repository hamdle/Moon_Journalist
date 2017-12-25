using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgObjFloat : MonoBehaviour {

	public Vector2 objFloat;
	public bool objFloatOn;

	public float rotateFloat;
	public bool rotateFloatOn;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (objFloatOn)
		{
			rb.velocity = objFloat * Time.deltaTime;
		}
		if (rotateFloatOn)
		{
			rb.transform.Rotate(0, 0, rotateFloat * Time.deltaTime);
		}
	}
}
