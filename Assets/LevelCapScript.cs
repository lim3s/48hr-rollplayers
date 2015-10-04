using UnityEngine;
using System.Collections;

public class LevelCapScript : MonoBehaviour {

	void Update(){
		if (GetComponent<FlightController> ().superPowered) {
			Destroy(this.gameObject);
		}
	}
}
