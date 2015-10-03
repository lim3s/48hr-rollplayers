using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaBar : MonoBehaviour {
	[SerializeField]
	FlightController flight;
	[SerializeField]
	Image myImage;

	float maxSize;
	// Use this for initialization
	void Start () {
		maxSize = myImage.rectTransform.rect.height;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float scale = flight.StaminaPercent ();
		transform.localScale = new Vector2(transform.localScale.x, scale);
		transform.localPosition = Vector2.down * (1 - scale) * maxSize / 2;
	}
}
