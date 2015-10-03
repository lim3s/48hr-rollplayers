using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	FlightController flight;
	Camera cam;

	[SerializeField]
	float speed = 0.1f;
	float distance = 10;
	float speedThreshold = 150;

	float minZoom = 20;
	float maxZoom = 60;

	public bool stall = true;

	// Use this for initialization
	void Start () {
		flight = player.GetComponent<FlightController> ();
		cam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (stall) {
			return;
		}
		float newSize = minZoom + ((flight.getCurrSpeed () / speedThreshold) * (maxZoom - minZoom));
		if (newSize > maxZoom)
			newSize = maxZoom;
		else if (newSize < minZoom)
			newSize = minZoom;
		cam.orthographicSize = Mathf.Lerp (cam.orthographicSize, newSize, 0.05f);

		Vector3 newpos = new Vector3 (player.position.x, player.position.y, -10);
		transform.position = Vector3.Lerp (transform.position, newpos, speed);
	}
}
