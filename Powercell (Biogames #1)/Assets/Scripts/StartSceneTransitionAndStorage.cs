using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//used to spawn only 1 copy of SceneTransitionAndStorage 
public class StartSceneTransitionAndStorage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("SceneTransitionAndStorage") == null)
			Instantiate(Resources.Load("SceneTransitionAndStorage"));
	}
}
