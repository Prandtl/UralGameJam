using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Door3Controller : MonoBehaviour, IUsable {

	public bool doorSwitch;
	public float openingSpeed;

	// Use this for initialization
	void Start () {
		door = transform.Find ("Door");
		doorSwitch = false;
		openingSpeed = 2.0f;
	}

	private Transform door;
	
	// Update is called once per frame
	void Update () {
		ControlDoor ();
	}

	public void Use () {
		SwitchDoor ();
	}

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
		door.Translate (Vector3.right * openingSpeed * Time.deltaTime);
	}

	void Close () {

	}
}
