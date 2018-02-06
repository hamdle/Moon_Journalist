using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OKSoundCom : MonoBehaviour {

	// GM GameManager
	public void SendSoundToGM()
	{
		GameObject gmGameObject = GameObject.FindGameObjectWithTag("GM");
		GameManager gmGameManager = gmGameObject.GetComponent<GameManager>();
		
		gmGameManager.PlayOKSound();
	}
}
