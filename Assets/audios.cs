using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class audios : MonoBehaviour {
	public List<AudioSource> sources;
	public List<float> delays;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < sources.Count; i++) {
			var delay = i >= delays.Count ? 0.25f * i : delays [i];
			sources [i].PlayDelayed (delay);
		}
	}

}
