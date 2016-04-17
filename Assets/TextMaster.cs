using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using AssemblyCSharp;

public class TextMaster : MonoBehaviour, IUsable {
	public List<Text> texts;
	public List<float> intervals;

	public void Use(){
		StartCoroutine (ShowText ());
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
