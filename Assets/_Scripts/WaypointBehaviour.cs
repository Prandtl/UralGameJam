using UnityEngine;
using System.Collections;

public class WaypointBehaviour : MonoBehaviour {

	public WaypointBehaviour next;

	public WaypointBehaviour GetNextWaypoint()
	{
		return next;
	}

	void OnTriggerEnter(Collider other){
		var walker = other.GetComponent<WaypointWalker>();
		if (walker == null)
			return;
		walker.wp = next;
	}
}
