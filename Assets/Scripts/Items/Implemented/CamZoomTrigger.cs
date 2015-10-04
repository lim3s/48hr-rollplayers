﻿using UnityEngine;
using System.Collections;

public class CamZoomTrigger : Trigger {
	[SerializeField]
	CameraFollow camFollow;
	[SerializeField]
	float zoom = 60;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate() {
		camFollow.minZoom = zoom;
	}
}
