using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DarkeningOnTrigger : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other)
	{
		RenderSettings.ambientIntensity = 0;
		var player = Object.FindObjectOfType<PrandtlyPlayerController> ();
		player.SetMoveState (false);
		player.SetWatchState (false);
		Invoke ("ChangeLevel", 5.0f);
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
