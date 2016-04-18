using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Judge : MonoBehaviour, IUsable {
	public TextMaster GoAway;
	public TextMaster YouWon;
	public GameObject wall;

	void Start() {
		wall = GameObject.Find ("JudgeWall");
	}

	public void Use(){
		var tablet = FindObjectOfType<TabletScript> ();
		if (tablet.currentAmount < 7) {
			GoAway.Use ();
			return;
		}
		YouWon.Use ();
		Invoke ("RemoveWall", 6.0f);
	}

	void RemoveWall(){

		wall.GetComponent<Renderer> ().enabled = false;
		wall.GetComponent<Collider> ().enabled = false;
	}
}
