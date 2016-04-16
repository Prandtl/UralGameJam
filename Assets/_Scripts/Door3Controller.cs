using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Door3Controller : MonoBehaviour, IUsable {

	public bool doorSwitch;

	// Use this for initialization
	void Start () {
		door = transform.Find ("Door");
		doorSwitch = false;
	}

	private Transform door;
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Use() {

	}

	public void SwitchDoor() {
		doorSwitch = !doorSwitch;
	}

	void Open() {

	}

	void Close() {

	}
}
