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

	void Awake ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.freezeRotation = true;
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
		}

		rb.AddForce (new Vector3 (0, -gravity * rb.mass, 0));
		grounded = false;
	}

	void OnCollisionStay ()
	{
		grounded = true;
	}

	float CaluculateJumpVerticalSpeed ()
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
