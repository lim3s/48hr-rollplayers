using UnityEngine;
using System.Collections;

public class Trophy : MonoBehaviour {
	public int trophyID;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			GameData.instance.myData.getTrophy(trophyID);
			Destroy(this);
		}
	}
}
