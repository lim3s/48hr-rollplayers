using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	float deadZone = 0.2f;
	[SerializeField]
	FlightController flight;

	float horizontal;
	float vertical;

	bool flag = false;
	bool flag2 = true;
	float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > deadZone && !flight.wingsIn && !flight.standing) {
			horizontal = Input.GetAxis ("Horizontal");
		} else {
			horizontal = GetComponent<Rigidbody2D>().velocity.normalized.x;
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical")) > deadZone && !flight.wingsIn && !flight.standing) {
			vertical = Input.GetAxis ("Vertical");
		} else {
			vertical = GetComponent<Rigidbody2D>().velocity.normalized.y;
		}
		if (flight.standing) {
			horizontal = 1;
			vertical = 0; 
			float rot = Mathf.Atan2 (vertical, horizontal) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.forward * rot), 1 * Time.deltaTime);
		} else if (flight.wingsIn || flight.stunned) {
			horizontal = 0;
			vertical = -1;
			float rot = Mathf.Atan2 (vertical, horizontal) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.forward * rot), 1 * Time.deltaTime);
		} else {
			float rot = Mathf.Atan2 (vertical, horizontal) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.forward * rot), 5 * Time.deltaTime);
		}



		if (flight.superPowered) {
			if (Input.GetAxis ("Flap") > 0.8){
				flight.Fart (timer);
			}
		} else {

			if (Input.GetAxis ("Flap") > 0.8 && !flag) {
				timer = 0;
				flag = true;
			}
			if (Input.GetAxis ("Flap") < 0.2 && flag) {
				flight.Flap (timer);
				flag = false;
			}
		}

		if (Input.GetAxis ("WingsIn") > 0.8 && flag2) {
			flight.Wings(true);
			flag2 = false;
		}
		if (Input.GetAxis ("WingsIn") < 0.2 && !flag2) {
			flight.Wings(false);
			flag2 = true;
		}
//		if (Input.GetButtonDown ("Reset")) {
//			flight.ResetPos();
//		}
		if (flag) {
			timer += Time.deltaTime * 80;
		}
	}
}
