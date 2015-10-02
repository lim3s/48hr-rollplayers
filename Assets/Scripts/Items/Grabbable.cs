using UnityEngine;
using System.Collections;

public class Grabbable : MonoBehaviour {
	Collider2D myCollider;

	// Use this for initialization
	void Start () {
		myCollider = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void grabObject(){
		myCollider.enabled = false;
	}

	void dropObject(){
		myCollider.enabled = true;
	}
}
