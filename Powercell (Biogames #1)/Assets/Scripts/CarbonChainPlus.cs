using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarbonChainPlus : MonoBehaviour {

	public GameObject phosphate;
	public GameObject carbonatom;

	public GameObject hydrogentext;
	public GameObject oxygentext;

	public GameObject electrontext;

	private GameObject phosphate1;
	private GameObject phosphate2;


	public int numcarbons;
	private double currentnumcarbons = 0;
	public int numphosphates;
	private int currentnumphosphates = 0;

	public int numoxygens;

	public int numhydrogens;

	public int numelectrons;
	
	private Stack<GameObject> carbonstack = new Stack<GameObject>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		updateChain();
		updateCounts();
	}
	
	private void updateCounts()
	{
		electrontext.GetComponent<TextMeshPro>().text = "" + numelectrons;
		hydrogentext.GetComponent<TextMeshPro>().text = "" + numhydrogens;
		oxygentext.GetComponent<TextMeshPro>().text = "" + numoxygens;
	}
	private void updateChain()
	{
		//adds & updates carbons
		if (currentnumcarbons < numcarbons) 
		{
			GameObject newcarbon = Instantiate(carbonatom);
			newcarbon.SetActive (true);
			newcarbon.transform.parent = this.transform;
			newcarbon.transform.localPosition = new Vector3 (-.5f, 0, 0);
			carbonstack.Push (newcarbon);


			if (currentnumcarbons == 1)
				newcarbon.transform.localPosition += new Vector3 (1f, 0f);
			if (currentnumcarbons == 2)
				newcarbon.transform.localPosition += new Vector3 (-1f, 0f);
			if (currentnumcarbons == 3)
				newcarbon.transform.localPosition += new Vector3 (2f, 0f);
			if (currentnumcarbons == 4)
				newcarbon.transform.localPosition += new Vector3 (-2f, 0f);
			if (currentnumcarbons == 5)
				newcarbon.transform.localPosition += new Vector3 (3f, 0f);

			currentnumcarbons++;
		}

		//removes carbons
		if (currentnumcarbons > numcarbons) 
		{
			Destroy(carbonstack.Pop());
			currentnumcarbons--;
		}

		//adds phosphates
		if (currentnumphosphates < numphosphates) 
		{
			if (currentnumphosphates == 0)
			{
				phosphate1 = Instantiate (phosphate);
				phosphate1.SetActive (true);
				phosphate1.transform.parent = this.transform;
				phosphate1.transform.localPosition = new Vector3 (0, 0, 0);
			}

			if (currentnumphosphates == 1)
			{
				phosphate2 = Instantiate (phosphate);
				phosphate2.SetActive (true);
				phosphate2.transform.parent = this.transform;
				phosphate2.transform.localPosition = new Vector3 (0, 0, 0);
			}
			currentnumphosphates++;
		}

		//removes phosphates
		if (currentnumphosphates > numphosphates) 
		{
			if (currentnumphosphates == 1)
			{
				Destroy (phosphate1);
			}

			if (currentnumphosphates == 2)
			{
				Destroy (phosphate2);
			}

			currentnumphosphates--;
		}

		//updates phosphates
		if (currentnumcarbons % 2 == 0) 
		{
			if (phosphate1 != null)
				phosphate1.transform.localPosition = new Vector3 ((float)((currentnumcarbons / 2) + .5), 0f);
			if (phosphate2 != null)
				phosphate2.transform.localPosition = new Vector3 ((float)(-1 * ((currentnumcarbons / 2) + .5)), 0f);
		} 
		else 
		{
			if (phosphate1 != null)
				phosphate1.transform.localPosition = new Vector3 ((float)((currentnumcarbons / 2)), 0f);
			if (phosphate2 != null)
				phosphate2.transform.localPosition = new Vector3 ((float)(-1 + -1 * ((currentnumcarbons / 2))), 0f);
		}
			
	}
}
