using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	CloudController main;
	float speed = 1f;
	float velocity = 5;

	// Use this for initialization
	void Start () {
		main = this.GetComponentInParent<CloudController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 newPos = new Vector2 (transform.position.x + velocity, transform.position.y);
		transform.position = Vector2.Lerp (transform.position, newPos, Time.fixedDeltaTime * speed);

		if (transform.position.x >= main.finish.position.x) {
			transform.position = new Vector2 (main.start.position.x, transform.position.y);
		}
	}
}
