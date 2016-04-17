using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class SnickersForcer : MonoBehaviour, IUsable {

	public void Use(){
		FindObjectOfType<Inventory> ().GiveSnickers ();
		Destroy (this.gameObject);
	}
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
