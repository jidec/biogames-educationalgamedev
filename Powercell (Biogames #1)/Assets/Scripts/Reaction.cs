using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour {

	public string isomer;
	public GameObject inputenergysocket;
	public GameObject outputenergysocket;
	public GameObject enzymesocket;
	
	public GameObject freephosphate;
	public GameObject ccprefab;
	//public GameObject movingcarbonchain;
	public bool mccpassed;
	public bool atp2adp = false;
	public bool adp2atp = false;
	public bool aldolasesplitting = false;
	public bool dehydrogenasereaction = false;
	public bool isomerasereaction = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(inputenergysocket != null && outputenergysocket != null)
		//are the sockets correct for ATP -> ADP? 
		if (inputenergysocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "ATP(Clone)" && outputenergysocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "ADP(Clone)" && enzymesocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "Kinase(Clone)")
		{
			adp2atp = false;
			aldolasesplitting = false;
			atp2adp = true;
			dehydrogenasereaction = false;
		}

		if(inputenergysocket != null && outputenergysocket != null)
		//are the sockets correct for ADP -> ATP?
		if (inputenergysocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "ADP(Clone)" && outputenergysocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "ATP(Clone)" && enzymesocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "Kinase(Clone)")
		{
			atp2adp = false;
			aldolasesplitting = false;
			adp2atp = true;
			dehydrogenasereaction = false;
		}

		//are the sockets correct for Aldolase splitting? 
		if (enzymesocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "Aldolase(Clone)")
		{
			atp2adp = false;
			adp2atp = false;
			aldolasesplitting = true;
			dehydrogenasereaction = false;
		}

		if(inputenergysocket != null && outputenergysocket != null)
		//are the sockets correct for a Dehydogenase reaction?
		if (inputenergysocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "NAD(Clone)" && outputenergysocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "NADH(Clone)" && enzymesocket.GetComponent<PuzzleSocket>().socketedmoleculename == "Dehydrogenase(Clone)")
		{
			atp2adp = false;
			adp2atp = false;
			aldolasesplitting = false;
			dehydrogenasereaction = true;

		}

		//are the sockets correct for Isomerase reaction?
		if (enzymesocket.GetComponent<PuzzleSocket> ().socketedmoleculename == "Isomerase(Clone)")
		{
			atp2adp = false;
			adp2atp = false;
			aldolasesplitting = false;
			isomerasereaction = true;
			dehydrogenasereaction = false;
		}

	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "MovingCarbonChain")
		{
			if (atp2adp == true) 
			{
				col.gameObject.GetComponent<CarbonChain>().numphosphates++;
			}
			if (adp2atp == true) 
			{
				col.gameObject.GetComponent<CarbonChain>().numphosphates--;
			}
			if (aldolasesplitting == true) 
			{
				//make new carbon chain using ccprefab
				GameObject splitchain = Instantiate(ccprefab, new Vector3 (col.gameObject.transform.position.x, col.gameObject.transform.position.y - (float) 4.2,4), Quaternion.identity);
				//remove half of carbons and phosphates
				col.gameObject.transform.position = new Vector3 (col.gameObject.transform.position.x, col.gameObject.transform.position.y + (float) 3.3, 4);
				col.gameObject.GetComponent<CarbonChain> ().numcarbons = (col.gameObject.GetComponent<CarbonChain> ().numcarbons) / 2;
				col.gameObject.GetComponent<CarbonChain> ().numphosphates = (col.gameObject.GetComponent<CarbonChain> ().numphosphates) / 2;

				//set tag 
				splitchain.tag = "MovingCarbonChain";
				splitchain.GetComponent<CarbonChain> ().numcarbons = 3;
				splitchain.GetComponent<CarbonChain> ().numphosphates = 1;
				print (splitchain.GetComponent<CarbonChain> ().numcarbons);
				GameObject.FindGameObjectWithTag("PuzzleController").GetComponent<GlycolysisController>().splitinputmolecule = splitchain;
			}
			if(dehydrogenasereaction)
			{
				col.gameObject.GetComponent<CarbonChain>().numphosphates++;
				//TODO trigger phosphate to move in
				if(freephosphate != null)
				{
					freephosphate.SetActive(false);
					StartCoroutine(phosphateReappear());
				}
			}
			if(isomerasereaction)
			{
				col.gameObject.GetComponent<CarbonChain>().currentisomer = isomer;
			}
		}
	}

	public IEnumerator phosphateReappear()
	{
		yield return new WaitForSeconds(3);
		freephosphate.SetActive(true);
	}
}
