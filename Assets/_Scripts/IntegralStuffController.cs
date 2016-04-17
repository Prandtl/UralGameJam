using UnityEngine;
using System.Collections;

public class IntegralStuffController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		failTexture1 = Resources.Load ("youAreStone") as Texture;
		monitor = transform.Find ("Monitor");
	}

	private Texture failTexture1;
	private Texture failTexture2;
	private Texture failTexture3;
	private Texture winTexture;

	private Transform monitor;

	// Update is called once per frame
	void Update () {
		
	}
}
