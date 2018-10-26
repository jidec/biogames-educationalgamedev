using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeModeController : MonoBehaviour {

	public List<GameObject> spawnpoints; 
	public List<string> organisms;
	public GameController controller; 

	// Use this for initialization
	void Start () {
		spawnCab();
		controller = GetComponent<GameController>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnCab()
	{
		int size = spawnpoints.Count;
		GameObject point = spawnpoints[Random.RandomRange(0,size - 1)];
		controller.playercab.transform.position = point.transform.position; 
	}

	void swapOrganism()
	{
		public void OrganismExit()
	{
		organismview.SetActive(false);
		currentorganism = "";
		organismview.GetComponent<AnimalView>().speechbubble.SetActive(true);
	}Z

		currentorganism = neworganism;
		organismview.GetComponentInChildren<AnimalView>().changeOrganism(neworganism);
	}
	}
}
