using UnityEngine;
using System.Collections;

public class HandJobController : MonoBehaviour {

	public bool handSwitch;

	// Use this for initialization
	void Start () {
		hand = transform.Find ("HandWrapper");
		handSwitch = false;
	}

	private Transform hand;
	
	// Update is called once per frame
	void Update () {
		ControlHand ();
	}

	void ControlHand() {
		if (!handSwitch)
			HandDown ();
		else
			HandUp ();
	}

	void HandUp () {
		if (hand.localEulerAngles.x < 360 && hand.localEulerAngles.x > 90)
			hand.Rotate (Vector3.right);
	}

	void HandDown () {
		if (hand.localEulerAngles.x > 360-90 && hand.localEulerAngles.y < 90)	//	Koctyl
			hand.Rotate (Vector3.left);
	}

	void SwitchHand() {
		handSwitch = !handSwitch;
	}
}
