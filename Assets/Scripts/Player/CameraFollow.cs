using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform player;
	FlightController flight;
	Camera cam;
	[SerializeField]
	BoxCollider2D bounds;
	[SerializeField]
	float speed = 0.5f;
	[SerializeField]
	float lookAhead = 5f;
	float speedThreshold = 150;

	public float minZoom = 20;
	float maxZoom = 60;

	float halfHeight;
	float halfWidth;

	float minX;
	float minY;
	float maxX;
	float maxY;

	public bool stall = true;

	// Use this for initialization
	void Start () {
		flight = player.GetComponent<FlightController> ();
		cam = GetComponent<Camera> ();

		halfHeight = cam.orthographicSize;
		halfWidth = halfHeight * cam.aspect;
		minX = bounds.bounds.min.x + halfWidth;
		minY = bounds.bounds.min.y + halfHeight;
		maxX = bounds.bounds.max.x - halfWidth;
		maxY = bounds.bounds.max.y - halfHeight;

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
		halfHeight = cam.orthographicSize;
		halfWidth = halfHeight * cam.aspect;
		minX = bounds.bounds.min.x + halfWidth;
		minY = bounds.bounds.min.y + halfHeight;
		maxX = bounds.bounds.max.x - halfWidth;
		maxY = bounds.bounds.max.y - halfHeight;

		float lerp = speed * player.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude;
		float horizontalShift = (halfHeight / (-player.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude - 1));

		Vector3 newpos = new Vector3 (player.position.x, player.position.y, -10);
		transform.position = Vector3.Lerp (transform.position, newpos, lerp);
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), -10);
	}
}
