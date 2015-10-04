using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	FlightController flight;
	SpriteRenderer myRenderer;

	// Use this for initialization
	void Start () {
		flight = GetComponentInParent<FlightController> ();
		myRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (flight.superPowered && Input.GetAxis ("Flap") > 0.8) {
			myRenderer.enabled = true;
		} else {
			myRenderer.enabled = false;
		}
	}
}
