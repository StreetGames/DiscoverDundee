using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LetsGo : MonoBehaviour {

	public Sprite dark;
	public Sprite light;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
			{
				GetComponent<SpriteRenderer> ().sprite = dark;
			}
		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
			{
				GetComponent<SpriteRenderer> ().sprite = light;
				SceneManager.LoadSceneAsync ("MainMap", LoadSceneMode.Single);
				SceneManager.UnloadScene ("StartScreen");
			}
		}
	}
}