using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfMolecule : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//On mouse enter, send molecule to moleculeview
	void OnMouseEnter()
	{
		print("entered");
		GameObject.FindGameObjectWithTag("MoleculeView").GetComponent<MoleculeView>().lastmousedover = gameObject;
	}

	//On mouse click, spawn the draggable molecule on the cursor
	void OnMouseClick()
	{
		print("clicked");
		GameObject newmolecule = Instantiate((GameObject) Resources.Load(gameObject.name), gameObject.transform.position, Quaternion.identity);
		newmolecule.GetComponent<Draggable>().target = newmolecule;
		newmolecule.GetComponent<Draggable>()._mouseState = true;
	}
}
