using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

	public float killTimer;
	[Range(0,1)] public float flashTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Projectile"))
		{
			// Disable all further collisions
			//collision.collider.enabled = false;
			// Flash sprite to indicate hit
			StartCoroutine(Flash(this.gameObject, flashTimer));
			// Destroy object after killTimer seconds
			Invoke("Kill", killTimer);
		}
	}

	private IEnumerator Flash(GameObject gameObject, float flashTimer)
	{
		SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

		//for (int i = 0; i < 10; i++)
		//{
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds(flashTimer);
			spriteRenderer.enabled = true;
			yield return new WaitForSeconds(flashTimer);
		//}
	}

	private void Kill()
	{
		Destroy(this.gameObject);
	}
}
