using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeView : MonoBehaviour {

	//when a GameObject with MoleculeViewRelay is moused over, it is sent here
	public GameObject lastmousedover;
	public bool hasshaken;
	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {

		//for every image set, which will be children of MoleculeView...
		foreach (Transform child in transform) 
		{
			//if image set name matches the name of the moused over molecule
			if(lastmousedover != null)
			if (child.gameObject.name + "(Clone)" == lastmousedover.name) 
			{
				//move to front of UI
				child.transform.SetAsLastSibling ();
			}
		}
	}

	//Called once by MoleculeViewRelay 
	public void shake()
	{
		foreach (Transform child in transform) 
		{
			child.GetComponent<UIShake>().shake = true;
		}
	}
}
