using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionAndStorage : MonoBehaviour {

	private string prevscenename;
	public GameObject currentcontroller;
	public int glycolysisATPproducts;
	public int glycolysisNADHproducts;
	public bool glycolysispyruvateproduced;
	private string glycolysissave;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	void Update () {
		
		currentcontroller = GameObject.FindGameObjectWithTag("PuzzleController");
		//When the scene changes, loads the saved state for new scene
		string scenename = SceneManager.GetActiveScene().name;
		if(scenename != prevscenename)
		{
			if(scenename == "glycolysis" && glycolysissave != null)
				LevelSerializer.LoadSavedLevel(glycolysissave);
			currentcontroller = GameObject.FindGameObjectWithTag("PuzzleController");
		}
		prevscenename = scenename;

		if(SceneManager.GetActiveScene().name == "glycolysis")
			updateGlycolysis();
	}

	//Called by the exit puzzle button
	//Saves the scene before the scene transition occurs
	public void saveLevelBeforeExit()
	{
		string scenename = SceneManager.GetActiveScene().name;
		if(scenename == "glycolysis")
		{
			glycolysissave = LevelSerializer.SerializeLevel();
		}
	}

	//get current glycolysis products from controller
	public void updateGlycolysis()
	{
		glycolysisATPproducts = currentcontroller.GetComponent<GlycolysisController>().currentnetATP;
		glycolysisNADHproducts = currentcontroller.GetComponent<GlycolysisController>().currentnetNADH;
	}
}
