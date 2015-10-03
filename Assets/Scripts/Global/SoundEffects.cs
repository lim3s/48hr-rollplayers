using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour {
	
	public AudioClip smashing;
	public AudioClip pickup;
	public AudioClip poop;
	public AudioClip traincrash;
	public AudioClip trainhorn;
	public AudioClip wallhit;
	public AudioClip flap;

	AudioSource audio;
	float volume = 0.7f;

	enum Effects {smashing, pickup, poop, traincrash, trainhorn, wallhit, flap};

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	public void playClip(string ID){
		try {
			Effects effect = (Effects) Enum.Parse(typeof(Effects), ID);        
			if (Enum.IsDefined(typeof(Effects), ID) || effect.ToString().Contains(",")){
				playClipFromID(effect);
			}
		} catch (ArgumentException) {
			print ("Invalid argument to playClip");
		}
	}

	void playClipFromID(Effects effect){
		switch (effect) {
		case Effects.pickup:
			audio.PlayOneShot(pickup, volume);
			break;
		case Effects.poop:
			audio.PlayOneShot(poop, volume);
			break;
		case Effects.smashing:
			audio.PlayOneShot(smashing, volume);
			break;
		case Effects.traincrash:
			audio.PlayOneShot(traincrash, volume);
			break;
		case Effects.trainhorn:
			audio.PlayOneShot(trainhorn, volume);
			break;
		case Effects.wallhit:
			audio.PlayOneShot(wallhit, volume);
			break;
		case Effects.flap:
			audio.PlayOneShot(flap, volume);
			break;
		}
	}
}
