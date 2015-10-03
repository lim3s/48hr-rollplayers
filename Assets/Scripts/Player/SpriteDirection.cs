using UnityEngine;
using System.Collections;

public class SpriteDirection : MonoBehaviour {
	
	Animator anim;
	FlightController flight;
	bool idleRunning = false;
	bool facingRight = true;
	float currentRotation;

	void Start () {
		anim = GetComponent<Animator> ();
		flight = GetComponent<FlightController> ();
		anim.SetBool ("Idle", true);
	}

	void Update () {
		if (idleRunning) {
			if (flight.wingsIn) {
				anim.SetBool ("WingsIn", true);
				anim.SetBool ("Idle", false);
				idleRunning = false;
			}
		} else {
			if(!flight.wingsIn){
				anim.SetBool ("WingsIn", false);
				anim.SetBool ("Idle", true);
				idleRunning = true;
			}
		}
		currentRotation = transform.eulerAngles.z;
		setFacing (currentRotation);
		anim.SetFloat("X", findX(currentRotation));
		anim.SetFloat("Y", findY(currentRotation));

		if (flight.flapping) {
			anim.SetTrigger ("Flap");
			flight.flapping = false;
			SoundManager.myManager.myEffects.playClip("flap");
		}
	}

	public void grab(){
		anim.SetTrigger ("Grab");
	}

	float findX(float rotation) {
		if (rotation >= 0 && rotation < 60) {
			return 1f;
		} else if (rotation >= 60 && rotation < 75) {
			return 0.5f;
		} else if (rotation >= 75 && rotation < 105) {
			return 0f;
		} else if (rotation >= 105 && rotation < 120) {
			return -0.5f;
		} else if (rotation >= 120 && rotation < 240) {
			return 1f;
		} else if (rotation >= 240 && rotation < 255) {
			return -0.5f;
		} else if (rotation >= 255 && rotation < 285) {
			return 0f;
		} else if (rotation >= 285 && rotation < 300) {
			return 0.5f;
		} else {
			return 1f;
		}
	}

	float findY(float rotation) {
		if (rotation >= 45 && rotation < 135) {
			return 1f;
		} else if (rotation >= 225 && rotation < 315) {
			return -1f;
		} else {
			return 0f;
		}
	}
	
	void setFacing(float rotation) {
		if (rotation >= 105 && rotation < 255) {
			if (facingRight) {
				flip();
			}
		} else {
			if(!facingRight){
				flip();
			}
		}
	}

	void flip(){
		facingRight = !facingRight;
		Vector3 myScale = transform.localScale;
		myScale.y *= -1;
		transform.localScale = myScale;
	}
}
