using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class AquariumBoxScript : MonoBehaviour, IUsable {

	public TextMaster needSnickersMaster;

	AquariumQuestScript aquarium;
	TabletScript tablet;
	Inventory inv;

	public void Use(){
		if (!inv.GotSnickers ()) {
			needSnickersMaster.Use ();
		} else {
			aquarium.TakeMedal ();
			inv.RemoveSnickers ();
			tablet.AddMedal ();
		}
	}

	// Use this for initialization
	void Start () {
		aquarium = FindObjectOfType<AquariumQuestScript> ();
		tablet = FindObjectOfType<TabletScript> ();
		inv = FindObjectOfType<Inventory> ();
	}
}
