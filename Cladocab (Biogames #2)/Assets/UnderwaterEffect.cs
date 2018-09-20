using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterEffect : MonoBehaviour {

	public float waterlevel;
	public bool underwater; 
	public Color normalcolor;
	public Color underwatercolor; 

	// Use this for initialization
	void Start () {
		normalcolor = new Color(0.5f,0.5f,0.5f,0.5f);
		underwatercolor = new Color(0.22f,0.65f,0.77f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < waterlevel != underwater)
		{
			underwater =  transform.position.y < waterlevel;
			if(underwater) SetUnderwater ();
			if(!underwater) SetNormal();
		}
	}

	void SetNormal()
	{
		RenderSettings.fogColor = normalcolor;
		RenderSettings.fogDensity = 0.002f;
	}

	void SetUnderwater()
	{
		RenderSettings.fogColor = underwatercolor;
		RenderSettings.fogDensity = 0.03f;
	}
}
