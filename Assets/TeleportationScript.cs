using UnityEngine;
using System.Collections;

public class TeleportationScript : MonoBehaviour {

	public Vector3 PositionForTeleportation;	

	void OnTriggerEnter(Collider other)
	{
		other.transform.position = PositionForTeleportation;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
