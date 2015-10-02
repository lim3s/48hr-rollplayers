using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {
	[SerializeField]
	private GameObject poop;
	[SerializeField]
	private Rigidbody2D rb;
	[HideInInspector]
	public bool hasPickup;
	public float pickupDist = 10f;
	private GameObject grabbedObj;

	SpriteDirection sprite;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteDirection> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			if(hasPickup){;
				DropObject();
			} else if (CheckProximity()){
				PickupObject();
				sprite.grab ();
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
		hasPickup = true;

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

		Quaternion newRotation = Quaternion.Euler (transform.rotation.eulerAngles.x + 90, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
		poopy.transform.rotation = newRotation;
		GameObject.Destroy (poopy, 10f);
	}

	void DropObject(){
		grabbedObj.GetComponent<Rigidbody2D> ().velocity = rb.velocity + Vector2.down * 1.5f;
		grabbedObj = null;
		hasPickup = false;
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
