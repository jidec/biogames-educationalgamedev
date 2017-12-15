using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalConversationTriggerer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<ConversationController>().speak("Hey there driver! Thanks for picking me up. I'm sure you can get me home.");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
