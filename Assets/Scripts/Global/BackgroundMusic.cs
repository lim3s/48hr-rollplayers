using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour {
	public AudioClip level1;
	public AudioClip level2;
	public AudioClip level2b;
	public AudioClip level3;
	public AudioClip level3b;

	AudioSource levelMusic;
	float volume = 0.7f;
	int playing = 0;
	bool part2 = false;

	// Use this for initialization
	void Start () {
		levelMusic = GetComponent<AudioSource>();
		levelMusic.loop = true;
		startMusic (0, 0);
	}

	public void startMusic(int level, int stage){
		float time = 0;
		levelMusic.Stop ();
		switch (level) {
		case 0:
			levelMusic.clip = level1;
			break;
		case 1:
			if(stage == 0){
				levelMusic.clip = level2;
			} else if (stage == 1){
				time = levelMusic.time;
				levelMusic.clip = level2b;
			}
			break;
		case 2:
			if (stage == 0) {
				levelMusic.clip = level3;
			} else if (stage == 1){
				levelMusic.clip = level3b;
			}
			break;
		}
		levelMusic.Play ();
		levelMusic.time = time;
	}
}
