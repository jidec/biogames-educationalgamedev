using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechSet: MonoBehaviour {

	public IDictionary<string, List<string>> quotestotrigger;

	//assign possible quotes for each organism in inspector 
	public List<string> GiantBarrelSponge; 
	public List<string> LionsManeJellyfish;
	public List<string> CommonStarfish; 

	private GameObject controller;
	private string currentorganism;

	void Start () {

		quotestotrigger = new Dictionary<string, List<string>>();
		quotestotrigger["GiantBarrelSponge"] = GiantBarrelSponge;
		quotestotrigger["LionsManeJellyfish"] = LionsManeJellyfish;
		quotestotrigger["CommonStarfish"] = CommonStarfish;
		controller = GameObject.FindGameObjectWithTag("GameController");
	}
	
	void Update () {
		currentorganism = controller.GetComponent<GameController>().currentorganism;
	}

	public void speakFromSet()
	{
		if(currentorganism != "")
		//If quotes remain for current organism
		if(quotestotrigger[currentorganism].Count > 0)
		{
		//random index of quotes of current organism
		int randomindex = (int) (Random.value * quotestotrigger[currentorganism].Count);
		
		//tell organism to speak
		controller.GetComponent<ConversationController>().speak(quotestotrigger[currentorganism][randomindex]);

		//remove spoken quote so it can't be repeated
		quotestotrigger[currentorganism].RemoveAt(randomindex);
		}
	}

	public void speakFirstTwoFromSet()
	{
		if(quotestotrigger[currentorganism].Count > 1)
		{
		string quote1 = quotestotrigger[currentorganism][0];
		string quote2 = quotestotrigger[currentorganism][1];
		
		//tell organism to speak
		controller.GetComponent<ConversationController>().speaktwo(quote1,quote2);

		//remove spoken quote so it can't be repeated
		quotestotrigger[currentorganism].RemoveAt(0);
		quotestotrigger[currentorganism].RemoveAt(0);
		}
	}
}
