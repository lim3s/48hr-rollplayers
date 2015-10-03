using UnityEngine;
using System.Collections;

public class LogoMove : MonoBehaviour {

	private float timeTilStop;
	private float time = 1.6f; 
	private float distancePerFrame;
	public bool stopped;
	public bool active;

	// Use this for initialization
	void Start () {
		distancePerFrame = Vector2.Distance (Camera.main.transform.position, this.transform.position)/(time*50);
		timeTilStop = time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (active) {
			transform.position = Vector2.Lerp(transform.position, Camera.main.transform.position+Vector3.up*2, Time.fixedDeltaTime*10);
			transform.GetChild(0).position = Vector2.Lerp(transform.GetChild(0).position, Camera.main.transform.position+Vector3.up*-3, Time.fixedDeltaTime*10);
			if(Input.GetKeyDown(KeyCode.JoystickButton0)){
				PlayGame();
			} else if (Input.GetKeyDown(KeyCode.JoystickButton1)){
				ExitGame();
			}
		}

		if (timeTilStop > 0) {
			transform.position += transform.right * distancePerFrame;
			timeTilStop -= Time.fixedDeltaTime;
		} else {
			stopped = true;
		}

		if (stopped && Input.anyKey && !active) {
			active = true;
		}

		if (Time.timeSinceLevelLoad > 40 && !active) {
			Application.LoadLevel(0);
		}
	}

	public void PlayGame () {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void ExitGame() {
		Application.Quit ();
	}
}
