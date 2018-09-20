using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//extends road from xstart,zstart to xend,zend
//also adds islands along the road at times specified in the inspector table
public class RoadGenerator : MonoBehaviour {

public float xstart;
public float zstart; 
public float xend;
public float zend;

public GameObject road;
public GameObject divider;
public GameObject fencepost;
public GameObject fenceleft;
public GameObject fenceright;

//vars for adding islands 
public int starttime;

public GameObject crowngroupisland;
public int[] crowngrouptimes;
public GameObject geologicislandprefab;
public int[] geologicislandtimes;
public GameObject lifeislandprefab;
public int[] lifeislandtimes;
public bool alreadygenerated;

//0, 100, 10 10
	// Use this for initialization
	void Start () {
		if(!alreadygenerated)
			generate();
		else
			addRoadIslands();
	}
	
	public void generate()
	{
		starttime = GetComponent<Road>().timeatstart;
		float distance = Mathf.Sqrt((xstart-xend)*(xstart-xend)+(zstart-zend)*(zstart-zend));
		
		//place in between points
		float xmidpoint = ((xstart + xend) / 2);
		float zmidpoint = ((zstart + zend) / 2);
		transform.position = new Vector3(xmidpoint,0, zmidpoint);

		//rotate towards end point
		this.transform.rotation = Quaternion.LookRotation(new Vector3(xend, 0, zend) - transform.position);

		//expand road and fence by z axis to meet points
		road.transform.localScale = new Vector3(road.transform.localScale.x, road.transform.localScale.y, distance / 2);

		//subtract 1 from the fence z
		//fenceleft.transform.localScale -= new Vector3(0,0,.01f);
		//fenceright.transform.localScale -= new Vector3(0,0,.01f);


		//add dividers
		float i = 1;
		while(i < distance)
		{
			//make new divider at the road's start
			GameObject newdivider = Instantiate(divider, new Vector3(xstart,0,zstart), Quaternion.identity);
			//rotate towards the end of the road
			 Vector3 relativePos = new Vector3(xend, 0, zend) - newdivider.transform.position;
			 Quaternion rotation = Quaternion.LookRotation(relativePos);
			 newdivider.transform.rotation = rotation;
			//new position is the road start moved towards the end i units
			Vector3 newposition = Vector3.MoveTowards(newdivider.transform.position, new Vector3(xend, .01f, zend),i);
			newdivider.transform.position = newposition;
			//set the Road as parent
			newdivider.transform.parent = transform;
			i++;
		}

		
		//add fence posts
		i = 1;
		while(i < distance)
		{
			//make two new posts at the road's start
			GameObject newfencepost = Instantiate(fencepost, new Vector3(xstart,0,zstart), Quaternion.identity);
			GameObject newfencepost2 = Instantiate(fencepost, new Vector3(xstart,0,zstart), Quaternion.identity);
			//rotate towards the end of the road
			 Vector3 relativePos = new Vector3(xend, 0, zend) - newfencepost.transform.position;
			 Quaternion rotation = Quaternion.LookRotation(relativePos);
			 newfencepost.transform.rotation = rotation;
			 newfencepost2.transform.rotation = rotation;
			//new position is the road start moved towards the end i units
			Vector3 newposition = Vector3.MoveTowards(newfencepost.transform.position, new Vector3(xend, .01f, zend),i);
			newfencepost.transform.position = newposition;
			newfencepost2.transform.position = newposition;
			//set the Road as parent
			newfencepost.transform.parent = transform;
			newfencepost2.transform.parent = transform;
			newfencepost.transform.localPosition -= new Vector3(-.85f,1.7f);
			newfencepost2.transform.localPosition -= new Vector3(.85f,1.7f);
			i+=8;
		}

		alreadygenerated = true;
	}

	public void addRoadIslands()
	{
		//add crown group islands
		for(int k = 0; k < crowngrouptimes.Length; k++)
		{
			int timedifference = starttime - crowngrouptimes[k];
			GameObject newisland = Instantiate(crowngroupisland, new Vector3(xstart,0,zstart),Quaternion.identity);
			//rotate towards the end of the road
			 Vector3 relativePos = new Vector3(xend, 0, zend) - newisland.transform.position;
			 Quaternion rotation = Quaternion.LookRotation(relativePos);
			 newisland.transform.rotation = rotation;
			
			//new position is the road start moved towards the end i units
			Vector3 newposition = Vector3.MoveTowards(newisland.transform.position, new Vector3(xend, 0, zend),timedifference);
			newisland.transform.position = newposition;
			//set the Road as parent
			newisland.transform.parent = transform;
			newisland.transform.rotation = this.transform.rotation;
			newisland.transform.rotation *= Quaternion.Euler(0,90f,0);
		}

		//add geologic islands
		for(int k = 0; k < geologicislandtimes.Length; k++)
		{
			int timedifference = starttime - geologicislandtimes[k];
			GameObject newisland = Instantiate(geologicislandprefab, new Vector3(xstart,0,zstart),Quaternion.identity);
			//rotate towards the end of the road
			 Vector3 relativePos = new Vector3(xend, 0, zend) - newisland.transform.position;
			 Quaternion rotation = Quaternion.LookRotation(relativePos);
			 newisland.transform.rotation = rotation;
			
			//new position is the road start moved towards the end i units
			Vector3 newposition = Vector3.MoveTowards(newisland.transform.position, new Vector3(xend, 0, zend),timedifference);
			newisland.transform.position = newposition;
			
			//set the Road as parent
			newisland.transform.parent = transform;
			newisland.transform.rotation = this.transform.rotation;
			newisland.transform.rotation *= Quaternion.Euler(0,90f,0);
		}

		//add life islands
		for(int k = 0; k < lifeislandtimes.Length; k++)
		{
			int timedifference = starttime - lifeislandtimes[k];
			GameObject newisland = Instantiate(lifeislandprefab, new Vector3(xstart,0,zstart),Quaternion.identity);
			//rotate towards the end of the road
			 Vector3 relativePos = new Vector3(xend, 0, zend) - newisland.transform.position;
			 Quaternion rotation = Quaternion.LookRotation(relativePos);
			 newisland.transform.rotation = rotation;
			
			//new position is the road start moved towards the end i units
			Vector3 newposition = Vector3.MoveTowards(newisland.transform.position, new Vector3(xend, 0, zend),timedifference);
			newisland.transform.position = newposition;
			
			//set the Road as parent
			newisland.transform.parent = transform;
			newisland.transform.rotation = this.transform.rotation;
			newisland.transform.rotation *= Quaternion.Euler(0,90f,0);
		}
	}
	// Update is called once per frame
	/* 
	void Update () {
		if(prevxend != xend || prevxstart != xstart || prevzend != zend || prevxend != xend)
			generate();
	}
	*/
}
