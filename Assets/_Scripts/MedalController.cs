using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class MedalController : MonoBehaviour, IUsable {

	public void Use(){
		var reciever = GameObject.FindGameObjectsWithTag ("MedalReciever");
		GameObject.FindObjectOfType<TabletScript> ().AddMedal ();
		Destroy (gameObject);
	}
}
