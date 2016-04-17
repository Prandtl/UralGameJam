﻿using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ButtonController : MonoBehaviour, IUsable {

	public bool used;

	// Use this for initialization
	void Start () {
		used = false;
		cylinder = transform.Find ("Cylinder");
	}

	private Transform cylinder;
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Use() {
		if (!used)
			cylinder.Translate (Vector3.down * 0.06f);
		used = true;
	}
}
