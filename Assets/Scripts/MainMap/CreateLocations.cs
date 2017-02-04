using UnityEngine;
using System;
using System.Collections;

public class CreateLocations : MonoBehaviour {

	Vector2 loc_abertay = new Vector2(56.463044F, -2.974081F);
	Vector2 loc_mcmanus = new Vector2(56.462515F, -2.971025F);
	Vector2 loc_dcthompson = new Vector2(56.462091F, -2.972610F);
	Vector2 loc_highschool = new Vector2(56.462773F, -2.972735F);
	Vector2 loc_royalexchange = new Vector2(56.463125F, -2.970704F);

	//To go from latitude to z-coord (latitude-minlatitude)/(latConversion*100(1 unit in pixels))-5.04(halfMapHeight)
	float latConversion = 0.0000060787037037F;
	float minLatitude = 56.457858F;
	float maxLatitude = 56.464423F;

	//To go from longitude to x-coord (longitude-minlongitude)/(lonConversion*100(1 unit in pixels))-9.60(halfMapHeight)
	float lonConversion = 0.000010911979166666F;
	float minLongitude = -2.980929F;
	float maxLongitude = -2.959978F;

	public bool ActiveWalk = false;

	// Use this for initialization
	public void CreateWalk (int currentWalk) {
		ActiveWalk = true;
		switch(currentWalk){
		case 0://CityCentre, Nethergate
			break;
		case 1://CityCentre, HighStreet
			break;
		case 2://CityCentre, Shore
			break;
		case 3://CityCentre, Cowgate
			break;
		case 4://CityCentre, Meadows 
			Create (loc_royalexchange.x, loc_royalexchange.y, "Royal Exchange", 0);
			Create (loc_mcmanus.x, loc_mcmanus.y, "McManus Galleries", 1);
			Create (loc_highschool.x, loc_highschool.y, "Dundee High School", 2);
			Create (loc_abertay.x, loc_abertay.y, "Abertay Univertsity", 3);
			Create (loc_dcthompson.x, loc_dcthompson.y, "DC Thompson", 4);
			break;
		case 5://CityCentre, WardLands
			break;
		case 6://CityCentre, ReturnToTheShore
			break;
		case 10://CityBraes, EastPort
			break;
		case 11://CityBraes, BonnyBank
			break;
		case 12://CityBraes, UpperChapelShade
			break;
		case 13://CityBraes, DudhopeEstate
			break;
		case 14://CityBraes, DudhopePark
			break;
		case 15://CityBraes, ScouringBurn
			break;
		case 20://WestEnd, CulturalQuarter
			break;
		case 21://WestEnd, Roseangle
			break;
		case 22://WestEnd, PerthRoad
			break;
		case 23://WestEnd, UniversityCampus
			break;
		case 30://Maritime, CraigHarbour
			break;
		case 31://Maritime, Esplanade
			break;
		case 32://Maritime, CentralWaterfront
			break;
		case 33://Maritime, HistoricDocks
			break;
		case 34://Maritime, DockStreetFrontage
			break;
		case 35://Maritime, HistoricMaritime
			break;
		case 40://BroughtyFerry, QueenStreetArea
			break;
		case 41://BroughtyFerry, BrookStreetEast
			break;
		case 42://BroughtyFerry, EsplanadeAndBeach
			break;
		case 43://BroughtyFerry, CastleAndHarbour
			break;
		case 44://BroughtyFerry, FisherStreet
			break;
		case 45://BroughtyFerry, FortStreetBrookStreet
			break;
		default: 
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Create(float lat_, float long_, string id_, int counterPos_){
		GameObject marker = GameObject.CreatePrimitive (PrimitiveType.Cube);
		marker.transform.position = new Vector3(((long_-minLongitude)/(lonConversion*100)-9.60F),-1.0F, ((lat_-minLatitude)/(latConversion*100)-5.04F));
		marker.transform.localScale = new Vector3 (0.1f, 0.5f, 0.1f);
		marker.name = id_;
		marker.tag = "Active";
	}
}
