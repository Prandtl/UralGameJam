using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Shader))]
public class SmartphoneScreenChanger : MonoBehaviour {

	public float timeToChangeScreen = 0.2f;

	// Use this for initialization
	void Start () {
		Debug.Log (gameObject);
		index = 0;
		colors = new Color[]{ Color.magenta, Color.cyan, Color.yellow, Color.white};
		mat = GetComponent<Renderer> ().material;
		InvokeRepeating ("ChangeScreen", timeToChangeScreen, timeToChangeScreen);
	}

	void ChangeScreen(){
		mat.SetColor("_EmissionColor", colors[index]);

		index = Random.Range (0, colors.Length);
	}


	Color[] colors;

	int index;
	Material mat;
}
