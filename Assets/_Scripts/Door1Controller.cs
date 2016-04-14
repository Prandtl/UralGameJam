﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Door1Controller : MonoBehaviour, IUsable {

	public float maxOpeningLimit;
	public float openingSpeed;
	public bool doorsSwitch;

	// Use this for initialization
	void Start () {
		
		leftDoor = transform.Find ("LeftDoor");
		rightDoor = transform.Find ("RightDoor");

		initialPositionZ = leftDoor.position.z;
		maxOpeningLimit = 1.8f;
		rightDoorOpeningLimit = initialPositionZ - maxOpeningLimit;
		leftDoorOpeningLimit = initialPositionZ + maxOpeningLimit;
		openingSpeed = 0.1f;

		doorsSwitch = false;
		leftDoorOpened = false;
		rightDoorOpened = false;
	}

	private float initialPositionZ;

	// Update is called once per frame
	void Update () {
		ControlDoors ();
	}

	public void Use () {
		SwitchDoor ();
	}

	void SwitchDoor ()
	{
		doorsSwitch = !doorsSwitch;
	}

	void Open () {
		OpenRightDoor ();
		if (rightDoorOpened) {
			OpenLeftDoor ();
		}
	}

	void Close () {
		CloseLeftDoor ();
		if (!leftDoorOpened)
			CloseRightDoor ();
	}

	void ControlDoors ()
	{
		if (doorsSwitch)
			Open ();
		else
			Close ();
	}

	void OpenRightDoor () {
		if (!rightDoorOpened && rightDoor.position.z > rightDoorOpeningLimit)
			rightDoor.Translate (Vector3.back * openingSpeed);
		else
			rightDoorOpened = true;
	}

	void CloseRightDoor () {
		if (rightDoorOpened && rightDoor.position.z < initialPositionZ)
			rightDoor.Translate (Vector3.forward * openingSpeed);
		else
			rightDoorOpened = false;
	}

	private Transform rightDoor;
	private bool rightDoorOpened;
	private float rightDoorOpeningLimit;

	void OpenLeftDoor () {
		if (!leftDoorOpened && leftDoor.position.z < leftDoorOpeningLimit)
			leftDoor.Translate (Vector3.forward * openingSpeed);
		else
			leftDoorOpened = true;
	}

	void CloseLeftDoor () {
		if (leftDoorOpened && leftDoor.position.z > initialPositionZ)
			leftDoor.Translate (Vector3.back * openingSpeed);
		else
			leftDoorOpened = false;
	}

	private Transform leftDoor;
	private bool leftDoorOpened;
	private float leftDoorOpeningLimit;

}