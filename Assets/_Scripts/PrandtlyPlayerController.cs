using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

[RequireComponent (typeof(Rigidbody))]
public class PrandtlyPlayerController : MonoBehaviour
{

	public bool canMove = true;
	public bool canWatch = true;


	public float speed = 5.5f;
	public float walkSpeed = 2.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;

	public float speedH = 2.0f;
	public float speedV = 2.0f;

	public float objectUseDistance = 2.0f;
	public Image handImage;

	public void SetWatchState(bool state){
		canWatch = state;
	}

	public void SetMoveState(bool state){
		canMove = state;
	}

	void Start ()
	{
		CursorStateManager.HideCursor ();
		cam = Camera.main;

	}

	void Awake ()
	{
		rb = GetComponent<Rigidbody> ();
		rb.useGravity = false;
		rb.freezeRotation = true;
		currentSpeed = speed;
	}

	void Update ()
	{
		handImage.enabled = false;
		CheckRunning ();
		LookWithMouse ();
		ReleaseOnEsc ();
		GetBackInOnClick ();
		DrawHandIfUsable ();
		UseIfPossible ();
	}

	void FixedUpdate ()
	{
		if (!canMove)
			return;
		
		if (grounded) {
			var targetVelocity = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
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


	void LookWithMouse ()
	{
		if (!canWatch)
			return;
		yaw += speedH * Input.GetAxis ("Mouse X");
		pitch -= speedV * Input.GetAxis ("Mouse Y");
		if (pitch > maxPitch)
			pitch = maxPitch;
		if (pitch < minPitch)
			pitch = minPitch;
		// turn character (z axis only)
		transform.eulerAngles = new Vector3 (0.0f, yaw, 0.0f);
		// turn mainCamera
		cam.transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
	}

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	private float maxPitch = 90.0f;
	private float minPitch = -90.0f;

	private Camera cam;

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

	void CheckRunning ()
	{
		currentSpeed = Input.GetKey (KeyCode.LeftShift) ? walkSpeed : speed;
	}

	IUsable CheckUsableObjects ()
	{
		RaycastHit hit;
		var ray = Camera.main.ScreenPointToRay (new Vector3 (cam.pixelWidth / 2, cam.pixelHeight / 2, 0));
		if (Physics.Raycast (ray, out hit, objectUseDistance)) {
			var obj = hit.collider.gameObject;
			if (obj.tag == "Usable") {
				IUsable usable = (IUsable)obj.GetComponent (typeof(IUsable));
				return usable;
			}
		}
		return null;
	}

	void UseIfPossible ()
	{
		if (Input.GetKeyDown (KeyCode.E)) {
			var obj = CheckUsableObjects ();
			if (obj == null)
				return;
			obj.Use ();
		}
	}

	void DrawHandIfUsable(){
		var obj = CheckUsableObjects ();
		if (obj == null)
			return;
		handImage.enabled = true;
	}
}
