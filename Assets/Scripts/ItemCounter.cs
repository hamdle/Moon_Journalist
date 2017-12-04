using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject coinHolder = GameObject.FindGameObjectWithTag("Player");
		coinHolder.GetComponent<ItemCollector>().RegisterCoin(this.gameObject.tag);
	}
	
}
