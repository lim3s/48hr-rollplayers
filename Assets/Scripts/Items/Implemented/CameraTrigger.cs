using UnityEngine;
using System.Collections;

public class CameraTrigger : Trigger {
	[SerializeField]
	CameraFollow camFollow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate() {
		camFollow.stall = false;
	}
}
