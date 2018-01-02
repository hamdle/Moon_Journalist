using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogContinueAnimation : MonoBehaviour {

	public GameObject gameUIObject;
	public float oscillationDistance;
	public float speed;

	private float min;
	private float max;
	private bool up = true;

	// Use this for initialization
	void Start () {
		// Check for divide by zero
		if (oscillationDistance <= float.Epsilon)
			return;

		min = gameUIObject.transform.localPosition.y - (oscillationDistance / 2);
		max = gameUIObject.transform.localPosition.y + (oscillationDistance / 2);

		Debug.Log(gameUIObject.transform.localPosition.y);
		Debug.Log(min);
		Debug.Log(max);
	}
	
	// Update is called once per frame
	void Update () {

		float curY = gameUIObject.transform.localPosition.y;

		if (up)
		{
			if (curY > max)
			{
				up = false;
			}
		}
		else
		{
			if (curY < min)
			{
				up = true;
			}
		}
		float newY = curY;

		if (up)
		{
			newY = curY + speed * Time.deltaTime;
		}
		else
		{
			newY = curY - speed * Time.deltaTime;
		}

		gameUIObject.transform.localPosition = new Vector3(gameUIObject.transform.localPosition.x, newY, gameUIObject.transform.localPosition.z) ;
	}
}
