using UnityEngine;
using System.Collections;

public class PersonController : MonoBehaviour {

	Vector3 initialPosition;
	float speed = 5.0f;
	float step;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		step = speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Vector3.MoveTowards (transform.position, initialPosition, step));
		transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);
	}


}
