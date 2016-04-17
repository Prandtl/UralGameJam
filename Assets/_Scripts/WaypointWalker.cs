using UnityEngine;
using System.Collections;

public class WaypointWalker : MonoBehaviour {
	public float speed = 10.0f;
	public WaypointBehaviour wp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (wp == null)
			return;
		float step = speed * Time.deltaTime;
		//		Debug.Log (Vector3.MoveTowards (transform.position, initialPosition, step));
		transform.position = Vector3.MoveTowards(transform.position, wp.transform.position, step);
	
	}
}
