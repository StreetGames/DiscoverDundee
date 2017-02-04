using UnityEngine;
using System;
using System.Collections;

public class RunningWalks : MonoBehaviour {

	public GameObject[] ActiveLocations;
	public GameObject MagicCube;

	private int WalkTarget = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (MagicCube.GetComponent<CreateLocations>().ActiveWalk == true) {
			ActiveLocations = GameObject.FindGameObjectsWithTag ("Active");
			ActiveLocations [WalkTarget].transform.position = new Vector3 (ActiveLocations [WalkTarget].transform.position.x, 0.25F, ActiveLocations [WalkTarget].transform.position.z);
			MagicCube.GetComponent<CreateLocations> ().ActiveWalk = false;
		}
	}
}
