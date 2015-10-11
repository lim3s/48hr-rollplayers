using UnityEngine;
using System.Collections;

public class ArcadeMode : MonoBehaviour {
	public static ArcadeMode singleton;

	[SerializeField]
	BoxCollider2D arenaBounds;
	[SerializeField]
	GameObject goal;

	float playerPoints;
	public GameObject currGoal;
	// Use this for initialization
	void Start () {
		if (singleton == null) {
			singleton = this;
			DontDestroyOnLoad (gameObject);
		} else {
			DestroyImmediate(gameObject);
			return;
		}

		currGoal = (GameObject)Instantiate (goal, arenaBounds.bounds.center, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewGoal() {
		GameObject.Destroy (currGoal);
		Vector2 newPos = new Vector2 (arenaBounds.bounds.min.x + Random.value * arenaBounds.bounds.size.x, arenaBounds.bounds.min.y + Random.value * arenaBounds.bounds.size.y);
		currGoal = (GameObject)Instantiate (goal, newPos, Quaternion.identity);
	}
}
