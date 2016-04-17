using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DarkeningOnTrigger : MonoBehaviour {

	public Light whiteLight;

	public Image energyStar;

	public AudioSource glitch;
	public AudioSource turnoff;
	public AudioSource turnon;
	public GameObject lighthouse;
	public List<Text> texts;
	public List<float> intervals;

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		whiteLight.enabled = true;
		RenderSettings.ambientIntensity = 0;
		var player = Object.FindObjectOfType<PrandtlyPlayerController> ();
		player.SetMoveState (false);
		player.SetWatchState (false);
		player.transform.LookAt (lighthouse.transform);
		glitch.Play ();
		Invoke ("Darkness", 0.1f);
		Invoke ("Turnoff", 2.0f);
	}

	void Darkness(){
		whiteLight.enabled = false;
	}

	void Turnoff()
	{
		turnoff.Play ();
		Invoke ("BootScreen", 2.0f);
	}

	void BootScreen(){
		turnon.Play ();
		energyStar.enabled = true;
		StartCoroutine (ShowText ());
		Invoke ("ChangeLevel", 7.0f);
	}

	IEnumerator ShowText(){
		for (int i = 0; i < texts.Count; i++) {
			texts [i].enabled = true;
			var interval = i >= intervals.Count ? 1 : intervals [i];
			yield return new WaitForSeconds (interval);
		}
	}

	void ChangeLevel()
	{
		SceneManager.LoadScene ("scene2");
	}

	void OnTriggerExit(Collider other)
	{
		RenderSettings.ambientIntensity = 1;
	}
}
