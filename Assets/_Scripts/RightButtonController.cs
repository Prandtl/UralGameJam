using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RightButtonController : MonoBehaviour, IUsable {

	public bool used;

	// Use this for initialization
	void Start () {
		medal = transform.Find ("Medal");
		used = false;
		cylinder = transform.Find ("Cylinder");
	}

	private Transform cylinder;
	private Transform medal;
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Use() {
		if (!used)
			cylinder.Translate (Vector3.down * 0.06f);
		used = true;
		Rigidbody rb = medal.gameObject.AddComponent<Rigidbody> ();
		rb.mass = 5;
	}
}
