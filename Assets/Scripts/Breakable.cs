using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {

	public Sprite unbroken;
	public Sprite brokenObj;

	bool broken = false;
	float threshold = 5;
	SpriteRenderer myRenderer;

	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<SpriteRenderer> ();
		myRenderer.sprite = unbroken;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void breakObject(){
		broken = true;
		myRenderer.sprite = brokenObj;
		GetComponent<Collider2D> ().enabled = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(!broken){
			float velocity = coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
			/*Check if player is flying fast enough*/
			if(velocity >= threshold){
				breakObject();
			}
		}
	}

}
