using UnityEngine;
using System.Collections;

public class HogwartsTrapController : MonoBehaviour {

	public float maxOpeningLimit;
	public bool active;
	public bool wasActivated;
	public float openingSpeed;
	public float closingTimeDelay;

	// Use this for initialization
	void Start () {
		maxOpeningLimit = 2.0f;
		trapDoor1 = transform.Find ("TrapDoor1");
		trapDoor2 = transform.Find ("TrapDoor2");
		trapDoor1InitialX = trapDoor1.localPosition.x;
		trapDoor2InitialX = trapDoor2.localPosition.x;
		trapDoor1Opened = false;
		trapDoor2Opened = false;
		active = false;
		wasActivated = false;
		openingSpeed = 3.0f;
		closingTimeDelay = 3.0f;
	}

	private Transform trapDoor1;
	private Transform trapDoor2;
	private float trapDoor1InitialX;
	private float trapDoor2InitialX;

	// Update is called once per frame
	void Update () {
		ControlDoors ();
	}

	void ControlDoors () {
		if (active && !wasActivated) {
			OpenTrapDoors ();
			Invoke ("CloseTrapDoors", closingTimeDelay);
		}
	}

	void OnTriggerEnter () {
		if (!wasActivated) {
			active = true;
		}
	}

	void OpenTrapDoors () {
		OpenTrapDoor1 ();
		OpenTrapDoor2 ();
	}

	void CloseTrapDoors () {
		CloseTrapDoor1 ();
		CloseTrapDoor2 ();
		wasActivated = true;
		active = false;
	}

	void OpenTrapDoor1 () {
		if (!trapDoor1Opened && trapDoor1.localPosition.x > trapDoor1InitialX - maxOpeningLimit)
			trapDoor1.Translate (Vector3.left * openingSpeed * Time.deltaTime);
		else
			trapDoor1Opened = true;
	}

	void CloseTrapDoor1 () {
		if (trapDoor1Opened && trapDoor1.localPosition.x < trapDoor1InitialX)
			trapDoor1.Translate (Vector3.right * openingSpeed * Time.deltaTime);
		else
			trapDoor1Opened = false;
	}

	private bool trapDoor1Opened;

	void OpenTrapDoor2 () {
		if (!trapDoor2Opened && trapDoor2.localPosition.x < trapDoor2InitialX + maxOpeningLimit)
			trapDoor2.Translate (Vector3.right * openingSpeed * Time.deltaTime);
		else
			trapDoor2Opened = true;
	}

	void CloseTrapDoor2 () {
		if (trapDoor2Opened && trapDoor2.localPosition.x > trapDoor2InitialX)
			trapDoor2.Translate (Vector3.left * openingSpeed * Time.deltaTime);
		else
			trapDoor2Opened = false;
	}

	private bool trapDoor2Opened;
}
