using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class BigMedalController : MonoBehaviour, IUsable {

	public GameObject radio;
	public GameObject credits;
	public float creditsSpeed;
	public float maxY;

	// Use this for initialization
	void Start () {
		creditsPlaying = false;
		creditsSpeed = 0.3f;
		maxY = 12.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (creditsPlaying && credits.transform.position.y < maxY) {
			credits.transform.Translate (Vector3.up * Time.deltaTime * creditsSpeed);
		}
	}

	private bool creditsPlaying;

	public void Use () {
		gameObject.GetComponent<Renderer> ().enabled = false;
		gameObject.GetComponent<Collider> ().enabled = false;
		radio.GetComponent<AudioSource> ().Play ();
		creditsPlaying = true;
	}
}
