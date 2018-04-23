using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = Quaternion.AngleAxis(-90, Vector3.left);
	}
}
