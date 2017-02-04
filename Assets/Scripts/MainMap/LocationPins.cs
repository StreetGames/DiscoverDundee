using UnityEngine;
using System.Collections;

public class LocationPins : MonoBehaviour
{
	Vector2 coordinates;
	string location_name;

	public GameObject marker = GameObject.CreatePrimitive (PrimitiveType.Cube);

	//To go from latitude to z-coord (latitude-minlatitude)/(latConversion*100(1 unit in pixels))-5.04(halfMapHeight)
	float latConversion = 0.0000060787037037F;
	float minLatitude = 56.457858F;
	float maxLatitude = 56.464423F;

	//To go from longitude to x-coord (longitude-minlongitude)/(lonConversion*100(1 unit in pixels))-9.60(halfMapHeight)
	float lonConversion = 0.000010911979166666F;
	float minLongitude = -2.980929F;
	float maxLongitude = -2.959978F;

	public LocationPins(){
	}

	public void Create(float lat_, float long_, string id_){
		coordinates.x = lat_;
		coordinates.y = long_;
		location_name = id_;

		marker.transform.position = new Vector3(((coordinates.x-minLongitude)/(lonConversion*100)-9.60F),0, ((coordinates.y-minLatitude)/(latConversion*100)-5.04F));
	}
}

