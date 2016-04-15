using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RingScript : MonoBehaviour, IUsable {

	AudioSource src;

	public void Use(){
		src.Play ();
	}

	// Use this for initialization
	void Start () {
		src = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
