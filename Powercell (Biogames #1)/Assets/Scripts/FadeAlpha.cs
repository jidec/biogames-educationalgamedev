using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAlpha : MonoBehaviour {


	public float fadepersecond;
	public bool fade = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(fade)
		{
			var material = GetComponent<Renderer>().material;
			var color = material.color;
			material.color = new Color(color.r, color.g, color.b, color.a - (fadepersecond * Time.deltaTime));
		}
	}
}
