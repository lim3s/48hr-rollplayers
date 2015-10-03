using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager myManager;
	public SoundEffects myEffects;

	// Use this for initialization
	void Start () {
		myEffects = GetComponentInChildren<SoundEffects> ();
		if (myManager == null) {
			DontDestroyOnLoad (gameObject);
			myManager = this;
		} else if (myManager != this) {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
