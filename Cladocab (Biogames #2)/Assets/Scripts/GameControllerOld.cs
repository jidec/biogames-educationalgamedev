using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class GameControllerOld : MonoBehaviour {

	public GameObject playercab; 
	public GameObject currentroad;

	public string currentorganism;

	public GameObject organismview;

	public Text hierarchytext;
	public Text timetext;

	public Text mypstext;

	public double myps;

	public double currenttime;
	public double timetraveled;

	public double prevtimedistance;

	//an array of o2 percentages with the array index corresponding to the geologic time
	public double[] o2attime = new double[1500];

	//an array of co2 percentages with the array index corresponding to the geologic time
	public double[] co2attime = new double[1500];

	//an array of sea levels with the array index corresponding to the geologic time
	public double[] sealevelsattime = new double[1500];

	public bool viewup;
	public bool viewdown;
	public GameObject animalview;

	public GameObject boostview;

	public bool boostenabled;
	public Stack<string> animalorder;

	public float boostspeed;

	// Use this for initialization
	void Start () {
		animalorder = new Stack<string>();
		InvokeRepeating("updateMyps",0,1);
		animalorder.Push("CommonStarfish");
		animalorder.Push("LionsManeJellyfish");
		animalorder.Push("GiantBarrelSponge");
	}
	void updateMyps()
	{
		myps = timetraveled;
		timetraveled = 0;
	}

	void FixedUpdate () {
		
		//myps calculation stuff
		double timedistance = 0;
		if(currentroad != null)
			timedistance = Vector3.Distance(playercab.transform.position, new Vector3(currentroad.GetComponent<RoadGenerator>().xstart, 0, currentroad.GetComponent<RoadGenerator>().zstart));
		timetraveled += Mathf.Abs((float) timedistance - (float) prevtimedistance);
		prevtimedistance = timedistance;
		
		//avoid errors
		if(currentroad != null)
		{
			//set current time and update timetext
			if((int)(currentroad.GetComponentInChildren<Road>().timeatstart - timedistance) >= 0)
			{
				currenttime = (int)(currentroad.GetComponentInChildren<Road>().timeatstart - timedistance);
				timetext.text = " " + currenttime + " million years ago";
			}

			//set hierarchytext and myps text
			hierarchytext.text = currentroad.GetComponent<Road>().pathname;
			mypstext.text = "" + (int)(myps * 60) + " mypm (millions of years per min)";
		}

		if(currenttime < 800)
			boostenabled = true;
		else
			boostenabled = false;

		if(boostenabled)
			boostview.SetActive(true);
		else
			boostview.SetActive(false);
			
		//boost with shift
		if(Input.GetKey(KeyCode.LeftShift))
		{
			if(boostenabled)
			{
			playercab.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,0, boostspeed), ForceMode.Acceleration);
			playercab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
			//playercab.GetComponent<CarController>().m_FullTorqueOverAllWheels = 1100f;
			//playercab.GetComponent<CarController>().m_Topspeed = 700f;
			}
		}

		//unboost
		if(Input.GetKeyUp(KeyCode.LeftShift))
		{
			playercab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
			//playercab.GetComponent<CarController>().m_FullTorqueOverAllWheels = 110f;
			//playercab.GetComponent<CarController>().m_Topspeed = 200f;
		}

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

		if(viewup)
		{
			if(animalview.transform.position.y < 0)
			{
				animalview.transform.position += new Vector3(0,10,0);
			}
		}

		if(viewdown)
		{
			if(animalview.transform.position.y > -435)
			{
				animalview.transform.position -= new Vector3(0,10,0);
			}
		}
	}


	//called by triggers
	public void OrganismExit()
	{
		organismview.SetActive(false);
		currentorganism = "";
		organismview.GetComponent<AnimalView>().speechbubble.SetActive(true);
	}

	//called by triggers
	public void nextOrganism(string neworganism)
	{
		currentorganism = neworganism;
		organismview.GetComponentInChildren<AnimalView>().changeOrganism(neworganism);
	}
}
