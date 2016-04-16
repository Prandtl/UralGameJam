using UnityEngine;
using System.Collections;

public class GiveTablet : MonoBehaviour {

	void OnTriggerEnter()
	{
		var go = FindObjectOfType<TabletScript> ().gameObject;
		FindObjectOfType<Inventory> ().AddTablet ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
