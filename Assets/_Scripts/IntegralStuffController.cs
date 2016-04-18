using UnityEngine;
using System.Collections;

public class IntegralStuffController : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		string path = "Textures/Integral/";
		defaultTexture = Resources.Load (path + "integral") as Texture;
		failTexture1 = Resources.Load (path + "youAreStone") as Texture;
		failTexture2 = Resources.Load (path + "demidovich") as Texture;
		failTexture3 = Resources.Load (path + "facepalm") as Texture;
		//winTexture = Resources.Load (path + "") as Texture;
		monitor = transform.Find ("Monitor");
		rend = monitor.GetComponent<Renderer> ();

		wrongButtons = GetComponentsInChildren<ButtonController>();
		rightButton = GetComponentInChildren<RightButtonController>();
		radio = GetComponentInChildren<AudioSource> ();

		failTexture1Used = false;
		failTexture2Used = false;
		failTexture3Used = false;
		celebration = false;

		monitorDelay = 5.0f;

		emitters = GetComponentsInChildren<ParticleSystem>();

		StopEmitters ();
	}

	private ParticleSystem[] emitters;

	private float monitorDelay;

	private Texture defaultTexture;

	private Texture failTexture1;
	private Texture failTexture2;
	private Texture failTexture3;
	//private Texture winTexture;

	private ButtonController[] wrongButtons;
	private RightButtonController rightButton;
	private AudioSource radio;

	private Transform monitor;

	private Renderer rend;

	// Update is called once per frame
	void Update () {
		
		if (!failTexture1Used && wrongButtons [0].used) {
			rend.material.mainTexture = failTexture1;
			Invoke ("SetDefaultTexture", monitorDelay);
			failTexture1Used = true;
		}

		if (!failTexture2Used && wrongButtons [1].used) {
			rend.material.mainTexture = failTexture2;
			Invoke ("SetDefaultTexture", monitorDelay);
			failTexture2Used = true;
		}

		if (!failTexture3Used && wrongButtons [2].used) {
			rend.material.mainTexture = failTexture3;
			Invoke ("SetDefaultTexture", monitorDelay);
			failTexture3Used = true;
		}

		if (rightButton.used && !celebration) {
			Celebrate ();
			celebration = true;
		}
	}

	void SetDefaultTexture () {
		rend.material.mainTexture = defaultTexture;
	}

	void Celebrate () {
		StartEmitters ();
		radio.Play ();
	}

	void StopEmitters () {
		foreach (var emitter in emitters) {
			emitter.Stop ();
		}
	}

	void StartEmitters () {
		foreach (var emitter in emitters) {
			emitter.Play();
		}
	}

	private bool failTexture1Used;
	private bool failTexture2Used;
	private bool failTexture3Used;
	private bool celebration;
}
