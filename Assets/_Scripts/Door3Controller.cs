using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Door3Controller : MonoBehaviour, IUsable {

	public bool doorSwitch;
	public float openingSpeed;
	public float maxTowardsShift;				// Выдвижение двери на себя
	public float maxSideShift;					// сдвиг вбок
	public float usageDelay;

	// Use this for initialization
	void Start () {
		door = transform.Find ("Door");
		doorSwitch = false;
		openingSpeed = 3.0f;
		maxTowardsShift = 1.4f;
		maxSideShift = 0.7f;
		initialPosition = door.transform.localPosition;
		doorOpened = false;
		doorSideShifted = false;
		nextUsage = Time.time;
		usageDelay = 1.5f;
	}

	private Vector3 initialPosition;
	private Transform door;
	
	// Update is called once per frame
	void Update () {
		ControlDoor ();
	}

	public void Use () {
		if (Time.time > nextUsage) {
			SwitchDoor ();
			nextUsage = Time.time + usageDelay;
		}
	}

	private float nextUsage;

	public void SwitchDoor () {
		doorSwitch = !doorSwitch;
	}

	void ControlDoor () {
		if (doorSwitch)
			Open ();
		else
			Close ();
	}

	void Open () {
		if (!doorOpened && (door.localPosition.x > initialPosition.x - maxTowardsShift))
			door.Translate (Vector3.left * openingSpeed * Time.deltaTime);
		else if (!doorSideShifted && (door.localPosition.z > initialPosition.z - maxSideShift)) {
			door.Translate (Vector3.back * openingSpeed * Time.deltaTime);
		} else {
			doorSideShifted = true;
			doorOpened = true;
		}
	}

	void Close () {
		if (doorSideShifted && (door.localPosition.z < initialPosition.z))
			door.Translate (Vector3.forward * openingSpeed * Time.deltaTime);
		else {
			doorSideShifted = false;
			if (!doorOpened && (door.localPosition.x < initialPosition.x))
				door.Translate (Vector3.right * openingSpeed * Time.deltaTime);
			else
				doorOpened = false;
		}
	}

	private bool doorOpened;
	private bool doorSideShifted;
}
