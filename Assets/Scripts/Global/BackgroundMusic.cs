using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour {
	public AudioClip bgMusic;
	AudioSource[] levelMusic;
	float volume = 0.7f;
	int playing = 0;

	// Use this for initialization
	void Start () {
		levelMusic = GetComponents<AudioSource>();
		for (int i=0; i<levelMusic.Length; i++) {
			levelMusic[i].volume = volume;
		}
		levelMusic [playing].Play ();
	}

	public void startMusic(int i){
		if (i >= 0 && i < levelMusic.Length) {
			levelMusic [playing].Stop ();
			levelMusic [i].Play ();
			playing = i;
		}
	}
}
