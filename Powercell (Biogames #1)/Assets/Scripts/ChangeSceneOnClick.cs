using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour {
	public string scenetoload;

	// Use this for initialization
	void Start () {
	}

	void OnMouseDown()
	{
		Initiate.Fade(scenetoload,Color.white,.8f);
		GetComponent<CameraZoomIntoPoint>().zoom = true;
		//SceneManager.LoadScene(scenetoload);
	}

	//Returns to MitochondriaView, saving the scene beforehand
	public void backtoMito()
	{
		GameObject.FindGameObjectWithTag("SceneTransitionAndStorage").GetComponent<SceneTransitionAndStorage>().saveLevelBeforeExit();
		Initiate.Fade("mitochondriaview",Color.white,.8f);
	}
}
