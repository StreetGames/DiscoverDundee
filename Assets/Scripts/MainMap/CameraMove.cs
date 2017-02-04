using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public GameObject player;       //Public variable to store a reference to the player game object
	public float speed = 0.1F;
	public GameObject Map;

	private Vector3 offset;         //Private variable to store the offset distance between the player and camera

	// Use this for initialization
	void Start () 
	{
		//Calculate and store the offset value by getting the distance between the player's position and camera's position.
		offset = transform.position - player.transform.position;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate () 
	{
		if(!Map.GetComponent<SelectWalk>().displayWalkMenu){
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
				Vector2 touchDeltaPos = Input.GetTouch (0).deltaPosition;
				transform.position = new Vector3 (transform.position.x + (-touchDeltaPos.x * speed), 5, transform.position.z + (-touchDeltaPos.y * speed));
			}
			// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
			 else if(Input.touchCount == 0){
				transform.position = player.transform.position + offset;
			}
		}
	}
}
