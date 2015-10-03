using UnityEngine;
using System.Collections;

public class TrianTrigger : Trigger {

	[SerializeField]
	GameObject spawnObj; 
	[SerializeField]
	Vector2 position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Activate (){
		Instantiate (spawnObj, position, Quaternion.identity);
		SoundManager.myManager.myEffects.playClip ("trainhorn");
		Destroy (this.gameObject);
	}
}
