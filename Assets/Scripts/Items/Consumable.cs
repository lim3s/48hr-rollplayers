﻿using UnityEngine;
using System.Collections;

public class Consumable : Grabbable {

	// Use this for initialization
	void Start () {
		setup ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void eat(){
		Destroy (this.gameObject);
	}
}
