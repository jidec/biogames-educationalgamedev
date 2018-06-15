using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBoost : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().boost = false;
		}
	}
}
