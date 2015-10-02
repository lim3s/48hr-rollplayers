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

	Vector2 currRot;
	float currSpeed;
	Vector2 currVelocity;
	Vector2 dragVector;
	Vector2 liftVector;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currRot  = transform.right;
		currVelocity = rb.velocity;
		currSpeed = currVelocity.magnitude;
		dragVector = currVelocity * -1;

		CalcVelocity ();
		AddVectors ();
	}

	void CalcVelocity() {
		// Drag
		float dragAngle = Vector2.Angle (currRot, dragVector);


		// Lift
		float liftPercent = Vector2.Dot (currRot, currVelocity.normalized);
		liftVector = transform.up;
		if (liftVector.y < 0) {
			liftVector = -liftVector;
		}

		liftVector = liftVector * wingLift * currSpeed * liftPercent;
	}

	void AddVectors() {
		rb.velocity = new Vector2 (rb.velocity.x + liftVector.x, rb.velocity.y + liftVector.y);
	}
}
