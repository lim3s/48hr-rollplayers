using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public Transform player;
	public Transform mycamera;

	bool dying = false;
	float timer = 0;
	float countdown = 5;

	[SerializeField]
	private GameObject grave;

	// Use this for initialization
	void Start () {/*
		Vector3[] graves = GameData.myData.getGraves (Application.loadedLevel);
		if (grave != null) {
			for (int i=0; i< graves.Length; i++) {
				Instantiate (grave, graves [i], Quaternion.identity);
			}
		}*/
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

	void die(){
		GameObject newGrave = (GameObject)Instantiate (grave, player.position, Quaternion.identity);
		newGrave.GetComponent<Rigidbody2D> ().velocity = Vector2.down * 5f;
		GameData.myData.addGrave (Application.loadedLevel, newGrave.transform.position);
		mycamera.GetComponent<CameraFollow> ().player = newGrave.transform;
		player.position = new Vector3 (5000, 5000, 0);
		dying = true;
	}
}
