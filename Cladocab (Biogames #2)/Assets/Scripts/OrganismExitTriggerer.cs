using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//triggers organism exits and activates the next pickup collider
public class OrganismExitTriggerer : MonoBehaviour {

	public string correctorganism;

	public GameObject nextorganismpickup;

	public GameObject exitspeechset; 

	public GameObject enterspeechset; 

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
				exitspeechset.GetComponent<SpeechSet>().speakFromSet(); 
				StartCoroutine(wait()); 
				GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().changeOrganism(); 
				enterspeechset.GetComponent<SpeechSet>().speakFromSet(); 
			}

	}

	public IEnumerator wait()
	{
		yield return new WaitForSeconds(10);
	}
}
