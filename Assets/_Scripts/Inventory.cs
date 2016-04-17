using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	GameObject myTablet;
	public Image snickersImg;

	bool gotTablet;

	// Use this for initialization
	void Start () {
		myTablet = Object.FindObjectOfType<TabletScript> ().gameObject;
		gotTablet = false;
		snickers = false;
		ChangeTabletState (gotTablet);
		ChangeSnickersState (snickers);
	}

	public void AddTablet()
	{
		gotTablet = true;
		ChangeTabletState (gotTablet);
	}

	public void RemoveTablet()
	{
		gotTablet = false;
		ChangeTabletState (gotTablet);
	}

	void ChangeTabletState(bool state)
	{
		myTablet.GetComponent<Renderer> ().enabled = state;
	}

	bool snickers;

	public void GiveSnickers(){
		snickers = true;
		ChangeSnickersState (snickers);
	}

	public bool GotSnickers()
	{
		return snickers;
	}

	public void RemoveSnickers()
	{
		snickers = false;
		ChangeSnickersState (snickers);
	}

	void ChangeSnickersState(bool state)
	{
		snickersImg.enabled = state;
	}
}
