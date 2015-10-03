using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {
	[SerializeField]
	Sprite inactiveSprite;
	[SerializeField]
	Sprite activeSprite;
	[SerializeField]
	GameObject key;

	bool active = false;

	SpriteRenderer myRenderer;
	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<SpriteRenderer> ();
		myRenderer.sprite = inactiveSprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll != null) {
			if (coll.gameObject.Equals(key) && !active) {
				Activate ();
			}
		}
	}

	public virtual void Activate() {
		myRenderer.sprite = activeSprite;
		GetComponent<BoxCollider2D> ().enabled = false;
		active = true;
	}
}
