using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneThrower : MonoBehaviour {

	public Transform prefab;
	public Vector2 throwForce;
	public float torque;
	public float torqueDeviation;
	public Vector3 throwOffset;

	public AudioClip throwSound;
	public AudioSource throwAudioSource;

	public GameObject dialogBox;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();

		throwAudioSource.clip = throwSound;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1"))
		{
			// Leave if we are waiting on the user to hit the dialog box
			if (dialogBox.gameObject.activeInHierarchy)
				return;

			throwAudioSource.Play();

			// Throw force
			Vector2 newThrowForce = new Vector2(throwForce.x * transform.localScale.x, throwForce.y);
			Vector3 newThrowOffset = new Vector3(throwOffset.x * transform.localScale.x, throwOffset.y, 0);

			float torqueRandDeviation = 0f;

			// Calc random torque deviation
			if (torqueDeviation != 0 )
				torqueRandDeviation = UnityEngine.Random.Range(0, torqueDeviation);
			
			// todo make rotate negative if throwing left
			
			Transform microphone = Instantiate(prefab, transform.position + newThrowOffset, Quaternion.identity);
			microphone.GetComponent<Rigidbody2D>().AddForce(newThrowForce, ForceMode2D.Impulse);
			microphone.GetComponent<Rigidbody2D>().AddTorque(torque + torqueRandDeviation, ForceMode2D.Impulse);
			microphone.GetComponent<Rigidbody2D>().velocity = new Vector2(microphone.GetComponent<Rigidbody2D>().velocity.x + rb.velocity.x, 0);
		}
	}
}
