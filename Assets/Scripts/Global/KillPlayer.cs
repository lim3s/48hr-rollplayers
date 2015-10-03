using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillPlayer : MonoBehaviour {

	public static KillPlayer instance;
	GameObject player;
	GameObject mycamera;

	bool dying = false;
	float timer = 0;
	float countdown = 5;
	List<Vector3> graves;
	GameObject newGrave;

	[SerializeField]
	private GameObject grave;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
			graves = new List<Vector3>();
		} else if (instance != this) {
			Destroy(gameObject);
		}
	}

	void OnLevelWasLoaded(){
		if (graves != null && graves.Count > 0) {
			for (int i=0; i< graves.Count; i++) {
				print ("New grave");
				Instantiate (grave, graves [i], Quaternion.identity);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (dying) {
			timer += Time.deltaTime;
			if(timer > countdown){
				timer = 0;
				dying = false;
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	public void die(){
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}

		if (mycamera == null) {
			mycamera = GameObject.FindGameObjectWithTag ("MainCamera");
		}

		newGrave = (GameObject)Instantiate (grave, player.transform.position, Quaternion.identity);
		newGrave.GetComponent<Rigidbody2D> ().velocity = Vector2.down * 5f;
		graves.Add (newGrave.transform.position);

		mycamera.GetComponent<CameraFollow> ().player = newGrave.transform;
		player.transform.position = new Vector3 (5000, 5000, 0);
		SoundManager.myManager.myEffects.enabled = false;

		dying = true;
	}
}
