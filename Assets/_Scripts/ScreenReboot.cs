using UnityEngine;
using System.Collections;

public class ScreenReboot : MonoBehaviour {
	GUITexture texture;//TODO:разобраться с тем как делать заливку

	void Awake(){
		texture = GetComponent<GUITexture> ();
		texture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);


	}

	void Update()
	{
		if (Input.GetKey (KeyCode.B))
			texture.color = Color.black;
		else
			texture.color = Color.clear;
	}

}
