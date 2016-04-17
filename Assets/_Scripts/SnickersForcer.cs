using UnityEngine;
using System.Collections;

public class SnickersForcer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	private Rigidbody rb;

	void Force() {
		rb.AddForce (transform.forward);
	}

	// Update is called once per frame
	void Update () {
	}
}
