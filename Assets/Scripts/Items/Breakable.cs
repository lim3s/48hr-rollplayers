using UnityEngine;
using System.Collections;

public class Breakable : MonoBehaviour {

	public Sprite unbroken;
	public Sprite brokenObj;

	bool broken = false;
	[SerializeField]
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
		SoundManager.myManager.myEffects.playClip ("smashing");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.tag == "Breaker") {
			if (!broken) {
				float velocity = coll.gameObject.GetComponent<Rigidbody2D> ().velocity.magnitude;
				/*Check if object is flying fast enough*/
				if (velocity >= threshold) {
					breakObject ();
				}
			}
		}
	}

}
