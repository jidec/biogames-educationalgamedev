using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MitochondriaViewController : MonoBehaviour {

	public GameObject totalATPtext;
	public GameObject glycolysisATPtext;
	public GameObject glycolysisNADHtext;

	public GameObject glucose;
	public GameObject pyruvate;

	public GameObject glycolysisATP;
	
	//public GameObject glycolysisNADH;

	//public GameObject glycolysisp

	public SceneTransitionAndStorage storage; 

	// Use this for initialization
	void Start () {
		storage = GameObject.FindGameObjectWithTag("SceneTransitionAndStorage").GetComponent<SceneTransitionAndStorage>();
	}
	
	// Update is called once per frame
	void Update () {
		totalATPtext.GetComponent<TextMesh>().text = "" + storage.glycolysisATPproducts + "/32";
		glycolysisATPtext.GetComponent<TextMesh>().text = "" + storage.glycolysisATPproducts;
		glycolysisNADHtext.GetComponent<TextMesh>().text = "" + storage.glycolysisNADHproducts;
		if(storage.glycolysisATPproducts > 0)
			glycolysisATP.SetActive(true);
		//if(storage.glycolysisNADHproducts > 0)
			//glycolysisNADH.SetActive(true);
		if(storage.glycolysispyruvateproduced)
			pyruvate.SetActive(true);
	}
}
