using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainChecker : MonoBehaviour {

	private GameObject PuzzleController;
	//the number of each molecule to spawn when the chain matches and the threshold is successfully passed
	public bool spawnedalready;
	public int kinases2spawn;
	public int alds2spawn;
	public int dehyds2spawn;

	public int isoms2spawn;
	public int ATP2spawn;
	public int ADP2spawn;
	public int NAD2spawn;
	public int NADH2spawn;

	public string isomertomatch;

	// Use this for initialization
	void Start () {
		PuzzleController = GameObject.FindGameObjectWithTag ("PuzzleController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		print("collided"); 
		if (col.gameObject.tag == "MovingCarbonChain") 
		{
			print("collidedwithtag");
			//if the moving carbon chain doesn't match the intermediate...
			if ((GetComponent<CarbonChain> ().numcarbons != col.gameObject.GetComponent<CarbonChain> ().numcarbons) || (GetComponent<CarbonChain> ().numphosphates != col.gameObject.GetComponent<CarbonChain> ().numphosphates || col.gameObject.GetComponent<CarbonChain>().currentisomer != isomertomatch)) {
				print("doesntmatch");
				//tell puzzle controller to stop the molecule and return it to its start
				PuzzleController.GetComponent<GlycolysisController>().movemolecule = false;

				//flash red
				foreach(SpriteRenderer r in gameObject.GetComponentsInChildren<SpriteRenderer>())
				{
					StartCoroutine (flashred(r));
				}
			}

			//otherwise it matches! if hasn't spawned yet, tell puzzle controller to spawn molecules assigned in inspector
			else 
			{
				col.gameObject.GetComponent<CarbonChain>().currentisomer = "";
				foreach(SpriteRenderer r in gameObject.GetComponentsInChildren<SpriteRenderer>())
				{
					StartCoroutine (flashgreen(r));
				}

				if (!spawnedalready) 
				{
					PuzzleController.GetComponent<GlycolysisController> ().generateMovables ("Kinase", kinases2spawn);
					PuzzleController.GetComponent<GlycolysisController> ().generateMovables ("Aldolase", alds2spawn);
					PuzzleController.GetComponent<GlycolysisController> ().generateMovables ("Dehydrogenase", dehyds2spawn);
					PuzzleController.GetComponent<GlycolysisController> ().generateMovables ("ATP", ATP2spawn);
					PuzzleController.GetComponent<GlycolysisController> ().generateMovables ("ADP", ADP2spawn);
					PuzzleController.GetComponent<GlycolysisController> ().generateMovables ("NAD", NAD2spawn);
					PuzzleController.GetComponent<GlycolysisController> ().generateMovables ("NADH", NADH2spawn);
					PuzzleController.GetComponent<GlycolysisController> ().generateMovables ("Isomerase", isoms2spawn);
					spawnedalready = true;
				}
			}
		}
	}

	IEnumerator flashred(SpriteRenderer r)
	{
		Color initial = r.color;
		r.color = Color.red;
		yield return new WaitForSeconds(0.02f);
		r.color = initial;
	}

	IEnumerator flashgreen(SpriteRenderer r)
	{
		Color initial = r.color;
		r.color = Color.green;
		yield return new WaitForSeconds(0.02f);
		r.color = initial;
	}
}
