using UnityEngine;
using System.Collections;

public class PowerBean : Consumable {

	void Start () {
		setup ();
	}

	public override void eat(){
		FindObjectOfType<FlightController> ().superPowered = true;
		Destroy (this.gameObject);
	}
}
