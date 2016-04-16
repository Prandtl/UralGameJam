using UnityEngine;
using System.Collections;

public class WaypointBehaviour : MonoBehaviour {

	public WaypointBehaviour next;

	public WaypointBehaviour GetNextWaypoint()
	{
		return next;
	}
}
