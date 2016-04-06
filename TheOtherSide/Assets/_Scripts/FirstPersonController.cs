using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    // Use this for initialization
    void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		MoveOnWasd();
		LookWithMouse();
	}

    void MoveOnWasd ()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime);
    }

    void LookWithMouse ()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
		if (pitch > maxPitch)
			pitch = maxPitch;
		if (pitch < minPitch)
			pitch = minPitch;
        // turn character (z axis only)
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        // turn mainCamera
        Camera.main.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	private float maxPitch = 90.0f;
	private float minPitch = -90.0f;

}
