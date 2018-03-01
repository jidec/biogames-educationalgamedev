using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabCircleBlink : MonoBehaviour {

	int counter;
	Vector3 size;

	// Use this for initialization
	void Start () {
		counter = 0;
		size = this.gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		if(counter > 44)
		{
			if(this.gameObject.transform.localScale == new Vector3(0,0,0))
				this.gameObject.transform.localScale = size;
			else
				this.gameObject.transform.localScale = new Vector3(0,0,0);
			counter = 0;
		}
	}
}
