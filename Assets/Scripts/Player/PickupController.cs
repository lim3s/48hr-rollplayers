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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			if(hasPickup){
				print ("drop");
				DropObject();
			} else if (CheckProximity()){
				print ("Pickup attempt");
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
		hasPickup = true;
	}

	void Poop(){
		GameObject poopy = (GameObject)Instantiate (poop, transform.position, Quaternion.identity);
		poopy.GetComponent<Rigidbody2D> ().velocity = rb.velocity + Vector2.down * 5f;
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
