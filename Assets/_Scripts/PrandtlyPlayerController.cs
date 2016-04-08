using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class PrandtlyPlayerController : MonoBehaviour
{
	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;

	public float speedH = 2.0f;
	public float speedV = 2.0f;

	void Start ()
	{
		CursorStateManager.HideCursor ();
	}

	void Awake ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.freezeRotation = true;
	}

	void Update ()
	{
		LookWithMouse ();
		ReleaseOnEsc ();
		GetBackInOnClick ();
	}

	void FixedUpdate ()
	{
		if (grounded) {
			var targetVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			targetVelocity = transform.TransformDirection (targetVelocity);
			targetVelocity *= speed;

			var velocity = rb.velocity;
			var dVelocity = targetVelocity - velocity;
			dVelocity.x = NormalizeVelocityChange (dVelocity.x);
			dVelocity.y = 0;
			dVelocity.z = NormalizeVelocityChange (dVelocity.z);

			rb.AddForce (dVelocity, ForceMode.VelocityChange);
			if (canJump && Input.GetButton ("Jump")) {
				rb.velocity = new Vector3 (velocity.x, CalculateJumpVerticalSpeed (), velocity.z);
			}
		}

		rb.AddForce (new Vector3 (0, -gravity * rb.mass, 0));
		grounded = false;
	}

	void OnCollisionStay (Collision collisionInfo)
	{
		if (!grounded) {
			foreach (var c in collisionInfo.contacts) {
				if (grounded)
					break;
				if (Vector3.Dot (c.normal, Vector3.up) > 0.5) {
					grounded = true;
				}
			}
		}
	}

	float CalculateJumpVerticalSpeed ()
	{
		return Mathf.Sqrt (2 * jumpHeight * gravity);
	}

	float NormalizeVelocityChange (float value)
	{
		return Mathf.Clamp (value, -maxVelocityChange, maxVelocityChange);
	}

	private bool grounded = false;
	private Rigidbody rb;


	void LookWithMouse ()
	{
		yaw += speedH * Input.GetAxis ("Mouse X");
		pitch -= speedV * Input.GetAxis ("Mouse Y");
		if (pitch > maxPitch)
			pitch = maxPitch;
		if (pitch < minPitch)
			pitch = minPitch;
		// turn character (z axis only)
		transform.eulerAngles = new Vector3 (0.0f, yaw, 0.0f);
		// turn mainCamera
		Camera.main.transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
	}

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	private float maxPitch = 90.0f;
	private float minPitch = -90.0f;


	void ReleaseOnEsc ()
	{
		if (CursorStateManager.IsLocked () && Input.GetKeyDown (KeyCode.Escape)) {
			CursorStateManager.ShowCursor ();
		}
	}

	void GetBackInOnClick ()
	{
		if (!CursorStateManager.IsLocked () && Input.GetMouseButtonDown (0)) {
			CursorStateManager.HideCursor ();
		}
	}
}
