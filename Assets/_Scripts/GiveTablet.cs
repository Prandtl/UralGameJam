using UnityEngine;
using System.Collections;

public class GiveTablet : MonoBehaviour {

	void OnTriggerEnter()
	{
		FindObjectOfType<Inventory> ().AddTablet ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
