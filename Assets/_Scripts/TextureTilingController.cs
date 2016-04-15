using UnityEngine;
using System.Collections;

/* Controller for auto tiling textures (WIP)*/

[ExecuteInEditMode]
public class TextureTilingController : MonoBehaviour {

	public Texture texture;
	public float textureToMeshZ = 2.0f;

	// Use this for initialization
	void Start () {
		prevScale = transform.lossyScale;
		prevTextureToMeshZ = textureToMeshZ;
	}

	private Vector3 prevScale;
	private float prevTextureToMeshZ;
	
	// Update is called once per frame
	void Update () {
		if (transform.lossyScale != prevScale) {
		}
		prevScale = transform.lossyScale;
		prevTextureToMeshZ = textureToMeshZ;
		UpdateTiling ();
	}

	[ContextMenu("UpdateTiling")]
	void UpdateTiling() {

	}
}
