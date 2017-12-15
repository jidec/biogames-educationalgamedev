using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandedView : MonoBehaviour {

	public GameObject objecttoexpand;
	public Vector3 initialscale;
	public bool expand;
	public bool retract;
	public bool fullyexpanded;
	public bool delaying;
	public bool expandwhileinsocket;
	// Use this for initialization
	void Start () {
		initialscale = objecttoexpand.transform.localScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(expand)
		{
			if(objecttoexpand.transform.localScale.x < initialscale.x)
			{
			objecttoexpand.transform.localScale += new Vector3(.06f,.06f,0f);
			}
			else
			{
				expand = false;
				fullyexpanded = true;
			}
		}

		if(retract)
		{
			fullyexpanded = false;
			if(objecttoexpand.transform.localScale.x > 0)
			{
			objecttoexpand.transform.localScale -= new Vector3(.03f,.03f,0f);
			}
			else
				retract = false;
		}

		if(expand && retract)
		{
			expand = false;
			retract =  true;
			//expandinglewis.transform.localScale = new Vector3(0,0,0);
		}
	}

	void OnMouseEnter()
	{
		if(!expandwhileinsocket)
			startexpand();
	}

	public void startexpand()
	{
		if(!retract && !fullyexpanded)
			objecttoexpand.transform.localScale = new Vector3(0,0,0);
		objecttoexpand.SetActive(true);
		expand = true;
	}

	public void startretract()
	{
		if(!delaying)
			StartCoroutine(delayRetract());	
	}
	void OnMouseExit()
	{
		if(!expandwhileinsocket)
			startretract();
	}

	private IEnumerator delayRetract()
	{
		delaying = true;
		yield return new WaitForSeconds(5f);
		retract = true;
	}
}
