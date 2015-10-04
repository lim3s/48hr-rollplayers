using UnityEngine;
using System.Collections;

public class PoopTrigger : Trigger {

	[SerializeField]
	ObservitoryDoor ob;

	public override void Activate(){
		ob.isOpen = true;
	}
}
