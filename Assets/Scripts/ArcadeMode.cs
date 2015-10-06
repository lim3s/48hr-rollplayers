using UnityEngine;
using System.Collections;

public class ArcadeMode : MonoBehaviour {
	[SerializeField]
	BoxCollider2D mapBounds;
	[SerializeField]
	GameObject goal;

	float playerPoints;
	GameObject currGoal;
	// Use this for initialization
	void Start () {
		currGoal = (GameObject)Instantiate (goal, mapBounds.bounds.center, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewGoal() {
		GameObject.Destroy (currGoal);
	}
}
