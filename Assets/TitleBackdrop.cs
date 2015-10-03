using UnityEngine;
using System.Collections;

public class TitleBackdrop : MonoBehaviour {

	LogoMove logo;

	// Use this for initialization
	void Start () {
		logo = FindObjectOfType<LogoMove> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (logo.stopped && !logo.active) {
			transform.position-= transform.right * Time.deltaTime*2;
		}
	}
}
