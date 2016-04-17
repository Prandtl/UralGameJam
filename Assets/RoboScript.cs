using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RoboScript : MonoBehaviour, IUsable {
	public TextMaster robotutor;
	public bool GotMedal;
	public GameObject Medal;

	Vector3 initialPosition;

	public void GiveMedal(){
		GotMedal = true;
		Medal.GetComponent<Renderer> ().enabled = GotMedal;
		Medal.GetComponent<Collider> ().enabled = GotMedal;
	}

	public void Use(){
		robotutor.Use ();
		var player = FindObjectOfType<PrandtlyPlayerController> ();
		player.canMove = false;
		var robo = FindObjectOfType<PrandtlyController> ();
		robo.canMove = true;
	}

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
		Medal.GetComponent<Renderer> ().enabled = GotMedal;
		Medal.GetComponent<Collider> ().enabled = GotMedal;
	}
	
	// Update is called once per frame
	void Update () {
		ResetOnEsc ();
	}

	void ResetOnEsc(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			var player = FindObjectOfType<PrandtlyPlayerController> ();
			player.canMove = true;
			var robo = FindObjectOfType<PrandtlyController> ();
			robo.canMove = false;
			robo.gameObject.transform.position = initialPosition;
		}
	}
}
