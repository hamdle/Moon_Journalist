using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour {

	public bool isLead = false;

	// Use this for initialization
	void Start () {
		GameObject coinHolder = GameObject.FindGameObjectWithTag("Player");
		coinHolder.GetComponent<CoinCollector>().RegisterCoin(isLead);
	}
	
}
