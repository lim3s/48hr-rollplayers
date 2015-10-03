using UnityEngine;
using System.Collections;

public class LevelTrigger : Trigger {
	[SerializeField]
	Object nextScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate() {
		Application.LoadLevel (nextScene.name);
	}
}
