using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollectorDisplay : MonoBehaviour {

	public Text coinText;
	//public Text hearts;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateCoins(int coins)
	{
		coinText.text = coins.ToString();
	}
}
