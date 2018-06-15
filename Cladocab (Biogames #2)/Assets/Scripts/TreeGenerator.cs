using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
public class TreeGenerator : MonoBehaviour {

public GameObject roadprefab;
//public GameObject junctioncircle;
private string[] allPoints = {
//format: x z connectionindex1 connectionindex2 connectionindex3 connectionname1 connectionname2 connectionname3 starttime
//if a connectionindex is 0, connects to nothing 
"0 0 1 0 0 Animalia 0 0 1105", //index 0 - start
"0 153 2 3 0 Animalia,Porifera Animalia,Eumetazoa 0 952", //index 1- Porifera/Eumetazoa
"1000 153 0 0 0 0 0 0 0", //index 2- Porifera End
"-128 153 4 5 0 Animalia,Eumetazoa,Cnidaria Animalia,Eumetazoa,Bilateria 0 824", //index 3- Cnidaria/Bilateria
"-128 -824 0 0 0 0 0 0 0", //index 4- Cnidaria End
"-128 180 6 11 0 Animalia,Eumetazoa,Bilateria,Prostomia Animalia,Eumetazoa,Bilateria,Deuterostomia 0 797", //index 5- Prostomia/Deuterostomia
"-172 180 7 10 0 Animalia,Eumetazoa,Bilateria,Prostomia,Unnamed Animalia,Eumetazoa,Bilateria,Prostomia,Lophotrochozoa 0 753", //index 6- Unnamed/Lophotrochozoa
"-179 173 8 9 0 Animalia,Eumetazoa,Bilateria,Prostomia,Unnamed,Arthropoda Animalia,Eumetazoa,Bilateria,Prostomia,Unnamed,Nematoda 0 743", //index 7- Arthropoda/Nematoda
"-704 -352 0 0 0 0 0 0 0", //index 8- Arthropoda End
"-500 -352 0 0 0 0 0 0 0",	//index 9- Nematoda End 
"-346 698 0 0 0 0 0 0 0", //index 10- Lophotrochozoa (unfinished)
"-128 293 12 13 0 Animalia,Eumetazoa,Bilateria,Deuterostomia,Echinodermata Animalia,Eumetazoa,Bilateria,Deuterostomia,Chordata 0 684",  //index 11- Echinodermata/Chordata
"-128 997 0 0 0 0 0 0 0", //index 12 - Echinodermata End
"556 293 0 0 0 0 0 0 0",  //index 13 - Chordata End

	


};
	void Start () 
	{
		for(int i = 0;  i < allPoints.Length; i++)
		{
			string[] vars = allPoints[i].Split(new[] {' '});
			int x = Int32.Parse(vars[0]);
			int z = Int32.Parse(vars[1]);
			int connection1index = Int32.Parse(vars[2]);
			int connection2index = Int32.Parse(vars[3]);
			int connection3index = Int32.Parse(vars[4]);
			String connection1name = vars[5];
			String connection2name = vars[6];
			String connection3name = vars[7];
			int starttime = Int32.Parse(vars[8]);


			//if connection is valid
			if(connection1index != 0)
			{
				print("" + i);
				//get coords from the index
				string[] coords = allPoints[connection1index].Split(new[] {' '});
				int connectx = Int32.Parse(coords[0]);
				int connectz = Int32.Parse(coords[1]);
				//create road
				createRoad(x, z, connectx, connectz, connection1name, starttime);
			}

			if(connection2index != 0)
			{
				//get coords from the index
				string[] coords = allPoints[connection2index].Split(new[] {' '});
				int connectx = Int32.Parse(coords[0]);
				int connectz = Int32.Parse(coords[1]);
				//create road
				createRoad(x, z, connectx, connectz, connection2name, starttime);
			}

			if(connection3index != 0)
			{
				//get coords from the index
				string[] coords = allPoints[connection3index].Split(new[] {' '});
				int connectx = Int32.Parse(coords[0]);
				int connectz = Int32.Parse(coords[1]);
				//create road
				createRoad(x, z, connectx, connectz, connection3name, starttime);
			}
		}
	}

	void createRoad(int x, int z, int endx, int endz, String newname, int starttime)
	{
			GameObject newroad = Instantiate(roadprefab, new Vector3(x,0,z), Quaternion.identity);
			newroad.GetComponent<RoadGenerator>().xstart = x;
			newroad.GetComponent<RoadGenerator>().zstart = z;
			newroad.GetComponent<RoadGenerator>().xend = endx;
			newroad.GetComponent<RoadGenerator>().zend = endz;
			newroad.GetComponentInChildren<Road>().pathname = newname;
			newroad.GetComponentInChildren<Road>().timeatstart = starttime;
			//create junction circle
			//Instantiate(junctioncircle, new Vector3(endx, 0, endz), Quaternion.identity);
	}
}
