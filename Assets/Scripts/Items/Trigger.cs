using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	[SerializeField]
	Collider2D coll;

	[SerializeField]
	string collideTag;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll != null) {
			if (coll.transform.tag == collideTag) {
				Activate();
			}
		}
	}

	public virtual void Activate() {
		// Do stuff
	}
}
