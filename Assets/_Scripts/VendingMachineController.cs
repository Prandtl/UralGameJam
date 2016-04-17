using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class VendingMachineController : MonoBehaviour, IUsable {

	public float speed;
	public bool used;
	public float maxOpeningLimit;

	// Use this for initialization
	void Start () {
		shelf = transform.Find ("Shelf");
		used = false;
		speed = 100.0f;
		maxOpeningLimit = 60.0f;
		snickers = GetComponentInChildren<SnickersForcer> ();
	}
	
	// Update is called once per frame
	void Update () {
		ControlShelf ();
	}

	void ControlShelf() {
		if(used)
			GetFood ();
	}

	private Component snickers;

	void GetFood () {
		if (shelf.localEulerAngles.z < 90 || shelf.localEulerAngles.z > 360 - maxOpeningLimit) {
			shelf.Rotate (Vector3.back * speed * Time.deltaTime);
		}
	}

	private Transform shelf;

	public void Use () {
		used = true;
		snickers.SendMessage("Force");
	}
}
