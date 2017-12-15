using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyCameraMove : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		speed = GetComponent<Camera>().orthographicSize / 60;

		
		if (Input.GetKey (KeyCode.D))
			this.transform.position += new Vector3 (speed, 0f);
		if (Input.GetKey (KeyCode.A))
			this.transform.position += new Vector3 (-speed, 0f);
		if (Input.GetKey (KeyCode.W))
			this.transform.position += new Vector3 (0, speed);
		if (Input.GetKey (KeyCode.S))
			this.transform.position += new Vector3 (0, -speed);
		

	/* 
		if (Input.GetKey (KeyCode.D))
			this.transform.position = Vector3.Lerp(this.transform.position, this.transform.position + new Vector3 (speed, 0f),.7f);
		if (Input.GetKey (KeyCode.A))
			this.transform.position += new Vector3 (-speed, 0f);
		if (Input.GetKey (KeyCode.W))
			this.transform.position += new Vector3 (0, speed);
		if (Input.GetKey (KeyCode.S))
			this.transform.position += new Vector3 (0, -speed);
			*/
	}
}
