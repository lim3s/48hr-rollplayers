using UnityEngine;
using System.Collections;

public class ObservitoryDoor : MonoBehaviour {

	public bool isOpen = false;
	float timer = 0.0f;
	public float timeToOpen = 5.0f;
	float degreesPerFrame;

	// Use this for initialization
	void Start () {
		degreesPerFrame = 90.0f / (timeToOpen * 50);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isOpen) {
			if (timer < timeToOpen) {
				timer += Time.fixedDeltaTime;
				transform.RotateAround (transform.parent.position, Vector3.forward, degreesPerFrame);
			}
		} else {
			if (timer > 0) {
				timer -= Time.fixedDeltaTime;
				transform.RotateAround (transform.parent.position, Vector3.forward, -degreesPerFrame);
			}
		}
	}


}
