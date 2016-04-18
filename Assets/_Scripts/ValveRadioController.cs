using UnityEngine;
using System.Collections;

public class ValveRadioController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		radio = GetComponent<AudioSource> ();
		played = false;
	}

	private AudioSource radio;
	private bool played;
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter () {
		if (!played) {
			radio.Play ();
			played = true;
		}
	}
}
