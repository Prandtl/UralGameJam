using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using AssemblyCSharp;

public class TextMaster : MonoBehaviour, IUsable {
	public List<Text> texts;
	public List<float> intervals;
	float alltime;

	public float StartedTalking;


	public void Use(){
		if (Time.time - StartedTalking > alltime) {
			StartedTalking = Time.time;
			StartCoroutine (ShowText ());
		}

	}

	IEnumerator ShowText(){
		for (int i = 0; i < texts.Count; i++) {
			texts [i].enabled = true;
			var interval = i >= intervals.Count ? 1 : intervals [i];
			yield return new WaitForSeconds (interval);
			texts [i].enabled = false;
		}
	}

	void Start () {
		alltime = 0;
		for (int i = 0; i < intervals.Count; i++) {
			alltime += intervals [i];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
