using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeWobble : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(new Vector3(transform.position.x - .1f, transform.position.y - .1f), Vector3.forward, 20 * Time.deltaTime);
	}
}
