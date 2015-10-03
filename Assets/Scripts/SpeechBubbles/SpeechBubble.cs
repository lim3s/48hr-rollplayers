using UnityEngine;
using System.Collections;
using System.Text;

public class SpeechBubble : MonoBehaviour {

	[SerializeField]
	string dialogueName;
	[SerializeField]
	DialogueManager manager;

	string dialogueText;
	int numLines = 1;

	[SerializeField]
	TextMesh myText;
	[SerializeField]
	GameObject topBubble;

	bool initial = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (manager.ready && initial) {
			initial = false;
			dialogueText = manager.GetDialogue (dialogueName);
			
			StringBuilder sb = new StringBuilder ();
			int charCount = 0;
			foreach (string word in dialogueText.Split (' ')) {
				if ((charCount + word.Length) > 30) {
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

			topBubble.transform.localScale = new Vector2 (1, 1 + 0.3f * (numLines-1));
			Disappear ();
		}
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
