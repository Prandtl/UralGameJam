using UnityEngine;
using System.Collections;

public class JacketColorChooser : MonoBehaviour {

	static Color[] colors = new Color[]{ 
		new Color((float)75/255,(float)50/255,(float)178/255),
		new Color((float)255/255,(float)50/255,(float)178/255),
		new Color((float)50/255,(float)94/255,(float)255/255),
		new Color((float)50/255,(float)255/255,(float)230/255),
		new Color((float)255/255,(float)153/255,(float)0/255),
		new Color((float)255/255,(float)35/255,(float)210/255),
		new Color((float)61/255,(float)163/255,(float)255/255)
	};

	// Use this for initialization
	void Start () {
		Material mat =  GetComponent<Renderer> ().material;
		int index = Random.Range (0, colors.Length);
		mat.SetColor ("_Color", colors [index]);
	}
}
