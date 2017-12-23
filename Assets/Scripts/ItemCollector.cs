using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour {

	[SerializeField] private int coinsInThisLevel = 0;
	[SerializeField] private int healthInThisLevel = 0;

	[SerializeField] int coinsCollected;
	[SerializeField] int healthCollected;

	[SerializeField] PlayerHealth playerHealth;

	[SerializeField] AudioClip coinSound;
	public AudioSource coinAudioSource;

	[SerializeField] AudioClip healthSound;
	public AudioSource healthAudioSource;

	public ItemCollectorDisplay itemCollectorDisplay;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Coin"))
		{
			coinAudioSource.clip = coinSound;
			coinAudioSource.Play();
			coinsCollected++;
			itemCollectorDisplay.UpdateCoins(coinsCollected);
			Destroy(collision.gameObject);
		}
		else if (collision.CompareTag("Health"))
		{
			healthAudioSource.clip = healthSound;
			healthAudioSource.Play();
			healthCollected++;
			playerHealth.HealthCollected();
			Destroy(collision.gameObject);
		}
	}

	public void RegisterCoin(string itemTag)
	{
		if (itemTag == "Coin")
			coinsInThisLevel++;
		else if (itemTag == "Health")
			healthInThisLevel++;
	}
}
