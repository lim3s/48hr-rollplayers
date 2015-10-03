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
	public AudioClip keycard;
	public AudioClip drop;
	public AudioClip objective;

	AudioSource myAudio;
	float volume = 0.7f;

	enum Effects {smashing, pickup, poop, traincrash, trainhorn, wallhit, flap, keycard, drop, objective};

	// Use this for initialization
	void Start () {
		myAudio = GetComponent<AudioSource>();
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
			myAudio.PlayOneShot(pickup, volume);
			break;
		case Effects.poop:
			myAudio.PlayOneShot(poop, volume);
			break;
		case Effects.smashing:
			myAudio.PlayOneShot(smashing, volume);
			break;
		case Effects.traincrash:
			myAudio.PlayOneShot(traincrash, volume);
			break;
		case Effects.trainhorn:
			myAudio.PlayOneShot(trainhorn, volume);
			break;
		case Effects.wallhit:
			myAudio.PlayOneShot(wallhit, volume);
			break;
		case Effects.flap:
			myAudio.PlayOneShot(flap, volume);
			break;
		case Effects.keycard:
			myAudio.PlayOneShot(keycard, volume);
			break;
		case Effects.drop:
			myAudio.PlayOneShot(drop, volume);
			break;
		case Effects.objective:
			myAudio.PlayOneShot(objective, volume);
			break;
		}
	}
}
