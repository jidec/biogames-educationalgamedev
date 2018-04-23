using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotateBack : MonoBehaviour {

	public int timesincelastmove;
	public Quaternion lastrotation;
	public bool lerping;
	
	// Update is called once per frame
	void FixedUpdate () {
		timesincelastmove++;
		//if a change in rotation
		if(transform.rotation != lastrotation && !lerping)
		{
			timesincelastmove = 0;
		}
		
		lastrotation = transform.rotation;

		if(timesincelastmove > 450)
		{
			lerping = true;
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, .1f);
		}
	}
}
