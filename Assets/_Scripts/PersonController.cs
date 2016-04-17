using UnityEngine;
using System.Collections;

public class PersonController : MonoBehaviour {

	Vector3 initialPosition;
	float speed = 5.0f;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float step = speed * Time.deltaTime;
//		Debug.Log (Vector3.MoveTowards (transform.position, initialPosition, step));
		transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);
	}


}
