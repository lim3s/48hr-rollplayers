using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody2D))]
public class PickupController : MonoBehaviour {
	[SerializeField]
	private GameObject poop;
	[SerializeField]
	private Rigidbody2D rb;
	[HideInInspector]
	public bool hasPickup;
	public float pickupDist = 30f;
	private GameObject grabbedObj;

	SpriteDirection sprite;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteDirection> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
			if(hasPickup){;
				DropObject();
			} else if (CheckProximity()){
				PickupObject();
			} else {
				Poop();
			}
		}

		if (hasPickup) {
			grabbedObj.transform.position = transform.position;
		}
	}

	bool CheckProximity(){
		Grabbable c = GetClosest ();
		if (c != null && Vector2.Distance (this.transform.position, c.transform.position) < pickupDist) {
			return true;
		}
		return false;
	}

	void PickupObject(){
		grabbedObj = GetClosest ().gameObject;

		Grabbable grab = grabbedObj.GetComponent<Grabbable> ();
		if (grab != null) {
			grab.grabObject ();
		}

		hasPickup = true;
		sprite.grab ();
		SoundManager.myManager.myEffects.playClip ("pickup");

		Consumable consume = grabbedObj.gameObject.GetComponent<Consumable> ();
		if (consume != null) {
			/*Increase stamina or something*/
			grabbedObj = null;
			hasPickup = false;
			consume.eat();
		}
	}

	void Poop(){
		GameObject poopy = (GameObject)Instantiate (poop, transform.position, Quaternion.identity);
		poopy.GetComponent<Rigidbody2D> ().velocity = rb.velocity + Vector2.down * 5f;
		SoundManager.myManager.myEffects.playClip ("poop");
		Quaternion newRotation = Quaternion.Euler (transform.rotation.eulerAngles.x + 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		poopy.transform.rotation = newRotation;
		GameObject.Destroy (poopy, 10f);
	}

	void DropObject(){
		grabbedObj.GetComponent<Rigidbody2D> ().velocity = rb.velocity + Vector2.down * 1.5f;
		grabbedObj.GetComponent<Grabbable> ().dropObject ();
		grabbedObj = null;
		hasPickup = false;
		SoundManager.myManager.myEffects.playClip ("drop");
	}

	Grabbable GetClosest(){
		Grabbable closest = null;
		foreach (Grabbable g in FindObjectsOfType<Grabbable> ()) {
			if(closest == null)
				closest = g;
			else if(Vector2.Distance(this.transform.position, g.transform.position) < Vector2.Distance(this.transform.position, closest.transform.position))
				closest = g;
		}
		return closest;
	}
}
