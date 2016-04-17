using UnityEngine;
using System.Collections;

public class PedestalScript : MonoBehaviour {

	public GameObject medal;
	public Light PedestalLight;

	bool visited = false;


	void OnTriggerEnter(Collider other){
		Debug.Log ("FUCK");
		if (!visited) {
			Debug.Log ("SHEIT");
			medal.GetComponent<Renderer> ().enabled = false;
			PedestalLight.enabled = false;
			visited = true;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
