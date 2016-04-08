using UnityEngine;
using System.Collections;

public class Door1Controller : MonoBehaviour {

	public float maxOpeningLimit;

	// Use this for initialization
	void Start () {
		leftDoor = transform.Find ("LeftDoor");
		rightDoor = transform.Find ("RightDoor");
		initialPosition = leftDoor.transform.position;
	}

	private Transform leftDoor;
	private Transform rightDoor;
	private Vector3 initialPosition;

	// Update is called once per frame
	void Update () {
		Open ();
	}

	void Open () {
	}

	void Close () {

	}
}
