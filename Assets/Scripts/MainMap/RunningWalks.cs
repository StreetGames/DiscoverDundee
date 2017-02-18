using UnityEngine;
using System;
using System.Collections;

public class RunningWalks : MonoBehaviour {

	public GameObject MapBase;

	public GameObject[] ActiveLocations;
	public GameObject MagicCube;
	public float ScaleSpeed;

	Material SonarMaterial;

	private int WalkTarget = 0;
	private bool ShowSonarCircle = false;
	private GameObject SonarCircle;

	private bool GameActive = false;

	static private int gameButtonSize = Screen.width / 10;
	static private int gameButtonSpacer = gameButtonSize / 5;
	static private int gameButtonYAllignment = Screen.height - (Screen.height / 4);

	private Vector2[,] wj_letter_coords;
	private Vector2[,] wj_initial_coords;
	private Vector2[,] wj_answer_locations;
	private int wj_current_answer_pos = 0;
	private string[,] wordJumbles;
	public Texture[] UIAlphabet;
	private Texture[,] wordJumblesTexture;
	private string wordJumbleAnswer;
	private string[] wordJumbleAnswerSubmit;
	private string wordJumbleAnswerSubmitFinal;
	private bool[] wordJumbleChecker;
	private bool wj_perform = false;
	private int wj_buttons_pressed = 0;

	void Start() {
		
		wj_initial_coords = new Vector2[2, 8] {
			 {
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			},
			{
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			}
		};
	
		wj_letter_coords  = new Vector2[2,8] {
			{
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			},
			{
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			}};

		wj_answer_locations = new Vector2[6, 10] {
			 {
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			},
			{
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			},
			{
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			},
			{
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			},
			{
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			},
			{
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F),
				new Vector2 (0.0F, 0.0F)
			}
		};

		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < 8; j++) {
				wj_initial_coords [i, j] = new Vector2 (((j * (gameButtonSize + gameButtonSpacer)) + gameButtonSpacer), ((i * (gameButtonSize + gameButtonSpacer)) + gameButtonSpacer + gameButtonYAllignment));
			}
		}
		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < 8; j++) {
				wj_letter_coords [i, j] = new Vector2 (((j * (gameButtonSize + gameButtonSpacer)) + gameButtonSpacer), ((i * (gameButtonSize + gameButtonSpacer)) + gameButtonSpacer + gameButtonYAllignment));
			}
		}
		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < (i + 4); j++) {
				wj_answer_locations [i, j] = new Vector2 ((j * (gameButtonSize + gameButtonSpacer) + (gameButtonSpacer * (4 + i))), (Screen.height / 2)); 
			}
		}
		wordJumbleAnswerSubmit = new string[10] {"", "", "", "", "", "", "", "", "", ""};
		wordJumbleAnswerSubmitFinal = "";
		wordJumbleChecker = new bool[10] {false, false, false, false, false, false, false, false, false, false};
		SonarMaterial = Resources.Load("Sonar", typeof(Material)) as Material;
	}

	// Update is called once per frame
	void Update () {
		if (MagicCube.GetComponent<CreateLocations>().ActiveWalk == true) {
			ActiveLocations = GameObject.FindGameObjectsWithTag ("Active");
			ActiveLocations [WalkTarget].transform.position = new Vector3 (ActiveLocations [WalkTarget].transform.position.x, 0.25F, ActiveLocations [WalkTarget].transform.position.z);
			MagicCube.GetComponent<CreateLocations> ().ActiveWalk = false;
			/*SonarCircle = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
			SonarCircle.transform.position = new Vector3 (ActiveLocations [WalkTarget].transform.position.x, 0.1F, ActiveLocations [WalkTarget].transform.position.z);
			SonarCircle.transform.localScale = new Vector3 (1.0F, 0.01F, 1.0F);
			SonarCircle.GetComponent<Renderer>().material = SonarMaterial;
			SonarCircle.GetComponent<Renderer>().material.color = new Color (0.05F, 0.84F, 0.06F, 0.5f);
			ShowSonarCircle = true;*/
			print(WalkTarget);
		}
		if (ShowSonarCircle) {
			//SonarCircle.transform.localScale = new Vector3 (SonarCircle.transform.localScale.x + (Time.deltaTime * ScaleSpeed), 0.01F, SonarCircle.transform.localScale.z + (Time.deltaTime * ScaleSpeed));
		}
		if (GameActive) {
			
		}
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Cylinder")
		{
			//SonarCircle.transform.localScale = new Vector3 (1.0F, 0.01F, 1.0F);
		}
		if (col.gameObject.name == ActiveLocations [WalkTarget].name) {
			MagicCube.GetComponent<CreateLocations> ().ActiveWalk = true;
			GameActive = true;
			SelectWordJumbles ();
			WalkTarget++;
		}

	}
	void OnGUI(){
		
		if (GameActive) {
			//LETTER BUTTONS
			for (int i = 0; i < 2; i++) {
				for (int j = 0; j < 8; j++) {
					if (GUI.Button (new Rect(wj_letter_coords[i,j].x, wj_letter_coords[i,j].y, gameButtonSize, gameButtonSize), wordJumblesTexture[i,j] )) {
						if (wj_letter_coords [i, j].y != wj_initial_coords [i, j].y) {
							for(int k = 0; k < 10; k++){
								if (wj_letter_coords [i, j].x == wj_answer_locations [wordJumbleAnswer.Length - 4, k].x) {
									wordJumbleChecker [k] = false;
									if (k < wj_current_answer_pos) {
										wj_perform = true;
									} else {
										wj_perform = false;
									}
								}
							}
							if (wj_perform) {
								do {
									wj_current_answer_pos--;
								} while(wordJumbleChecker [wj_current_answer_pos]);
							}
							wj_letter_coords [i, j] = wj_initial_coords [i, j];
							wj_buttons_pressed--;
						} else {
							if (wj_buttons_pressed < wordJumbleAnswer.Length) {
								wj_letter_coords [i, j] = wj_answer_locations [(wordJumbleAnswer.Length - 4), wj_current_answer_pos];
								wordJumbleChecker [wj_current_answer_pos] = true;
								while (wordJumbleChecker [wj_current_answer_pos]) {
									wj_current_answer_pos++;
								} 
								wj_buttons_pressed++;
							}
						}
					}
				}
			}
			//SUBMIT BUTTON
			if (GUI.Button (new Rect (Screen.width / 2, (Screen.height / 3 )* 2, gameButtonSize, gameButtonSize), "SUBMIT")) {
				for (int i = 0;i<2;i++){
					for (int j = 0; j < 8; j++) {
						for (int k = 0; k < 10; k++) {
							if (wj_letter_coords [i, j].x == wj_answer_locations [wordJumbleAnswer.Length - 4, k].x && wj_letter_coords [i, j].y == wj_answer_locations [wordJumbleAnswer.Length - 4, k].y) {
								wordJumbleAnswerSubmit [k] = wordJumblesTexture [i, j].name;
							}
						}
					}
				}
				wordJumbleAnswerSubmitFinal = String.Concat (wordJumbleAnswerSubmit [0], wordJumbleAnswerSubmit [1], wordJumbleAnswerSubmit [2], wordJumbleAnswerSubmit [3], wordJumbleAnswerSubmit [4], wordJumbleAnswerSubmit [5], wordJumbleAnswerSubmit [6], wordJumbleAnswerSubmit [7], wordJumbleAnswerSubmit [8], wordJumbleAnswerSubmit[9]);
				if (wordJumbleAnswerSubmitFinal == wordJumbleAnswer) {
					//DO CORRECT ANSWER THING
				} else {
					//DO INCORRECT ANSWER THING
				}
			}
		}
	}
	void SelectWordJumbles(){
		switch(MapBase.GetComponent<SelectWalk>().currentWalk){
		case 0://CityCentre, Nethergate
			break;
		case 1://CityCentre, HighStreet
			break;
		case 2://CityCentre, Shore
			break;
		case 3://CityCentre, Cowgate
			break;
		case 4://CityCentre, Meadows 
			switch (WalkTarget) {
			case 0: //Royal Exchange
				break;
			case 1:
				wordJumbleAnswer = "SHIELD";
				wordJumbles = new string[2, 8] {
					 {
						"<size=40>s</size>",
						"<size=40>h</size>",
						"<size=40>i</size>",
						"<size=40>e</size>",
						"<size=40>l</size>",
						"<size=40>d</size>",
						"<size=40>a</size>",
						"<size=40>b</size>"
					}, {
						"<size=40>c</size>",
						"<size=40>d</size>",
						"<size=40>e</size>",
						"<size=40>f</size>",
						"<size=40>g</size>",
						"<size=40>h</size>",
						"<size=40>i</size>",
						"<size=40>j</size>"
					}
				};
				wordJumblesTexture = new Texture[2, 8] {
					{
						UIAlphabet[18],
						UIAlphabet[7],
						UIAlphabet[8],
						UIAlphabet[4],
						UIAlphabet[11],
						UIAlphabet[3],
						UIAlphabet[20],
						UIAlphabet[14],
					}, {
						UIAlphabet[19],
						UIAlphabet[22],
						UIAlphabet[25],
						UIAlphabet[5],
						UIAlphabet[7],
						UIAlphabet[13],
						UIAlphabet[0],
						UIAlphabet[25],
					}
				};
				break;
			}
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
}
	