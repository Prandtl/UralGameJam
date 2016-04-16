using UnityEngine;
using System.Collections;

public class PrandtlyController : MonoBehaviour {

	public float speed = 5.5f;
	public float walkSpeed = 2.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	public float rotateSpeed = 2.0f;


	void Awake ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.freezeRotation = true;
		currentSpeed = speed;
	}

	void FixedUpdate ()
	{
		if (grounded) {
			//var targetVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			var targetVelocity = new Vector3 (0, 0, -Input.GetAxis ("Vertical"));
			targetVelocity = transform.TransformDirection (targetVelocity);
			targetVelocity *= currentSpeed;

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

		transform.Rotate (-Vector3.up * Input.GetAxis ("Horizontal") * rotateSpeed);
		rb.AddForce (new Vector3 (0, -gravity * rb.mass, 0));
		grounded = false;
	}

	private float currentSpeed;

	void OnCollisionStay (Collision collisionInfo)
	{
		if (!grounded) {
			foreach (var c in collisionInfo.contacts) {
				if (grounded)
					break;
				if (Vector3.Dot (c.normal, Vector3.up) > 0.1) {
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
}
