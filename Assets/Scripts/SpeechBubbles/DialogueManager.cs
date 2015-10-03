using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {
	[SerializeField]
	TextAsset dialogueFile;

	Dictionary<string, string> dialogue;

	public static DialogueManager instance;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		dialogue = new Dictionary<string, string> ();
		if (dialogueFile != null) {
			string[] dialogueLines = dialogueFile.text.Split('\n');

			foreach (string line in dialogueLines) {
				string[] singleLine = line.Split(':');
				dialogue.Add(singleLine[0], singleLine[1]);
			}
			print ("Dialogue Loaded!");
		}
		GameObject.DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string GetDialogue(string key) {
		if (!dialogue.ContainsKey (key)) {
			return "Swoopy poopy escape from the coopy";
		} else {
			return dialogue[key];
		}
	}
}
