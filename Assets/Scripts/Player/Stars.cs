using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {

	FlightController flight;
	SpriteRenderer myRenderer;

	// Use this for initialization
	void Start () {
		flight = GetComponentInParent<FlightController> ();
		myRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (flight.stunned) {
			myRenderer.enabled = true;
		} else {
			myRenderer.enabled = false;
		}
	}
}
