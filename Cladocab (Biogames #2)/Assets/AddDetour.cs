using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDetour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int rand = Random.Range(0,3);
		if(rand == 0)
		{
			GameObject detour = Resources.Load("ZigzagDetour", typeof(GameObject)) as GameObject;
		}
		else if(rand == 1)
		{

		}
	}
}
