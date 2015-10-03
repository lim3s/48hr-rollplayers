using UnityEngine;
using System.Collections;

public class TrainScript : MonoBehaviour {

	[SerializeField]
	float speed = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.right * speed * Time.fixedDeltaTime;
		if (transform.position.x > 50) {
			Destroy(this.gameObject);
		}
	}
}
