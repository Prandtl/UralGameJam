using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Door2Controller : MonoBehaviour, IUsable {

	public float maxOpeningLimit;
	public float openingSpeed;
	public bool doorsSwitch;

	// Use this for initialization
	void Start () {

		leftDoor = transform.Find ("LeftDoorWrapper");
		rightDoor = transform.Find ("RightDoorWrapper");

		maxOpeningLimit = 91.0f;
		openingSpeed = 2.5f;

		doorsSwitch = false;
		leftDoorOpened = false;
		rightDoorOpened = false;

		boltOpeningLimit = 89.0f;
		boltClosingLimit = 7.0f;
		bolt = transform.Find("BoltWrapper");
		boltOpened = false;
	}

	private float initialPositionZ;

	// Update is called once per frame
	void Update () {
		ControlDoors ();
	}

	public void Use () {
		SwitchDoor ();
	}

	public void SwitchDoor ()
	{
		doorsSwitch = !doorsSwitch;
	}

	void Open () {
		OpenBolt ();
		if (boltOpened) {
			OpenRightDoor ();
			OpenLeftDoor ();
		}
	}

	void Close () {
		CloseRightDoor ();
		CloseLeftDoor ();
		if (!(leftDoorOpened || rightDoorOpened))
			CloseBolt ();
	}

	void ControlDoors ()
	{
		if (doorsSwitch)
			Open ();
		else
			Close ();
	}

	void OpenRightDoor () {
		if (!rightDoorOpened && (rightDoor.localEulerAngles.y > 360 - maxOpeningLimit || rightDoor.localEulerAngles.y < 90))
			rightDoor.Rotate (Vector3.down * openingSpeed);
		else
			rightDoorOpened = true;
	}

	void CloseRightDoor () {
		if (rightDoorOpened && (rightDoor.localEulerAngles.y > 180))
			rightDoor.Rotate (Vector3.up * openingSpeed);
		else
			rightDoorOpened = false;
	}

	private Transform rightDoor;
	private bool rightDoorOpened;

	void OpenLeftDoor () {
		if (!leftDoorOpened && (leftDoor.localEulerAngles.y < maxOpeningLimit || leftDoor.localEulerAngles.y > 270))
			leftDoor.Rotate (Vector3.up * openingSpeed);
		else
			leftDoorOpened = true;
	}

	void CloseLeftDoor () {
		if (leftDoorOpened && (leftDoor.localEulerAngles.y < 180))
			leftDoor.Rotate (Vector3.down * openingSpeed);
		else
			leftDoorOpened = false;
	}

	private Transform leftDoor;
	private bool leftDoorOpened;

	void OpenBolt () {
		if (!boltOpened && bolt.localEulerAngles.x < boltOpeningLimit && bolt.localEulerAngles.y == 0)  // kostyl
			bolt.Rotate (Vector3.right * openingSpeed);
		else
			boltOpened = true;
	}

	void CloseBolt () {
		if (boltOpened && bolt.localEulerAngles.x > boltClosingLimit)
			bolt.Rotate (Vector3.left * openingSpeed);
		else
			boltOpened = false;
	}

	private float boltOpeningLimit;
	private float boltClosingLimit;
	private Transform bolt;
	private bool boltOpened;
}
