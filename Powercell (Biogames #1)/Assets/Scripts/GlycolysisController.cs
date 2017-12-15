using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GlycolysisController : MonoBehaviour {

	public int currentnetATP;
	public int currentnetNADH;
	public bool movemolecule;
	public bool justmoved;
	public bool isfructose; 

	public GameObject inputmolecule;
	public GameObject splitinputmolecule;
	public Vector3 inputstartpos;
	public int inputstartcarbons;
	public int inputstartphosphates;

	public int initialkinases;
	public int initialdehyds;
	public int initialalds;
	public int initialATP;
	public int initialADP;
	public int initialNAD;
	public int initialNADH;

	public int initialisoms;
	public GameObject uicanvas;

	public GameObject productioncanvas;
	public GameObject netATPtext;
	public GameObject netNADHtext;

	public GameObject outputmoleculetext;
	public int correctmoleculesproduced;

	public int prevnetatp;
	public int prevnetnadh;
	public int prevpyruvates;

	// Use this for initialization
	void Start () {
		uicanvas = GameObject.FindGameObjectWithTag ("UICanvas");

		//generates all movable molecules assigned in inspector
		generateMovables("Kinase", initialkinases);
		generateMovables("Dehydrogenase", initialdehyds);
		generateMovables("Aldolase", initialalds);
		generateMovables("ATP", initialATP);
		generateMovables("ADP", initialADP);
		generateMovables("NAD", initialNAD);
		generateMovables("NADH", initialNADH);
		generateMovables("Isomerase", initialisoms);

		correctmoleculesproduced = 0;
		inputstartpos = inputmolecule.transform.position;
	}

	//maybe add position as input?
	public void generateMovables(string movablename, int num2spawn)
	{
		if(Resources.Load(movablename) != null)
		for (int i = 0; i < num2spawn; i++) 
		{
			//instantiate in the center of the camera
			float xoffset = Random.value * 3;
			float yoffset = Random.value * 3;
			Vector3 cameraposition = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x + 5 + xoffset,GameObject.FindGameObjectWithTag("MainCamera").transform.position.y - 4 + yoffset, 3);
			Instantiate ((GameObject) Resources.Load (movablename), cameraposition, Quaternion.identity);
			
		}
	}

	// Update is called once per frame
	void Update () {

		updateGUI();

		//deals with MovingCarbonChain movement 
		if (Input.GetKey (KeyCode.Space)) 
		{
			movemolecule = true;
			inputstartcarbons = 6;
			inputstartphosphates = 0;
			justmoved = true;
		}

		if (movemolecule)
		{
			inputmolecule.transform.position += new Vector3 (.1f, 0f);

			if(splitinputmolecule != null)
				splitinputmolecule.transform.position += new Vector3 (.1f, 0f);
		}

		if(!movemolecule && justmoved)
		{	
			inputmolecule.GetComponent<CarbonChain>().currentisomer = "";
			inputmolecule.transform.position = inputstartpos;
			if(splitinputmolecule != null)
				Destroy (splitinputmolecule);
			inputmolecule.GetComponent<CarbonChain> ().numcarbons = 6;
			inputmolecule.GetComponent<CarbonChain> ().numphosphates = 0;
			justmoved = false;
		}
	}

	public void updateGUI()
	{
		int newnetATP = 0;
		int newnetNADH = 0;

		//for every socket
		foreach (GameObject g in GameObject.FindGameObjectsWithTag ("Socket")) 
		{
			//if it has a molecule
			if (g.GetComponent<PuzzleSocket> ().socketedmolecule != null)
			{
				//if molecule is ATP or NADH
				if (g.GetComponent<PuzzleSocket> ().socketedmolecule.name == "ATP(Clone)") 
				{
					//adds to net if in output socket, subtracts if in input
					if (g.GetComponent<PuzzleSocket> ().socketname == "EnergyOutput")
						newnetATP++;
					else if (g.GetComponent<PuzzleSocket> ().socketname == "EnergyInput")
						newnetATP--;
				}

				if (g.GetComponent<PuzzleSocket> ().socketedmolecule.name == "NADH(Clone)")
				{
					if (g.GetComponent<PuzzleSocket> ().socketname == "EnergyOutput")
						newnetNADH++;
					else if (g.GetComponent<PuzzleSocket> ().socketname == "EnergyInput")
						newnetNADH--;
				}
			}
		}
			
		currentnetATP = newnetATP;
		currentnetNADH = newnetNADH;

		//if(newnetATP != prevnetatp || newnetNADH != prevnetnadh || correctmoleculesproduced != prevpyruvates)
			//productioncanvas.GetComponent<UIShake>().shake = true;

			
		netATPtext.GetComponent<Text> ().text = "" + currentnetATP + "/2";
		netNADHtext.GetComponent<Text> ().text = "" + currentnetNADH + "/2";
		outputmoleculetext.GetComponent<Text>().text = "" + correctmoleculesproduced;

		prevnetatp = currentnetATP;
		prevnetnadh = currentnetNADH;
		prevpyruvates = correctmoleculesproduced;
	}

	//Called to play sounds by loading the given sound name from Resources
	public void playSound(string soundname)
	{
		GetComponent<AudioSource> ().PlayOneShot ((AudioClip) Resources.Load (soundname));
	}
}
