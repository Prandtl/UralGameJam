using UnityEngine;
using System.Collections;

public class LadderSegmentController : MonoBehaviour {

	public int state;

	void setState(int state) {
		this.state = state;
	}

	public float RotationSpeed;

	// Use this for initialization
	void Start () {
		RotationSpeed = 20.0f;
		state = 0;
		prevState = 0;
		initialRotation = transform.localEulerAngles.y;
	}

	private int prevState;
	private float initialRotation;

	// Update is called once per frame
	void Update () {
		ControlPosition ();
	}

	void ControlPosition () {
		
		if (state == 0)
		if (prevState == -1 && transform.localEulerAngles.y < initialRotation) {
			transform.Rotate (Vector3.up * RotationSpeed * Time.deltaTime);
		}
		else if (prevState == 1 && transform.localEulerAngles.y > initialRotation)
			transform.Rotate (-Vector3.up * RotationSpeed * Time.deltaTime);
		else
			prevState = 0;

		if (state == 1)
		if (transform.localEulerAngles.y < initialRotation + 90) {
			transform.Rotate (Vector3.up * RotationSpeed * Time.deltaTime);
		}
		else
			prevState = 1;

		if (state == -1)
		if (transform.localEulerAngles.y > initialRotation - 90) {
			transform.Rotate (-Vector3.up * RotationSpeed * Time.deltaTime);
		}
		else
			prevState = -1;
	}
}
