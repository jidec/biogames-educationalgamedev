using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurvedShader : MonoBehaviour {
public Shader shader;

	// Use this for initialization
	void Start () {
		Camera.main.RenderWithShader(shader,"curved");
	}
}
