﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour {

	[SerializeField] private int coinsInThisLevel = 0;
	[SerializeField] private int leadsInThisLevel = 0;

	[SerializeField] int coinsCollected;
	[SerializeField] int leadsCollected;

	[SerializeField] PlayerHealth playerHealth;

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
			coinsCollected++;
			Destroy(collision.gameObject);
		}
		else if (collision.CompareTag("Lead Coin"))
		{
			leadsCollected++;
			playerHealth.LeadCoinCollected();
			Destroy(collision.gameObject);
		}
	}

	public void RegisterCoin(bool isLead)
	{
		if (!isLead)
			coinsInThisLevel++;
		else
			leadsInThisLevel++;
	}
}