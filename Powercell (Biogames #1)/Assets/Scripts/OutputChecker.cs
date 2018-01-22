using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputChecker : MonoBehaviour {

	//if the molecule reaches this it is correct
	//update the controller and scene transition then send the molecule back
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "MovingCarbonChain")
		{
			GameObject.FindGameObjectWithTag("PuzzleController").GetComponent<GlycolysisController>().correctmoleculesproduced = 2;
			GameObject.FindGameObjectWithTag("PuzzleController").GetComponent<GlycolysisController>().movemolecule = false;
			GameObject.FindGameObjectWithTag("SceneTransitionAndStorage").GetComponent<SceneTransitionAndStorage>().glycolysispyruvateproduced = true;
		}
	}
}
