using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using System;

public class GameController : MonoBehaviour {

	public GameObject playercab; 
	public GameObject currentroad;

	//variables for organisms and changing organisms
	public string currentorganism;
	public GameObject organismview;
	public Stack<string> animalorder;


	//text that changes based on time
	public Text hierarchytext;
	public Text timetext;
	public Text mypstext;


	//variables for myps calculation
	public double myps;
	public double currenttime;
	public double timetraveled;
	public double prevtimedistance;


	//animal view shifting variables
	public bool viewup;
	public bool viewdown;
	public GameObject animalview;


	//boosting variables
	public GameObject boostview;
	public bool boostenabled;
	public bool boost;
	public float boostspeed;


	//warp test variables
	public Shader warpshader;
	public Camera camera;


	//UI variables
	public Vector3 animalviewposition;
	public GameObject firstpersoncam;
	public GameObject thirdpersonUI;
	public GameObject firstpersonUI;


	void Start () {
		//testing shader
		//camera.SetReplacementShader(warpshader, "t");
		//camera.gameObject.SetActive(true);
		//testing tint
		//if (RenderSettings.skybox.HasProperty("_Tint"))
         // RenderSettings.skybox.SetColor("_Tint", Color.red);
       //else if (RenderSettings.skybox.HasProperty("_SkyTint"))
         //RenderSettings.skybox.SetColor("_SkyTint", Color.red);
		animalorder = new Stack<string>();
		InvokeRepeating("updateMyps",0,1);
		animalorder.Push("CommonStarfish");
		animalorder.Push("LionsManeJellyfish");
		animalorder.Push("GiantBarrelSponge");
		animalviewposition = animalview.transform.position;
	}
	void updateMyps()
	{
		myps = timetraveled;
		timetraveled = 0;
	}

	//global adjustments and calculations in FixedUpdate
	void FixedUpdate () {

		//rotate skybox
		RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1f);
		
		//myps calculation stuff
		double timedistance = 0;
		if(currentroad != null)
			timedistance = Vector3.Distance(playercab.transform.position, new Vector3(currentroad.GetComponent<RoadGenerator>().xstart, 0, currentroad.GetComponent<RoadGenerator>().zstart));
		timetraveled += Mathf.Abs((float) timedistance - (float) prevtimedistance);
		prevtimedistance = timedistance;

		//set time, hierarchy, myps
		if(currentroad != null)
		{
			//set current time and update timetext
			if((int)(currentroad.GetComponentInChildren<Road>().timeatstart - timedistance) >= 0)
			{
				int prevtime = (int) currenttime;
				currenttime = (int)(currentroad.GetComponentInChildren<Road>().timeatstart - timedistance);
				if(currenttime != prevtime)
				{
				timetext.text = " " + currenttime + " million years ago";
				}
			}

			//set hierarchytext and myps text
			hierarchytext.text = currentroad.GetComponent<Road>().pathname;
			mypstext.text = "" + (int)(myps * 60) + " my/min";
		}
		

		if(viewup)
		{
			if(animalview.transform.position.y < 0)
			{
				animalview.transform.position += new Vector3(0,10,0);
			}
		}

		if(viewdown)
		{
			if(animalview.transform.position.y > animalviewposition.y + 10)
			{
				animalview.transform.position -= new Vector3(0,10,0);
			}
		}
	}

	//game controls in Update
	void Update()
	{
		//move up animalview with space
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(viewup == false)
			{
				viewup = true;
				viewdown = false;
			}
			else
			{
				viewup = false;
				viewdown = true;
			}
		}

		//switch between 1st and 3rd person with F
		if(Input.GetKeyDown(KeyCode.F))
		{
			if(firstpersoncam.activeSelf)
			{
				firstpersoncam.SetActive(false);
				thirdpersonUI.SetActive(true);
				firstpersonUI.SetActive(false);
			}
			else
			{
				firstpersoncam.SetActive(true);
				firstpersonUI.SetActive(true);
				thirdpersonUI.SetActive(false);
			}
		}

		//left shift to boost from end of road to last intersection
		//playercab.transform.rotation = currentroad.transform.rotation;
		//trigger to enable boost
		//boostenabled = true;

		if(Input.GetKey(KeyCode.LeftShift) && boostenabled)
		{
			boost = true;
			boostenabled = false;
			playercab.transform.position += new Vector3(0,1,0);
			playercab.transform.rotation = Quaternion.Inverse(currentroad.transform.rotation);
			playercab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
		}


		if(boost)
		{
			playercab.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, boostspeed), ForceMode.Acceleration);
			playercab.transform.rotation = Quaternion.Inverse(currentroad.transform.rotation);
			//playercab.GetComponent<CarController>().m_FullTorqueOverAllWheels = 1100f;
			//playercab.GetComponent<CarController>().m_Topspeed = 700f;
		}
		
		else
		{
			playercab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		}
	}


	//cause organism to exit: called by triggers
	public void OrganismExit()
	{
		organismview.SetActive(false);
		currentorganism = "";
		organismview.GetComponent<AnimalView>().speechbubble.SetActive(true);
	}

	//set next organism: called by triggers
	public void nextOrganism(string neworganism)
	{
		currentorganism = neworganism;
		organismview.GetComponentInChildren<AnimalView>().changeOrganism(neworganism);
	}
}
