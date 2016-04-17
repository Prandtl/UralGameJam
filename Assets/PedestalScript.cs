using UnityEngine;
using System.Collections;

public class PedestalScript : MonoBehaviour {

	public GameObject medal;
	public Light PedestalLight;

	bool visited = false;


	void OnTriggerEnter(Collider other){
		if (!visited) {
			medal.GetComponent<Renderer> ().enabled = false;
			PedestalLight.enabled = false;
			visited = true;
			FindObjectOfType<RoboScript> ().GiveMedal ();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
