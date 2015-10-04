using UnityEngine;
using System.Collections;

public class SpeechBubbleFollow : MonoBehaviour {
	[SerializeField]
	Transform follow;
	[SerializeField]
	float offsetX;
	[SerializeField]
	float offsetY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = follow.position + new Vector3 (offsetX, offsetY, 0);
	}
}
