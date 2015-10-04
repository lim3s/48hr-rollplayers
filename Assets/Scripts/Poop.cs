using UnityEngine;
using System.Collections;

public class Poop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currVelocity = GetComponent<Rigidbody2D> ().velocity;
		float angle = (Mathf.Atan2 (currVelocity.y, currVelocity.x) * Mathf.Rad2Deg) + 90;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.rotation = Quaternion.Lerp (transform.rotation, rotation, 10 *Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.transform.tag == "Wall") {
			GameObject.Destroy(gameObject);
		}
	}
}
