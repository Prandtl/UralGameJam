using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RoboScript : MonoBehaviour, IUsable {

	public bool GotMedal;

	Vector3 initialPosition;

	public void Use(){
		var player = FindObjectOfType<PrandtlyPlayerController> ();
		player.canMove = false;
		var robo = FindObjectOfType<PrandtlyController> ();
		robo.canMove = true;
	}

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
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
