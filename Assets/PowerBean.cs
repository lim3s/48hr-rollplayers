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
<<<<<<< Updated upstream
		SoundManager.myManager.myMusic.enterSpace ();
=======
		GameObject.Destroy (prevDialogue.gameObject);
		nextDialogue.Activate ();
>>>>>>> Stashed changes
		Destroy (this.gameObject);
	}
}
