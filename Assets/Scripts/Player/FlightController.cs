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
	float maxStamina = 3;
	[SerializeField]
	float gravity = 9.81f;
	[SerializeField]
	float regenRate = 0.2f;
	[SerializeField]
	float wingsInMultiplier = 1.2f;

	Vector2 currRot;
	float currSpeed;
	Vector2 currVelocity;
	Vector2 dragVector;
	Vector2 liftVector;

	float currStamina;

	Vector2 newVel;

	bool stunned = false;
	float stunTimer = 0;
	float currStun = 0;
	[SerializeField]
	float stunThreshold = 3f;

	public bool wingsIn = false;
	public bool flapping = false;
	// Use this for initialization
	void Start () {
		currStamina = maxStamina;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		TickStun ();
		FixAngularVelocity ();
		currRot  = transform.right;
		currVelocity = rb.velocity;
		currSpeed = currVelocity.magnitude;
		dragVector = currVelocity * -1;

		if (!wingsIn) {
			Rotate ();
			CalcVelocity ();
			AddVectors ();
		}
		RegenStamina ();
		AddGravity ();
		WingsInBoost ();
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
		if (wingsIn) {
			liftVector *= 1.2f;
		}

		liftVector = liftVector * wingLift * currSpeed * liftPercent;
	}

	void AddVectors() {
		rb.velocity = newVel + liftVector;
	}

	void AddGravity() {
		rb.velocity -= Vector2.up * gravity;
	}

	void WingsInBoost() {
		if (wingsIn) {
			Vector2 wingBoost = transform.right * wingsInMultiplier;
			rb.velocity = rb.velocity + wingBoost;
		}
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
		if (currStamina < 1) {
			return;
		}
		// Flap forward
		Vector2 flap = transform.right * flapStrength;
		rb.velocity = rb.velocity + flap;
		// Flap up
//		Vector2 flap = transform.up * strength;
//		if (flap.y < 0) {
//			flap *= -1;
//		}
//		rb.velocity += flap;
		flapping = true;

		currStamina -= 1;
	}

	void RegenStamina() {
		currStamina += Time.fixedDeltaTime * regenRate;
		if (currStamina > maxStamina) {
			currStamina = maxStamina;
		}
	}

	public void Wings(bool areIn) {
		wingsIn = areIn;
	}

	public void ResetPos() {
		transform.position = new Vector2 (-60, 40);
		rb.velocity = Vector2.zero;
	}

	public float StaminaPercent() {
		return currStamina / maxStamina;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		print ("on collision");
		if (coll.gameObject.tag == "Wall") {
			print ("Collision");
			if (coll.relativeVelocity.x > stunThreshold && !stunned) {
				StartStun(coll.relativeVelocity.x);
			}
			rb.velocity -= Vector2.right * rb.velocity.x * 1.5f;
		}
	}

	void StartStun(float speed) {
		print ("Stunned");
		stunned = true;
		currStun = Mathf.Log(speed);
		stunTimer = 0;
		print ("Stun time: " + currStun);
		SoundManager.myManager.myEffects.playClip("wallhit");
	}

	void TickStun() {
		if (stunned) {
			stunTimer += Time.deltaTime * 3f;
			print (stunTimer);
		}
		if (stunTimer >= currStun) {
			stunned = false;
		}
	}

	void FixAngularVelocity() {
		if (!stunned) {
			rb.angularVelocity = 0;
		}
	}
}
