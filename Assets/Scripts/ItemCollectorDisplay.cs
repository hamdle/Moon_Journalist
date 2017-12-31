using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollectorDisplay : MonoBehaviour {

	public ItemCollector itemCollector;
	public PlayerHealth playerHealth;
	public Text coinText;
	public GameObject heart;

	int prevHealth;
	Stack heartStack;

	// Use this for initialization
	void Start () {
		//heart = GameObject.FindGameObjectWithTag("Health Icon");
		heartStack = new Stack();
		heartStack.Push(heart);

		prevHealth = playerHealth.GetHealth();
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
		int curHealth = playerHealth.GetHealth();

		if (prevHealth != curHealth)
		{
			if (prevHealth < curHealth)
			{
				// Gained health
				GameObject clone = Instantiate(heart, heart.transform);
				clone.transform.position = new Vector3(heart.transform.position.x + 36, heart.transform.position.y, heart.transform.position.z);
				heartStack.Push(clone);
			}
			else if (prevHealth > curHealth)
			{
				// Lost health
				GameObject lastHeartCloned = heartStack.Pop() as GameObject;
				lastHeartCloned.SetActive(false);
			}
		}

		prevHealth = curHealth;
	}

}
