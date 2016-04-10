using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LapTopController : MonoBehaviour, IUsable {

	public float openingSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		cover = transform.Find ("CoverWrapper");
	}

	private Transform cover;
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Use () {
		OpenCover ();
	}

	void OpenCover () {
		cover.Rotate (-Vector3.forward * (openingSpeed * Time.deltaTime));
	}

	void CloseCover () {

	}
}
