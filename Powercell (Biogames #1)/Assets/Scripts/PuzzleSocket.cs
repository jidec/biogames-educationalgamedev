using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSocket : MonoBehaviour {

	public string socketname;
	public string socketedmoleculename;
	public GameObject socketedmolecule;
	
	// Update is called once per frame
	void Update () {
		if (socketedmolecule != null) 
			{
			socketedmoleculename = socketedmolecule.name;
			}
	}
}
