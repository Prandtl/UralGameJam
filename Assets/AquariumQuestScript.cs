using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class AquariumQuestScript : MonoBehaviour, IUsable {

	public TextMaster hungryMaster;
	public TextMaster notHungryMaster;



	public void Use(){
		if (GotMedal) {
			hungryMaster.Use ();
		} 
		else {
			notHungryMaster.Use ();
		}
	}

	public void TakeMedal()
	{
		GotMedal = false;
	}

	bool GotMedal;
	bool SeenFood;

	// Use this for initialization
	void Start () {
		GotMedal = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
