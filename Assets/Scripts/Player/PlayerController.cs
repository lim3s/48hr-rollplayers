﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	float deadZone = 0.2f;
	[SerializeField]
	FlightController flight;

	float horizontal;
	float vertical;

	bool flag = true;
	bool flag2 = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > deadZone && !flight.wingsIn) {
			horizontal = Input.GetAxis ("Horizontal");
		} else {
			horizontal = GetComponent<Rigidbody2D>().velocity.normalized.x;
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical")) > deadZone && !flight.wingsIn) {
			vertical = Input.GetAxis ("Vertical");
		} else {
			vertical = GetComponent<Rigidbody2D>().velocity.normalized.y;
		}
		float rot = Mathf.Atan2 (vertical, horizontal) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.forward * rot), 5 * Time.deltaTime);

		if (Input.GetAxis ("Flap") > 0.8 && flag) {
			flight.Flap();
			flag = false;
		}
		if (Input.GetAxis ("Flap") < 0.2 && !flag) {
			flag = true;
		}

		if (Input.GetAxis ("WingsIn") > 0.8 && flag2) {
			flight.Wings(true);
			flag2 = false;
		}
		if (Input.GetAxis ("WingsIn") < 0.2 && !flag2) {
			flight.Wings(false);
			flag2 = true;
		}
		if (Input.GetButtonDown ("Reset")) {
			flight.ResetPos();
		}
	}
}