using UnityEngine;
using System.Collections;

public class PowerBean : Consumable {
	[SerializeField]
	SpeechBubble prevDialogue;
	[SerializeField]
	SpeechBubble nextDialogue;

	void Start () {
		setup ();
	}

	public override void eat(){
		FindObjectOfType<FlightController> ().superPowered = true;
		SoundManager.myManager.myMusic.enterSpace ();
		GameObject.Destroy (prevDialogue.gameObject);
		nextDialogue.Activate ();
		Destroy (this.gameObject);
	}
}
