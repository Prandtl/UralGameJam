using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class TabletScript : MonoBehaviour, IMedalReciever {

	public int currentAmount;
	int maxAmount = 7;

	public void AddMedal()
	{
		if (currentAmount < maxAmount) {
			transform.GetChild (currentAmount).GetComponent<Renderer> ().enabled = true;
			currentAmount++;
		}
		
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild (i).gameObject.GetComponent<Renderer> ().enabled = false;
		}
		currentAmount = 0;
	}

}
