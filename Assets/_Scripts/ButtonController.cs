using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ButtonController : MonoBehaviour, IUsable {

	// Use this for initialization
	void Start () {
		cylinder = transform.Find ("Cylinder");
	}

	private Transform cylinder;
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Use() {
		cylinder.Translate (Vector3.down * 0.03f);
	}
}
