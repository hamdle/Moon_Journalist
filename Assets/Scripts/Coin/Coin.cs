using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	int value = 1;

	public void CoinCollected()
	{
		Destroy(gameObject);
	}
}
