using UnityEngine;
using System.Collections;




public class GPSTracker : MonoBehaviour {

	//To go from latitude to z-coord (latitude-minlatitude)/(latConversion*100(1 unit in pixels))-5.04(halfMapHeight)
	float latConversion = 0.0000060787037037F;
	float minLatitude = 56.457858F;
	float maxLatitude = 56.464423F;

	//To go from longitude to x-coord (longitude-minlongitude)/(lonConversion*100(1 unit in pixels))-9.60(halfMapHeight)
	float lonConversion = 0.000010911979166666F;
	float minLongitude = -2.980929F;
	float maxLongitude = -2.959978F;

	//float test_lat = 56.459654F; 
	//float test_long = -2.969088F;
	// Use this for initialization
	void Start () {
		Input.location.Start();
		Input.compass.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		float longitude = Input.location.lastData.longitude;
		float latitude = Input.location.lastData.latitude;
		if (latitude < minLatitude) {
			latitude = minLatitude;
		}
		if (latitude > maxLatitude) {
			latitude = maxLatitude;
		}
		if (longitude < minLongitude) {
			longitude = minLongitude;
		}
		if (longitude > maxLongitude) {
			longitude = maxLongitude;
		}

		//GetComponent<Transform> ().position = new Vector3 (((test_long - minLongitude) / (lonConversion * 100) - 9.6F), 0, ((test_lat - minLatitude) / (latConversion * 100) - 5.4F));
		//transform.position = new Vector3(((longitude-minLongitude)/(lonConversion*100)-9.60F),0.1F, ((latitude-minLatitude)/(latConversion*100)-5.04F));
		//Test Movement
		if(Input.GetKeyDown(KeyCode.W)){
			transform.position = transform.position + new Vector3 (0, 0, 0.1F);
		}
		if(Input.GetKeyDown(KeyCode.A)){
			transform.position = transform.position + new Vector3 (-0.1F, 0, 0);
		}
		if(Input.GetKeyDown(KeyCode.S)){
			transform.position = transform.position + new Vector3 (0, 0, -0.1F);
		}
		if(Input.GetKeyDown(KeyCode.D)){
			transform.position = transform.position + new Vector3 (0.1F, 0, 0);
		}

		transform.rotation = Quaternion.Euler (90.0F, Input.compass.trueHeading, Input.compass.trueHeading);
	}
}
