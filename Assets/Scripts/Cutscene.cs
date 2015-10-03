using UnityEngine;
using System.Collections;

public class Cutscene : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer myRenderer;
	AudioSource myAudio;
	int count = 0;
	float timer;
	float length = 3;

	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<SpriteRenderer> ();
		myAudio = GetComponent<AudioSource> ();
		myAudio.Play ();
		myRenderer.sprite = sprites [count];
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > length) {
			timer = 0;
			count++;
			if(count < sprites.Length){
				myRenderer.sprite = sprites[count];
			} else if (count >= sprites.Length){
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}
	}
}
