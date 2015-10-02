using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

	[HideInInspector]
	public bool hasPickup;
	public float pickupDist;
	private GameObject grabbedObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			if(hasPickup){
				DropObject();
			} else if (CheckProximity()){
				PickupObject();
			} else {
				Poop();
			}
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

	void Poop(){}

	void DropObject(){
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
