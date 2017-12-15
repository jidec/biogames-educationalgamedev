﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//put on the Road prefab, extends road from xstart,zstart to xend,zend
public class RoadGenerator : MonoBehaviour {

public int xstart;
public int zstart; 
public int xend;
public int zend;

public GameObject road;
public GameObject divider;
public GameObject fencepost;

public GameObject fence;

//0, 100, 10 10
	// Use this for initialization
	void Start () {
	
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
		//fence.transform.localScale += new Vector3(0,0,1);


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

		/* 
		//add fence posts
		i = 1;
		while(i < distance)
		{
			//make two new posts at the road's start
			GameObject newfencepost = Instantiate(divider, new Vector3(xstart,0,zstart), Quaternion.identity);
			GameObject newfencepost2 = Instantiate(divider, new Vector3(xstart,0,zstart), Quaternion.identity);
			//rotate towards the end of the road
			 Vector3 relativePos = new Vector3(xend, 0, zend) - newfencepost.transform.position;
			 Quaternion rotation = Quaternion.LookRotation(relativePos);
			 newfencepost.transform.rotation = rotation;
			 newfencepost2.transform.rotation = rotation;
			//new position is the road start moved towards the end i units
			Vector3 newposition = Vector3.MoveTowards(newfencepost.transform.position, new Vector3(xend, .01f, zend),i);
			newdivider.transform.position = (newposition -= new Vector3(;
			//set the Road as parent
			newdivider.transform.parent = transform;
			i++;
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}