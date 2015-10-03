using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	FlightController flight;
	Camera cam;

	float speed = 50;
	float distance = 10;
	float speedThreshold = 100;

	float minZoom = 20;
	float maxZoom = 40;

	// Use this for initialization
	void Start () {
		flight = player.GetComponent<FlightController> ();
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float newSize = minZoom + ((flight.getCurrSpeed () / speedThreshold) * (maxZoom - minZoom));
		if (newSize > maxZoom)
			newSize = maxZoom;
		else if (newSize < minZoom)
			newSize = minZoom;
		cam.orthographicSize = newSize;

		Vector3 newpos = new Vector3 (player.position.x, player.position.y, -10);
		transform.position = Vector3.Lerp (transform.position, newpos, Time.fixedDeltaTime * speed);
	}
}
