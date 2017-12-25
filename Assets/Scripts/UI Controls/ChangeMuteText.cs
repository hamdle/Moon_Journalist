using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMuteText : MonoBehaviour {

	public Text muteText;

	private bool isMute = false;

	public void ToggleMuteText()
	{
		if (isMute)
		{
			muteText.text = "Mute";
			isMute = false;
		}
		else
		{
			muteText.text = "Unmute";
			isMute = true;
		}
	}
}
