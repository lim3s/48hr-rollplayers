using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	float deadZone = 0.2f;

	float horizontal;
	float vertical;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Mathf.Abs (Input.GetAxis ("Horizontal")) > deadZone) {
			horizontal = Input.GetAxis ("Horizontal");
		} else {
			//horizontal = 0;
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical")) > deadZone) {
			vertical = Input.GetAxis ("Vertical");
		} else {
			//vertical = 0;
		}
		float rot = Mathf.Atan2 (vertical, horizontal) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.forward * rot), 5 * Time.deltaTime);
	}
}
