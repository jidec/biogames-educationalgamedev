using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechSetTriggerer : MonoBehaviour {

	public SpeechSet quotes;
	public bool speaktwo;

	//speak from assigned set when colliding with player
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(speaktwo)
				quotes.speakFirstTwoFromSet();
			else
				quotes.speakFromSet();
		}
	}
}
