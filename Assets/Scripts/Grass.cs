using UnityEngine;
using System.Collections;

public class Grass : MonoBehaviour {

	public Sprite[] mySprites;

	SpriteRenderer myRenderer;
	float timer;
	float interval = 0.75f;
	int currentSprite = 0;

	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<SpriteRenderer> ();
		myRenderer.sprite = mySprites [0];
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > interval) {
			timer = 0;
			currentSprite++;
			if(currentSprite >= mySprites.Length){
				currentSprite = 0;
			}
			myRenderer.sprite = mySprites[currentSprite];
		}
	}
}
