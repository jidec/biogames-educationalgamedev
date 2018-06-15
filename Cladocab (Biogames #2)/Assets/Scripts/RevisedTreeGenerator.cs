using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

//generates roads, divergence islands, and oases
public class RevisedTreeGenerator : MonoBehaviour {

public GameObject allroads;
public GameObject roadprefab;
public GameObject divergenceisland;
public GameObject oasis;

private string[] allRoads= {
//NEW FORMAT: prevousroadindex name timeatend angle calculatedxend calculatedzend
"-1 Opisthokonta 952 90 0 0", //index 0 - Opisthokonta
"0 Animalia 0 0 0 0", //index 1- To Porifera
"0 Animalia 824 145 0 0", //index 2- To Eumetazoa
"2 Eumetazoa 0 -90 0 0", //index 3- To Cnidaria
"2 Eumetazoa 797 90 0 0", //index 4- To Bilateria
"4 Bilateria 753 180 0 0", //index 5- To Prostomia
"4 Bilateria 684 45 0 0", //index 6- To Deuterostomia
"6 Deuterostomia 473 0 0 0", //index 7- To Chordata
"6 Deuterostomia 0 90 0 0", //index 8- To Echinodermata
"5 Prostomia 743 135 0 0 0", //index 9- To Ecdysozoa
"9 Ecdysozoa 0 90 0 0 0", //index 10- To Nematoda
"9 Ecdysozoa 601 135 0 0 0", //index 11- To Arthropoda
"11 Arthropoda 0 105 0 0 0", //index 12- To Chelicerata
"11 Arthropoda 0 165 0 0 0", //index 13- To Insecta 
"5 Prostomia 688 -135 0 0 0", //index 14- To Lophotrochozoa
"14 Lophotrochozoa 0 195 0 0 0", //index 15- To Molluska
"14 Lophotrochozoa 0 260 0 0 0", //index 16- To Annelida
"7 Chordata 0 90 0 0", //index 17- To Chondrichthyes
"7 Chordata 435 0 0 0", //index 18- To Osteichthyes
"18 Osteichthyes 0 90 0 0", //index 19- To Actinopterygii
"18 Osteichthyes 352 0 0 0", //index 20- To Tetrapoda
"20 Tetrapoda 0 90 0 0", //index 21- To Sauria
"20 Tetrapoda 0 0 0 0", //index 22- To Mammalia
};

//NEW FORMAT: prevousroadindex name timeatend angle calculatedxend calculatedzend
	void Start () 
	{
		for(int i = 0;  i < allRoads.Length; i++)
		{
			//get vars from current road
			string[] vars = allRoads[i].Split(new[] {' '});
			int previousroadindex = Int32.Parse(vars[0]);
			String roadname = vars[1];
			Debug.Log(roadname);
			int timeatend = Int32.Parse(vars[2]);
			double angle = (double) Int32.Parse(vars[3]);

			//if not first road
			if(previousroadindex != -1)
			{
				//get vars from previous road
				string[] prevvars = allRoads[previousroadindex].Split(new[] {' '});
				String prevroadname = prevvars[1];
				int timeatstart = Int32.Parse(prevvars[2]);
				float xstart = float.Parse(prevvars[4]);
				float zstart = float.Parse(prevvars[5]);
				int timedifference = timeatstart - timeatend;
				
				//calculate coords for the index
				double radians = angle * Math.PI / 180;
				float xoffset = timedifference * (float) Math.Cos(radians);
				float xend = xstart + xoffset; 
				float zoffset = timedifference * (float) Math.Sin(radians);
				float zend = zstart + zoffset; 

				//place end coords and new name back in allRoads retroactively 
				vars[4] = "" + xend;
				vars[5] = "" + zend; 
				String fullname = prevroadname + "," + roadname;
				allRoads[i] = "" + previousroadindex + " " + fullname + " " + timeatend + " " + angle + " " + xend + " " + zend;
				
				//create road
				createRoad(xstart, zstart, xend, zend, fullname, timeatstart, timeatend);
			}

			//if first road
			else
			{
				//blank first road
				String prevroadname = "";
				float xstart = 0;
				float zstart = 0;
				//1105 = animal/fungi divergence
				int timeatstart = 1105;
				int timedifference = timeatstart - timeatend;
				
				//calculate coords for the index
				double radians = angle * Math.PI / 180;
				float xoffset = timedifference * (float) Math.Cos(radians);
				float xend = xstart + xoffset; 
				float zoffset = timedifference * (float) Math.Sin(radians);
				float zend = zstart + zoffset; 

				Debug.Log(timedifference + " " + xoffset + " " + zoffset);

				//place end coords and new name back in allRoads retroactively 
				vars[4] = "" + xend;
				vars[5] = "" + zend; 
				String fullname = prevroadname + "," + roadname;
				allRoads[i] = "" + previousroadindex + " " + fullname + " " + timeatend + " " + angle + " " + xend + " " + zend;
				
				//create road
				createRoad(xstart, zstart, xend, zend, fullname, timeatstart, timeatend);
			}
		}
	}

	void createRoad(float x, float z, float endx, float endz, String newname, int starttime, int timeatend)
	{
			GameObject newroad = Instantiate(roadprefab, new Vector3(x,0,z), Quaternion.identity);
			newroad.GetComponent<RoadGenerator>().xstart = x;
			newroad.GetComponent<RoadGenerator>().zstart = z;
			newroad.GetComponent<RoadGenerator>().xend = endx;
			newroad.GetComponent<RoadGenerator>().zend = endz;
			newroad.GetComponentInChildren<Road>().pathname = newname;
			newroad.GetComponentInChildren<Road>().timeatstart = starttime;
			newroad.name = newname;

			//add islands
			//must parent manually
			if(timeatend != 0)
			{
			GameObject newdivergenceisland = Instantiate(divergenceisland, new Vector3(endx, 0, endz),newroad.transform.rotation);
			}

			else
			{
			GameObject newoasis = Instantiate(oasis, new Vector3(endx, 0, endz),newroad.transform.rotation);
			}
			newroad.transform.parent = allroads.transform;
	}
}
