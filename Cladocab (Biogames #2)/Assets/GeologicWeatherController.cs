using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using System;

public class GeologicWeatherController : MonoBehaviour {

	//text that changes based on time
	public Text sealeveltext;
	public Text o2text;
	public Text co2text;
	public Text temperaturetext;

	//arrays of paleochronology data
	public double[] o2attime = new double[1500];
	public double[] co2attime = new double[1000];
	public double[] sealevelsattime = new double[1500];
	public double[] temperatureattime = new double[1500];

	//era and eon
	public Text eratext;
	public Text periodtext;
	public Text Pdescription;
	public Text Edescription;

	//geologic weather variables
	public GameObject co2smoke;
	public Skybox tempsky;
	public Color coolest;
	public Color unknowntemp;
	public float lowestsealevel; 
	public float sealevelmultiplier;
	public float co2multiplier;
	public GameObject sea;
	public GameObject seashader;
	public Color icecolor; 
	public GameObject ice;
	public GameObject snow;
	public GameObject meteors;

	public bool underwater; 

	//vars from main GameController
	public int currenttime;
	public bool boostenabled; 
	public GameObject playercab; 


	// Use this for initialization
	void Start () {
		setPaleoData();
		playercab = this.GetComponent<GameController>().playercab;
	}

	void FixedUpdate()
	{
		currenttime = (int) this.GetComponent<GameController>().currenttime;
		boostenabled = this.GetComponent<GameController>().boostenabled;  
		updateGeologic();
		
	}

	public void updateGeologic()
	{
		//set period and era
		//set o2, co2, temp, sea level by finding closest higher and lower values in the tables and linearly calculating the average
		//also glaciations/extinctions etc
			double currenttime = this.GetComponent<GameController>().currenttime;

			//Geologic eras and periods
			if((int) currenttime < 1600 && (int) currenttime >= 1000)
			{
				eratext.text = "Mesoproterozoic";
			}

			else  if((int) currenttime < 1000 && (int) currenttime >= 541)
			{
				eratext.text = "Neoproterozoic";
				Edescription.text = "";
				if((int) currenttime < 1000 && (int) currenttime >= 850)
				{
					periodtext.text = "Tonian";
					Pdescription.text = "The mysterious time of the earliest animals";
				}
				else if((int) currenttime < 850 && (int) currenttime >= 635)
				{
					periodtext.text = "Cryogenian";
					Pdescription.text = "The time of Earth's largest glaciations";
				}
				else if((int) currenttime < 635 && (int) currenttime >= 541)
				{
					periodtext.text = "Ediacaran";
					Pdescription.text = "The first fossil appearance of complex animals";
				}
			}

			else if((int) currenttime < 541 && (int) currenttime >= 251)
			{
				eratext.text = "Paleozoic";
				Edescription.text = "Dramatic evolutionary radiation";
				if((int) currenttime < 541 && (int) currenttime >= 485)
				{
					periodtext.text = "Cambrian";
					Pdescription.text = "The rapid diversification of life as we know it";
				}
				else if((int) currenttime < 485 && (int) currenttime >= 443)
				{
					periodtext.text = "Ordovician";
					Pdescription.text = "Continued oceanic diversification, mollusks and arthropods flourish";
				}
				else if((int) currenttime < 443 && (int) currenttime >= 419)
				{
					periodtext.text = "Silurian";
					Pdescription.text = "First fish with jaws and bones appear";
				}
				else if((int) currenttime < 419 && (int) currenttime >= 358)
				{
					periodtext.text = "Devonian";
					Pdescription.text = "For the first time, plants and legged fish reach the land";
				}
				else if((int) currenttime < 358 && (int) currenttime >= 298)
					periodtext.text = "Carboniferous";
				else if((int) currenttime < 298 && (int) currenttime >= 252)
					periodtext.text = "Permian";
			}

			else if((int) currenttime < 251 && (int) currenttime >= 66)
			{
				eratext.text = "Mesozoic";
				Edescription.text = "Reptiles evolve and dominate the land";
				if((int) currenttime < 251 && (int) currenttime >= 201)
					periodtext.text = "Triassic";
				else if((int) currenttime < 201 && (int) currenttime >= 145)
					periodtext.text = "Jurassic";
				else if((int) currenttime < 145 && (int) currenttime >= 66)
					periodtext.text = "Cretaceous";
			}

			else if((int) currenttime < 66)
			{
				eratext.text = "Cenozoic";
				Edescription.text = "Mammals and plants change as the dawn of humans approaches";
				if((int) currenttime < 66 && (int) currenttime >= 23)
					periodtext.text = "Paleogene";
				else if((int) currenttime < 23 && (int) currenttime >= 3)
					periodtext.text = "Neogene";
				else if((int) currenttime < 3)
					periodtext.text = "Quaternary";
			}

			//SNOWBALL EARTHS
			//Marinoan snowball earth
			if((int) currenttime <= 650 && (int) currenttime >= 635 && !boostenabled)
			{
				ice.SetActive(true);
				//snow.SetActive(true);
				playercab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
				//playercab.GetComponent<CarController>().m_FullTorqueOverAllWheels = 50;
				//playercab.GetComponent<CarController>().m_ReverseTorque = 10;
				//playercab.GetComponent<CarController>().m_MaximumSteerAngle = 5;
				//playercab.GetComponent<CarController>().m_Topspeed = 75;
			}
			else if(ice.activeSelf)
			{
				ice.SetActive(false);
				//snow.SetActive(false);
				playercab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				//playercab.GetComponent<CarController>().m_FullTorqueOverAllWheels = 110;
				//playercab.GetComponent<CarController>().m_ReverseTorque = 20;
				//playercab.GetComponent<CarController>().m_MaximumSteerAngle = 10;
				//playercab.GetComponent<CarController>().m_Topspeed = 200;
			}

			//EXTINCTIONS
			//KT extinction
			if((int) currenttime <= 66 && (int) currenttime >= 63 && !boostenabled)
			{
				//meteors.SetActive(true);
				playercab.GetComponent<Rigidbody>().mass = 4000;

			}
			/* 
			else if(meteors.activeSelf)
			{
				//meteors.SetActive(false);
				playercab.GetComponent<Rigidbody>().mass = 1000;
			}
			*/
			

			//End Permian extinction
			if((int) currenttime <= 251 && (int) currenttime >= 248 && !boostenabled)
			{
				//meteors.SetActive(true);
				playercab.GetComponent<Rigidbody>().mass = 4000;
				playercab.GetComponent<Rigidbody>().drag = 1;
				co2smoke.SetActive(true);


			}
			else if(co2smoke.activeSelf)
			{
				co2smoke.SetActive(false);
				playercab.GetComponent<Rigidbody>().mass = 1000;
				playercab.GetComponent<Rigidbody>().drag = 0.1f;
			}

			//CO2 LEVEL
			int time = (int) currenttime;
			//if time unknown
			if(time > 570)
			{
				co2text.text = "ppm Co2: ???";
				//co2smoke...
			}
			//otherwise time is known
			else
			{
				double finalval = 0;
				//if exact time in table
				if(co2attime[time] != 0)
				{
					finalval = co2attime[time];
				}

				//otherwise approximate
				else
				{
					if(time <= 570)
					{	

						int lowerindex = -1;
						int higherindex = -1; 
						int dist2lower = 0;
						int dist2higher = 0;

						//find closest lower index
						while(lowerindex == -1)
						{
							//if no value at time 
							if(co2attime[time - dist2lower] == 0)
							{
								//increase dist2lower and try lower time
								dist2lower++;
							}

							//if value at time
							else
							{
								lowerindex = time - dist2lower;
							}
						}

						//find closest higher index
						while(higherindex == -1)
						{
							//if no value at time 
							if(co2attime[time + dist2higher] == 0)
							{
								//increase dist2higherand try higher time
								dist2higher++;
							}

							//if value at time
							else
							{
								higherindex = time + dist2higher;
							}
						}

						float avgpermil = Mathf.Abs((float) co2attime[lowerindex] - (float) co2attime[higherindex]) / (dist2lower + dist2higher);
						if(co2attime[lowerindex] > co2attime[higherindex])
						{
							finalval = co2attime[higherindex] + (avgpermil * dist2higher);
						}
						else
						{
							finalval = co2attime[lowerindex] + (avgpermil * dist2lower);
						}
						decimal roundedfinal = Convert.ToDecimal(finalval);
						roundedfinal = decimal.Round(roundedfinal,1);
						finalval = Convert.ToDouble(roundedfinal);
					} 
				}
				co2text.text ="ppm Co2: " + finalval;
				//change co2 smoke
				co2smoke.GetComponent<ParticleSystem>().startSize = (float) (finalval * co2multiplier);
			}

			//TEMPERATURE
			time = (int) currenttime;
			//if time unknown
			if(time > 570)
			{
				temperaturetext.text = "ΔT°C: ???";
				//change skybox color
				if (RenderSettings.skybox.HasProperty("_Tint"))
         			RenderSettings.skybox.SetColor("_Tint", unknowntemp);
			}
			//otherwise time is known
			else
			{
				double finalval = 0;
				//if exact time in table
				if(temperatureattime[time] != 0)
				{
					finalval = temperatureattime[time];
				}

				//otherwise approximate
				else
				{
					if(time <= 520)
					{	

						int lowerindex = -1;
						int higherindex = -1; 
						int dist2lower = 0;
						int dist2higher = 0;

		
						//find closest lower index
						while(lowerindex == -1)
						{
							//if no value at time 
							if(temperatureattime[time - dist2lower] == 0)
							{
								//increase dist2lower and try lower time
								dist2lower++;
							}

							//if value at time
							else
							{
								lowerindex = time - dist2lower;
							}
						}

						//find closest higher index
						while(higherindex == -1)
						{
							//if no value at time 
							if(temperatureattime[time + dist2higher] == 0)
							{
								//increase dist2higherand try higher time
								dist2higher++;
							}

							//if value at time
							else
							{
								higherindex = time + dist2higher;
							}
						}

						float avgpermil = Mathf.Abs((float) temperatureattime[lowerindex] - (float) temperatureattime[higherindex]) / (dist2lower + dist2higher);
						if(temperatureattime[lowerindex] > temperatureattime[higherindex])
						{
							finalval = temperatureattime[higherindex] + (avgpermil * dist2higher);
						}
						else
						{
							finalval = temperatureattime[lowerindex] + (avgpermil * dist2lower);
						}
						decimal roundedfinal = Convert.ToDecimal(finalval);
						roundedfinal = decimal.Round(roundedfinal,1);
						finalval = Convert.ToDouble(roundedfinal);
					} 
				}
				temperaturetext.text ="ΔT°C: " + finalval;
				//change skybox color
				Color timecolor = coolest; 
				timecolor.r += (float) (finalval + 1.1) * .05f;
				if (RenderSettings.skybox.HasProperty("_Tint"))
         			RenderSettings.skybox.SetColor("_Tint", timecolor);
			}

			//SEA LEVEL
			time = (int) currenttime;
			//if time unknown
			if(time > 540)
			{
				sealeveltext.text = "Global sea level (m): ???";
			}

			//otherwise time is known
			else
			{
				double finalval = 0;
				//if exact time in table
				if(sealevelsattime[time] != 0)
				{
					finalval = sealevelsattime[time];
				}

				//otherwise approximate
				else
				{
					if(time <= 540)
					{	

						int lowerindex = -1;
						int higherindex = -1; 
						int dist2lower = 0;
						int dist2higher = 0;

						//539
						//530 = 180
						//find closest lower index
						while(lowerindex == -1)
						{
							//if no value at time 
							if(sealevelsattime[time - dist2lower] == 0)
							{
								//increase dist2lower and try lower time
								dist2lower++;
							}

							//if value at time
							else
							{
								lowerindex = time - dist2lower;
							}
						}

						//find closest higher index
						while(higherindex == -1)
						{
							//if no value at time 
							if(sealevelsattime[time + dist2higher] == 0)
							{
								//increase dist2higherand try higher time
								dist2higher++;
							}

							//if value at time
							else
							{
								higherindex = time + dist2higher;
							}
						}

						//avg per mil year = absolute value of sea level at lower minus sea level of higher 
						//54
						//
						//
						//530 - 180 
						//currently 535- target is 135
						//90 - 180 = 90 / 10 = 9;
						//finalval = 90 + (9 * 5)
						float avgpermil = Mathf.Abs((float) sealevelsattime[lowerindex] - (float) sealevelsattime[higherindex]) / (dist2lower + dist2higher);
						if(sealevelsattime[lowerindex] > sealevelsattime[higherindex])
						{
							finalval = sealevelsattime[higherindex] + (avgpermil * dist2higher);
						}
						else
						{
							finalval = sealevelsattime[lowerindex] + (avgpermil * dist2lower);
						}
						decimal roundedfinal = Convert.ToDecimal(finalval);
						roundedfinal = decimal.Round(roundedfinal,1);
						finalval = Convert.ToDouble(roundedfinal);
					} 
				}
				sealeveltext.text ="Global sea level (m): " + finalval;
				//change sea level
				float sealevel = lowestsealevel; 
				sealevel += (float) (finalval) * sealevelmultiplier; //.02 = 2y for every 100 meters- max is 400 = 8y
				sea.transform.position = new Vector3(sea.transform.position.x, sealevel, sea.transform.position.z);
			}

			//UNDERWATER!!
			if(sea.transform.position.y > playercab.transform.position.y)
			{
				Debug.Log("dsd");
				RenderSettings.fogColor = new Color(0.22f,0.65f,0.77f,0.5f);
			}
			
			else
			{
				RenderSettings.fogColor = new Color(0.5f,0.5f,0.5f,0.5f);
			}
	}

	//sets up paleochronology data tables
	void setPaleoData()
	{
		//co2 
		co2attime[570] = 11.7;
		co2attime[560] = 16.3;
		co2attime[550] = 18;
		co2attime[540] = 17.2;
		co2attime[530] = 25.5;
		co2attime[520] = 26.2;
		co2attime[510] = 22.4;
		co2attime[500] = 18.9;
		co2attime[490] = 17.3; 
		co2attime[480] = 17.3;
		co2attime[470] = 17.7;
		co2attime[460] = 15.5;
		co2attime[450] = 15.9;
		co2attime[440] = 16.7;
		co2attime[430] = 17;
		co2attime[420] = 13.9;
		co2attime[410] = 11;
		co2attime[400] = 11.3;
		co2attime[390] = 13.5;
		co2attime[380] = 15.3;
		co2attime[370] = 8;
		co2attime[360] = 6.1;
		co2attime[350] = 4.3;
		co2attime[340] = 2.7;
		co2attime[330] = 1.7;
		co2attime[320] = 1.3;
		co2attime[310] = 1.3;
		co2attime[300] = 1.2;
		co2attime[290] = 1.3;
		co2attime[280] = 1.3;
		co2attime[270] = 1.4;
		co2attime[260] = 1.9;
		co2attime[250] = 6.1;
		co2attime[240] = 7.1;
		co2attime[230] = 5.2;
		co2attime[220] = 5.8;
		co2attime[210] = 4.9;
		co2attime[200] = 5.4;
		co2attime[190] = 4.4;
		co2attime[180] = 4.8;
		co2attime[170] = 8.6;
		co2attime[160] = 9.1;
		co2attime[150] = 7.6;
		co2attime[140] = 8.2;
		co2attime[130] = 6.6;
		co2attime[120] = 6.1;
		co2attime[110] = 5.9;
		co2attime[100] = 5.3;
		co2attime[90] = 4.3;
		co2attime[80] = 4.2;
		co2attime[70] = 3.2;
		co2attime[60] = 2.8;
		co2attime[50] = 3.2;
		co2attime[40] = 2.1;
		co2attime[30] = 1.4;
		co2attime[20] = 1.2;
		co2attime[10] = 1;
		co2attime[0] = 1;
		
		//temperature
		temperatureattime[520] = 6.5;
		temperatureattime[510] = 7.5;
		temperatureattime[500] = 6.8; 
		temperatureattime[490] = 6.4; 
		temperatureattime[480] = 5.9;
		temperatureattime[470] = 5.0; 
		temperatureattime[460] = 2.9;      
		temperatureattime[450] = 2.2;
		temperatureattime[440] = 2.5; 
		temperatureattime[430] = 2.9; 
		temperatureattime[420] = 3.0;
		temperatureattime[410] = 3.7;
		temperatureattime[400] = 4.3; 
		temperatureattime[390] = 5.3; 
		temperatureattime[380] = 6.1; 
		temperatureattime[370] = 4.6;  
		temperatureattime[360] = 3.7;
		temperatureattime[350] = 2.7; 
		temperatureattime[340] = 1.4;
		temperatureattime[330] = 0.7;
		temperatureattime[320] = -0.3; 
		temperatureattime[310] = -1.1;
		temperatureattime[300] = -1.1;
		temperatureattime[290] = -0.9;
		temperatureattime[280] = -0.9;
		temperatureattime[270] = 0.8; 
		temperatureattime[260] = 3.5; 
		temperatureattime[250] = 5.0;
		temperatureattime[240] = 5.5;
		temperatureattime[230] = 4.5;
		temperatureattime[220] = 3.1; 
		temperatureattime[210] = 1.9; 
		temperatureattime[200] = 2.0; 
		temperatureattime[190] = 1.7; 
		temperatureattime[180] = 1.0; 
		temperatureattime[170] = 2.4; 
		temperatureattime[160] = 2.7;
		temperatureattime[150] = 2.5; 
		temperatureattime[140] = 3.0;
		temperatureattime[130] = 2.3;
		temperatureattime[120] = 2.6; 
		temperatureattime[110] = 2.8;
		temperatureattime[100] = 4.2;
		temperatureattime[90] = 3.9;
		temperatureattime[80] = 3.2;
		temperatureattime[70] = 3.1;
		temperatureattime[60] = 2.6;  
		temperatureattime[50] = 2.3;
		temperatureattime[40] = 1.4;
		temperatureattime[30] = 0.3;
		temperatureattime[20] = -0.1;
		temperatureattime[10] = -0.3;
		temperatureattime[0] = 1;

		//sea level
		sealevelsattime[540] = 90;
		sealevelsattime[530] = 180;
		sealevelsattime[500] = 325;
		sealevelsattime[486] = 275;
		sealevelsattime[450] = 400; 
		sealevelsattime[420] = 340;
		sealevelsattime[405] = 210;
		sealevelsattime[385] = 260;
		sealevelsattime[375] = 200;
		sealevelsattime[325] = 250; 
		sealevelsattime[250] = -25; 
		sealevelsattime[222] = 60; 
		sealevelsattime[200] = 25;
		sealevelsattime[80] = 240; 
		sealevelsattime[25] = 1;
		sealevelsattime[12] = 40;
		sealevelsattime[0] = 1; 
	}
}
