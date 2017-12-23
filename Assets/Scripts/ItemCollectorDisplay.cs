using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollectorDisplay : MonoBehaviour {

	public ItemCollector itemCollector;
	public PlayerHealth playerHealth;
	public Text coinText;
	public Text healthText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		UpdateCoinsDisplay();
		UpdateHealthDisplay();
	}

	private void UpdateCoinsDisplay()
	{
		coinText.text = itemCollector.GetCoins().ToString();
	}

	private void UpdateHealthDisplay()
	{
		healthText.text = playerHealth.GetHealth().ToString();
	}
}
