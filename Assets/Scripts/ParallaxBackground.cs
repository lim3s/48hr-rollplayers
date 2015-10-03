using UnityEngine;
using System.Collections;

public class ParallaxBackground : MonoBehaviour {
	[SerializeField]
	Camera cam;
	[SerializeField]
	float parallaxRatio = 0.5f;
	Vector2 lastCamPos;
	// Use this for initialization
	void Start () {
		lastCamPos = cam.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 curr = cam.transform.position;
		Vector2 diff = lastCamPos - curr;
		print (diff);
		transform.position = new Vector2 (transform.position.x + diff.x * parallaxRatio, transform.position.y);
		lastCamPos = curr;
	}
}
