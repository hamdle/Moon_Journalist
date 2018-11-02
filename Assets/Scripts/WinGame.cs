using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour {

	public void ResetMusicAfterWinGame()
	{
		GameObject go = GameObject.FindGameObjectWithTag("GM");
		GameManager gm = go.GetComponent<GameManager>();
		gm.PlayWinGameMusic();
	}	
}
