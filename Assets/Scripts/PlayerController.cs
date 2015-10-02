using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float rot = Mathf.Atan2 (Input.GetAxis ("Vertical"), Input.GetAxis ("Horizontal")) * Mathf.Rad2Deg;
		print (rot);
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, rot));
	}
}
