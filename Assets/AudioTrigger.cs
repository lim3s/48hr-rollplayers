using UnityEngine;
using System.Collections;

public class AudioTrigger : Trigger {

	bool boom;

	public override void Activate (){
		boom = false;
		GetComponent<AudioSource> ().Play ();
	}
}
