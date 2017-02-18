using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectWalk : MonoBehaviour {

	public GameObject cube;
	public Texture2D menu, left, right, go, back;
	public Texture2D[] walkSections;
	public Texture2D[] walks;
	public int[] sectionLengths;
	public bool displayWalkMenu = false;

	static private int buttonSize = Screen.width / 9;
	static private int buttonSpacer = buttonSize / 5;
	private int currentSection = 0;//0 = CC, 1 = CB, 2 = WE, 3 = M, 4 = BF
	public int currentWalk = 0; //
	private CreateLocations CreateLocations;
	private int displayLevel = 0;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update(){

	}

	void OnGUI(){
		if (GUI.Button (new Rect (Screen.width - buttonSize - buttonSpacer, buttonSpacer, buttonSize, buttonSize), menu)) {
			displayWalkMenu = !displayWalkMenu;
		}
		if (displayWalkMenu) {
			if (GUI.Button (new Rect ((Screen.width / 2) - ((buttonSize * 3) / 2), Screen.height - buttonSize - buttonSpacer, (buttonSize * 3), buttonSize), go)) {
				if (displayLevel == 0) {
					currentWalk = currentSection * 10;
					displayLevel = 1;
				} else if (displayLevel == 1) {
					cube.GetComponent<CreateLocations>().CreateWalk(currentWalk);
					displayWalkMenu = false;
				}
			}
			if (GUI.Button (new Rect (buttonSpacer, (Screen.height / 2) - (buttonSize / 2), buttonSize, buttonSize), left)) {
				if (displayLevel == 0) {
					currentSection--;
					if (currentSection < 0) {
						currentSection = (walkSections.Length - 1);
					}
				} else if (displayLevel == 1) {
					currentWalk--;
					if (currentWalk < currentSection * 10) {
						currentWalk = ((currentSection * 10) + sectionLengths[currentSection] - 1);
					}
				}
			}
			if (GUI.Button (new Rect (Screen.width - buttonSize - buttonSpacer, (Screen.height / 2) - (buttonSize / 2), buttonSize, buttonSize), right)) {
				if (displayLevel == 0) {
					currentSection++;
					if (currentSection > (walkSections.Length - 1)) {
						currentSection = 0;
					}
				} else if (displayLevel == 1) {
					currentWalk++;
					if (currentWalk > ((currentSection * 10) + sectionLengths[currentSection] - 1)) {
						currentWalk = currentSection * 10;
					}
				}
			}
			if (GUI.Button (new Rect (buttonSpacer, buttonSpacer, buttonSize, buttonSize), back)) {
				if (displayLevel == 0) {
					displayWalkMenu = false;
				} else if (displayLevel == 1) {
					displayLevel = 0;
				}
			}
			GUI.TextField (new Rect ((Screen.width / 2) - ((buttonSize * 3) / 2), buttonSpacer, (buttonSize * 3), buttonSize), "Select Walk");
			if (displayLevel == 0) {
				GUI.DrawTexture (new Rect (((Screen.width / 2) - ((buttonSize * 3) / 2)), ((Screen.height / 2) - ((buttonSize * 3) / 2)), (buttonSize * 3), (buttonSize * 3)), walkSections[currentSection]);
			} else if (displayLevel == 1) {
				GUI.DrawTexture (new Rect (((Screen.width / 2) - ((buttonSize * 3) / 2)), ((Screen.height / 2) - ((buttonSize * 3) / 2)), (buttonSize * 3), (buttonSize * 3)), walks[currentWalk]);
			}
		}
	}
}
