using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideDialog : MonoBehaviour {

	public void ShowHideToggle(GameObject c)
	{
		//GameObject c = GameObject.FindGameObjectWithTag("Dialog Box");
		c.SetActive(!c.activeInHierarchy);
	}
}
