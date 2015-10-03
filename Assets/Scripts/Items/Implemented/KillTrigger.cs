using UnityEngine;
using System.Collections;

public class KillTrigger : Trigger {

	[SerializeField]

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Activate() {
		KillPlayer.instance.die ();
	}
}
