using UnityEngine;
using System.Collections;

public class LevelTrigger : Trigger {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate() {
		Application.LoadLevel (Application.loadedLevel+1);
	}
}
