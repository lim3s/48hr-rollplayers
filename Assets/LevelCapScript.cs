using UnityEngine;
using System.Collections;

public class LevelCapScript : MonoBehaviour {

	void Update(){
		if (FindObjectOfType<FlightController> ().superPowered) {
			Destroy(this.gameObject);
		}
	}
}
