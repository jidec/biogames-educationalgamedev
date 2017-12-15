using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//triggers organism exits and activates the next pickup collider
public class OrganismExitTriggerer : MonoBehaviour {

	public string correctorganism;

	public GameObject nextorganismpickup;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
			if(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().currentorganism == correctorganism)
			{
				GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().OrganismExit();
				if(nextorganismpickup != null)
					nextorganismpickup.SetActive(true);
			}

	}
}
