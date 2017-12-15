using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when moused over, relay information to MoleculeView
public class MoleculeViewRelay : MonoBehaviour {

public string moleculename;

 	void OnMouseEnter()
	{

		if(GameObject.FindGameObjectWithTag("MoleculeView").GetComponent<MoleculeView>().lastmousedover != gameObject)
			GameObject.FindGameObjectWithTag("MoleculeView").GetComponent<MoleculeView>().shake();
		GameObject.FindGameObjectWithTag("MoleculeView").GetComponent<MoleculeView>().lastmousedover = gameObject;
	}
}
