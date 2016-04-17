using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class WardrobeController : MonoBehaviour, IUsable {

	public float openingSpeed;
	public float closingSpeed;
	public float maxOpeningLimit;
	public bool doorsOpened;
	public bool doorsSwitch;
	public float usageDelay;

	// Use this for initialization
	void Start () {
		maxOpeningLimit = 150.0f;
		openingSpeed = 70.0f;
		closingSpeed = 70.0f;
		doorsOpened = false;
		doorsSwitch = false;
		leftDoor = transform.Find ("LeftDoorContainer");
		rightDoor = transform.Find ("RightDoorContainer");
		nextUsage = Time.time;
		usageDelay = 2.5f;
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
			if (leftDoor.localEulerAngles.y < maxOpeningLimit) {
				leftDoor.transform.Rotate (Vector3.up * (openingSpeed * Time.deltaTime));
				rightDoor.transform.Rotate (-Vector3.up * (openingSpeed * Time.deltaTime));
			} else {
				doorsOpened = true;
			}
		}
	}

	void CloseDoors () {
		if (doorsOpened) {
			if (leftDoor.localEulerAngles.y > 3.0f && leftDoor.localEulerAngles.y < 270.0f) {
				leftDoor.transform.Rotate (-Vector3.up * (openingSpeed * Time.deltaTime));
				rightDoor.transform.Rotate (Vector3.up * (openingSpeed * Time.deltaTime));
			} else {
				doorsOpened = false;
			}
		}
	}

	public void Use () {
		if (Time.time > nextUsage) {
			SwitchDoors ();
			nextUsage = Time.time + usageDelay;
		}
	}

	private float nextUsage;
}
