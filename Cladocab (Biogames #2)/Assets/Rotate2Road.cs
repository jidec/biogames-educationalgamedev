using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2Road : MonoBehaviour {

	public GameObject parentroad;
	// Use this for initialization
	void Start () {
		parentroad = GetComponentInParent<Road>().gameObject; 
		transform.localRotation = new Quaternion(0,0,0,0);
	}
}
