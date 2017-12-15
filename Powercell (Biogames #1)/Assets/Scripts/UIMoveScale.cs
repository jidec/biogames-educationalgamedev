using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoveScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RectTransform myrect = GetComponent<RectTransform>();
		myrect.localPosition += new Vector3(2f, 1f);
		myrect.localScale += new Vector3(.002f, .002f);
	}
}
