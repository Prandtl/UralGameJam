using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RingScript : MonoBehaviour, IUsable {

	AudioSource src;
	bool used;

	public Door2Controller door;

	public void Use(){
		src.Play ();
		if (!used) {
			Invoke ("OpenDoor", 0.5f);
			used = true;
		}
	}
	
	void OpenDoor(){
		door.SwitchDoor ();
	}
	// Use this for initialization
	void Start () {
		src = GetComponent<AudioSource> ();
		used = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
