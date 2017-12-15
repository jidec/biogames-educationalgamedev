using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCollide : MonoBehaviour {

public GameObject parentroad;
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().currentroad = parentroad;
		}
	}
}
