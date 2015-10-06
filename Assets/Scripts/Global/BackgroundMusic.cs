using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour {
	public AudioClip title;
	public AudioClip level1;
	public AudioClip level2;
	public AudioClip level2b;
	public AudioClip level3;
	public AudioClip space;
	public AudioClip end;

	AudioSource levelMusic;
	float volume = 1.5f;

	// Use this for initialization
	void Start () {
		levelMusic = GetComponent<AudioSource>();
		levelMusic.loop = true;
		levelMusic.volume = volume;
		startMusic (Application.loadedLevel);
	}

	void OnLevelWasLoaded(){
		startMusic (Application.loadedLevel);
	}

	void startMusic(int level){
		levelMusic = GetComponent<AudioSource>();
		switch (level) {
		case 1:
			levelMusic.clip = title;
			break;
		case 2:
			levelMusic.clip = level1;
			break;
		case 3:
			levelMusic.clip = level2;
			break;
		case 4:
			levelMusic.clip = level2b;
			break;
		case 5:
			levelMusic.clip = level3;
			break;
		case 6:
			levelMusic.clip = end;
			break;
		}
		levelMusic.Play ();
	}

	public void enterSpace(){
		levelMusic.Stop ();
		levelMusic.clip = space;
		levelMusic.Play ();
	}
}
