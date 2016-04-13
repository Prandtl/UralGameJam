﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class WardrobeController : MonoBehaviour, IUsable {

	public float openingSpeed;
	public float closingSpeed;
	public float maxOpeningLimit;
	public bool doorsOpened;
	public bool doorsSwitch;

	// Use this for initialization
	void Start () {
		maxOpeningLimit = 150.0f;
		openingSpeed = 70.0f;
		closingSpeed = 70.0f;
		doorsOpened = false;
		doorsSwitch = false;
		leftDoor = transform.Find ("LeftDoorContainer");
		leftDoor.eulerAngles.Set (0, 0, 0);
		rightDoor = transform.Find ("RightDoorContainer");
		rightDoor.eulerAngles.Set (0, 0, 0);
	}

	private Transform leftDoor;
	private Transform rightDoor;
	
	// Update is called once per frame
	void Update () {
		ControlDoors ();
		/*
		if (Input.GetKeyDown(KeyCode.C)) {
			SwitchDoors ();
		};
		*/
	}

	void SwitchDoors ()
	{
		doorsSwitch = !doorsSwitch;
	}

	void ControlDoors () {
		if (doorsSwitch) {
			//doorsOpened = false;
			OpenDoors ();
		} else {
			//doorsOpened = true;
			CloseDoors ();
		}
	}

	void OpenDoors () {
		if (!doorsOpened) {
			Debug.Log (leftDoor.eulerAngles.y);
			if (leftDoor.eulerAngles.y < maxOpeningLimit) {
				leftDoor.transform.Rotate (Vector3.up * (openingSpeed * Time.deltaTime));
				rightDoor.transform.Rotate (-Vector3.up * (openingSpeed * Time.deltaTime));
			} else {
				doorsOpened = true;
			}
		}
	}

	void CloseDoors () {
		if (doorsOpened) {
			if (leftDoor.eulerAngles.y > 3.0f && leftDoor.eulerAngles.y < 270.0f) {
				leftDoor.transform.Rotate (-Vector3.up * (openingSpeed * Time.deltaTime));
				rightDoor.transform.Rotate (Vector3.up * (openingSpeed * Time.deltaTime));
			} else {
				doorsOpened = false;
			}
		}
	}

	public void Use()
	{
		SwitchDoors ();
	}
}
