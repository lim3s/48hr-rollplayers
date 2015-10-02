using UnityEngine;
using System.Collections;

public class FlightController : MonoBehaviour {
	
	[SerializeField]
	Rigidbody2D rb;
	[SerializeField]
	float wingLift = 15f;
	[SerializeField]
	float dragAmount = 5f;
	[SerializeField]
	float flapStrength = 10f;
	[SerializeField]
	float maxFlap = 80f;
	[SerializeField]
	float gravity = 9.81f;

	Vector2 currRot;
	float currSpeed;
	Vector2 currVelocity;
	Vector2 dragVector;
	Vector2 liftVector;

	Vector2 newVel;

	public bool wingsIn = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currRot  = transform.right;
		currVelocity = rb.velocity;
		currSpeed = currVelocity.magnitude;
		dragVector = currVelocity * -1;

		if (!wingsIn) {
			Rotate ();
			CalcVelocity ();
			AddVectors ();
		}
		AddGravity ();
	}

	void Rotate() {
		newVel = (Vector3.Project (currVelocity, currRot) * 0.2f);
		newVel += (currVelocity * 0.8f);
	}

	void CalcVelocity() {
		// Drag


		// Lift
		float liftPercent = Vector2.Dot (currRot, currVelocity.normalized);
		liftVector = transform.up;
		if (liftVector.y < 0) {
			liftVector = -liftVector;
		}

		liftVector = liftVector * wingLift * currSpeed * liftPercent;
	}

	void AddVectors() {
		rb.velocity = newVel + liftVector;
	}

	void AddGravity() {
		rb.velocity -= Vector2.up * gravity;
	}

	public void Flap(float strength) {
		if (strength > maxFlap) {
			strength = maxFlap;
		} else if (strength < flapStrength) {
			strength = flapStrength;
		}
		if (wingsIn) {
			return;
		}
		print ("FlapStrength: " + strength);
		// Flap forward
//		Vector2 flap = transform.right * flapStrength;
//		rb.velocity = rb.velocity + flap;
		// Flap up
		Vector2 flap = transform.up * strength;
		if (flap.y < 0) {
			flap *= -1;
		}
		rb.velocity += flap;
	}

	public void Wings(bool areIn) {
		print ("Wings: " + areIn);
		wingsIn = areIn;
	}

	public void ResetPos() {
		print ("Reset");
		transform.position = new Vector2 (-60, 40);
		rb.velocity = Vector2.zero;
	}
}
