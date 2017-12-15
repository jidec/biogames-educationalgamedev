using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleStateStorage : MonoBehaviour {

	//Lists of Tuples for each puzzle with all gameobjects for the puzzle and their positions
	//List<Tuple<GameObject, Vector3>> glycolysismovables;
	public List<GameObject> glycolysismovables;
	List<Tuple<GameObject, string>> glycolysissockets;

	string prevscenename;
	bool justchangedscene; 

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {

		string scenename = SceneManager.GetActiveScene().name;
		if(scenename != prevscenename)
			justchangedscene = true;
		prevscenename = scenename;

		//If in Glycolysis...
		if(scenename == "GlycolysisPrototype3")
		{	
			print("in glycolysis");
			//If just changed scene
			if(justchangedscene)
			{
				print("justchangedscene");
				//Instantiate all gameobjects at saved positions
				foreach(GameObject g in glycolysismovables)
				{
					Instantiate(g, g.transform);
				}
				justchangedscene = false;
			}

			//For every MovableMolecule in the scene
			foreach(GameObject g in GameObject.FindGameObjectsWithTag("MovablePowersource"))
			{
				print(GameObject.FindGameObjectsWithTag("MovablePowersource").Length);
				//See if it doesn't match an object already in the list
				foreach(GameObject g2 in glycolysismovables)
				{
					if(!g.Equals(g2))
						glycolysismovables.Add(g);
				}
			}
		}
	}
}
