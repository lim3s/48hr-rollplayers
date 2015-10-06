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
	[SerializeField]
	float raycastDist = 3;

	Vector2 currRot;
	float currSpeed;
	Vector2 currVelocity;
	Vector2 dragVector;
	Vector2 liftVector;

	float currStamina;

	Vector2 newVel;
	[SerializeField]
	float terminalVel = 100;

	public bool stunned = false;
	float stunTimer = 0;
	float currStun = 0;
	float maxStun = 5;
	[SerializeField]
	float stunThreshold = 3f;

	public bool wingsIn = false;
	public bool flapping = false;
	public bool standing = false;
	public bool superPowered = false;

	int layerMask = 1 << 8;
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

		if (!wingsIn && !standing && !stunned) {
			Rotate ();
			CalcVelocity ();
			AddVectors ();
		}
		RegenStamina ();
		AddGravity ();
		WingsInBoost ();
		if (currVelocity.magnitude < 1) {
			print ("pop");
			CheckStanding();
		}
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
		Vector2 flap;
		flap = transform.right * flapStrength;

		rb.velocity = rb.velocity + flap;
		flapping = true;

		if (standing) {
			standing = false;
		}

		currStamina -= 1;
	}

	public void Fart(float strength) {
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
		if (standing) {
			standing = false;
		}
		// Flap forward
		Vector2 flap = transform.right * flapStrength *0.05f;
		rb.velocity = rb.velocity + flap;
		rb.velocity = Vector2.ClampMagnitude (rb.velocity, terminalVel);
		
		//currStamina -= 1;
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
		if (coll.gameObject.tag == "Wall") {
			if (coll.relativeVelocity.magnitude > stunThreshold && !stunned && Mathf.Abs(Vector2.Dot (coll.contacts[0].normal, newVel))/newVel.magnitude > 0.5f) {
				StartStun(coll.relativeVelocity.x);
			}
		}
	}

	void CheckStanding() {
		RaycastHit2D hit = Physics2D.Raycast (transform.position + Vector3.up*0.02f, Vector2.down, raycastDist, layerMask);
		print (hit.transform != null);
		if (hit) {
			print (hit.transform.tag);
			if (hit.transform.tag == "Wall") {
				standing = true;
			}
		}
	}

	void StartStun(float speed) {
		stunned = true;
		currStun = Mathf.Log(speed);
		stunTimer = 0;
		SoundManager.myManager.myEffects.playClip("wallhit");
	}

	void TickStun() {
		if (stunned) {
			stunTimer += Time.deltaTime * 3f;
		}
		if (stunTimer >= currStun) {
			stunned = false;
		} else if (stunTimer >= maxStun) {
			stunned = false;
		}
	}

	void FixAngularVelocity() {
		rb.angularVelocity = 0;
	}

	public float getCurrSpeed(){
		return currSpeed;
	}
}
