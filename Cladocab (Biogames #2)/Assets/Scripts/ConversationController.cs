using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//called to speak through triggers, also randomly speaks random quotes for each organism
public class ConversationController : MonoBehaviour {

	public SpeechSet randomquotes;

	public SpeechSet entrancequotes;

	public SpeechSet exitquotes; 
	
	private string currentorganism;
	public GameObject textbubble;
	bool currentlyspeaking;

	void Start () {
		InvokeRepeating("rollforspeech",10,20);
	}
	
	// Update is called once per frame
	void Update () {
	}

	//after 10s and every 20s, 50% chance for current organism to speak a random quote
	void rollforspeech()
	{
		if(Random.value > .5)
		{
			if(!currentlyspeaking)
				//call the randomquotes SpeechSet
				randomquotes.speakFromSet();
		}
	}


	//call speak(randomQuote(sponge))
	//or call speak(quote)
	public void speak(string quote)
	{
		textbubble.GetComponentInChildren<Text>().text = quote;
		textbubble.SetActive(true);
		currentlyspeaking = true;
		StartCoroutine(wait(null));
	}

	//speak two quotes in a row
	public void speaktwo(string quote1, string quote2)
	{
		textbubble.GetComponentInChildren<Text>().text = quote1;
		textbubble.SetActive(true);
		currentlyspeaking = true;
		StartCoroutine(wait(quote2));
	}

	//wait to turn off speech bubble
	//speak second quote after waiting if secondquote isn't null
	public IEnumerator wait(string secondquote)
	{
		yield return new WaitForSeconds(10);
		textbubble.SetActive(false);
		currentlyspeaking = false;
		if(secondquote != null)
			speak(secondquote);
	}
}
