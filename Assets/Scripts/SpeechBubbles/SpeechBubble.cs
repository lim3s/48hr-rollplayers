using UnityEngine;
using System.Collections;
using System.Text;

public class SpeechBubble : MonoBehaviour {
	[SerializeField]
	DialogueManager dialogueManager;

	[SerializeField]
	string dialogueName;

	string dialogueText;
	int numLines = 1;

	[SerializeField]
	TextMesh myText;
	[SerializeField]
	GameObject topBubble;
	// Use this for initialization
	void Start () {
		dialogueText = dialogueManager.GetDialogue (dialogueName);

		StringBuilder sb = new StringBuilder ();
		int charCount = 0;
		foreach (string word in dialogueText.Split (' ')) {
			if ((charCount + word.Length) > 50) {
				sb.Append('\n');
				sb.Append(word + " ");
				charCount = 0;
				numLines++;
			} else {
				sb.Append(word + " ");
				charCount += word.Length;
			}
		}
		dialogueText = sb.ToString();

		myText.text = dialogueText;
		float scale;
		switch (numLines) {
		case 1:
		case 2:
		case 3:
			scale = 0.4f;
			break;
		case 4:
		case 5:
			scale = 0.65f;
			break;
		case 6:
		case 7:
			scale = 0.86f;
			break;
		case 8:
		case 9:
		default:
			scale = 1.2f;
			break;
		}
		topBubble.transform.localScale = new Vector2 (2.7f, scale);
		Disappear ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D coll) {
		//Show bubble
		if (coll.transform.tag == "Player") {
			Reappear ();
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.transform.tag == "Player") {
			Disappear ();
		}
	}

	void Disappear() {
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		topBubble.GetComponent<SpriteRenderer> ().enabled = false;
	}

	void Reappear() {
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		topBubble.GetComponent<SpriteRenderer> ().enabled = true;
	}
}
