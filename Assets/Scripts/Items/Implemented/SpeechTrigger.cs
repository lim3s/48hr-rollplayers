using UnityEngine;
using System.Collections;

public class SpeechTrigger : Trigger {
	[SerializeField]
	SpeechBubble speech;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate() {
		speech.Activate ();
	}
}
