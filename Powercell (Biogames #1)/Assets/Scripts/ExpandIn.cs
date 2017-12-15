using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandIn : MonoBehaviour {

	Vector3 initialscale;
	// Use this for initialization
	void Start () {
		initialscale = transform.localScale;
		transform.localScale = new Vector3(0,0,initialscale.z);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.localScale.x < initialscale.x)
		{
			transform.localScale += new Vector3(.02f,.02f,0f);
		}
	}
}
