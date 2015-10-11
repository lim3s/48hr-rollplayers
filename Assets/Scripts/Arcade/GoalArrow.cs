using UnityEngine;
using System.Collections;

public class GoalArrow : MonoBehaviour {
	Transform currGoal;
	[SerializeField]
	Transform player;

	[SerializeField]
	float dist = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currGoal = ArcadeMode.singleton.currGoal.transform;
		if (currGoal != null) {
			transform.position = player.position + (currGoal.position - player.position).normalized * dist;
			transform.rotation = Quaternion.Euler(((Mathf.Atan2((currGoal.position - player.position).y, (currGoal.position - player.position).x)* Mathf.Rad2Deg) - 90) * Vector3.forward);
		}
	}
}
