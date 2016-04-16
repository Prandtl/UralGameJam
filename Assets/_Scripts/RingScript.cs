using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RingScript : MonoBehaviour, IUsable {

	AudioSource src;

	public Door2Controller door;

	public void Use(){
		src.Play ();
		Invoke ("OpenDoor", 0.5f);
	}
	
	void OpenDoor(){
		door.SwitchDoor ();
	}
	// Use this for initialization
	void Start () {
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
