using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog {

	public string name;
	// The senetences we will load into the queue
	[TextArea(3, 10)]
	public string[] sentences;
}
