using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDetour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject detour;
		int rand = Random.Range(0,3);
		rand = 0;
		if(rand == 0)
		{
			detour = Resources.Load("Test", typeof(GameObject)) as GameObject;
		}
		else if(rand == 1)
		{
			detour = Resources.Load("RightCurveAroundDetour", typeof(GameObject)) as GameObject;
		}
		else if(rand == 2)
		{
			detour = Resources.Load("LeftCurveUpDetour", typeof(GameObject)) as GameObject; 
		}
		else 
		{
			detour = Resources.Load("RightCurveUpDetour", typeof(GameObject)) as GameObject; 
		}
		detour = Instantiate(detour);
		detour.transform.position = this.transform.position;
		detour.transform.rotation = this.transform.rotation;
		detour.transform.parent = this.transform; 

		//also rotate whole island to road, because why not
		transform.localRotation = new Quaternion(0,0,0,0);
	}
}
