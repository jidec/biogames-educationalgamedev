using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeProducedRelay : MonoBehaviour {

	public int numcarbons;
	public int numphosphates;
	//num hydrogens etc...

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "MovingCarbonChain")
		{
			if(col.gameObject.GetComponent<CarbonChain>().numcarbons == numcarbons && col.gameObject.GetComponent<CarbonChain>().numphosphates == numphosphates)
			{
				GameObject.FindGameObjectWithTag("PuzzleController").GetComponent<GlycolysisController>().correctmoleculesproduced ++;
			}
		}
	}

}
