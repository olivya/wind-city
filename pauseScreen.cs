using UnityEngine;
using System.Collections;

public class pauseScreen : MonoBehaviour {
	
	public bool paused = false;
	public bool showPauseMenu = false;

	private float boxY = Screen.height / 2 - 100;
	private float boxX = Screen.width / 2 - 100;

	float sW;
	float sH;

	public GUIStyle boxStyle;
	public bool pickedUp;
	string thisMessage;

	public bool pressedSettings;
	public bool settings;

	public bool showMap;


	static float volumeLevel = 5.0f;
	

	void Start() {
		}

	void Update() {

		sW = Screen.width;
		sH = Screen.height;

		AudioListener.volume = volumeLevel/10.0f;
		
//		if(pressedStart) {
//			selectLevel = true;
//			if(settings) {
//				settings = false;
//				pressedSettings = false;
//			}
//		}
		
//		else selectLevel = false;
		
		if(pressedSettings) {
			settings = true;
		}
		
		else settings = false;


		pickedUp = GameObject.Find ("player").GetComponent<showScript> ().pickedUp;

		thisMessage = GameObject.Find ("player").GetComponent<showScript> ().thisMessage2;


		if (pickedUp && Input.GetKeyDown (KeyCode.Return)) {
			pickedUp = false;
			paused = false;
		}

		if(pickedUp) {
			paused = true;
		}

		if(Input.GetKeyDown(KeyCode.Escape) && !pickedUp) {
			showPauseMenu = true;
		}

		AudioListener.volume = volumeLevel/10.0f;
	}
	
	void OnGUI() {

		const int escWidth = 525 / 2;
		const int escHeight = 59 / 2;

		const int mapWidth = 209 / 2;
		const int mapHeight = 55 / 2;


		if (GUI.Button (new Rect (sW - mapWidth - 20, sH - mapHeight - 50, mapWidth, mapHeight), "",GUIstyles.GetMapStyle())){
			//showPauseMenu = true;
			showMap = !showMap;
		}

		if (GUI.Button (new Rect (sW - escWidth - 20, sH - escHeight - 20, escWidth, escHeight), "", GUIstyles.GetEscStyle())){
			showPauseMenu = true;
		}



		if (showPauseMenu == true || showMap == true) {
			GUI.Box (new Rect (0, 0, sW, sH),"", GUIstyles.GetPauseScreenStyle());
		}



		const int resumeButtonWidth = 229 * 2;
		const int resumeButtonHeight = 126 * 2;
		
		const int settingsButtonWidth = 205 * 2;
		const int settingsButtonHeight = 112 * 2;
		
		const int quitButtonWidth = 173 * 2;
		const int quitButtonHeight = 97 * 2;

		const int menuButtonWidth = 253 * 2;
		const int menuButtonHeight = 130 * 2;


		const int cityButtonWidth = 301 / 2;
		const int cityButtonHeight = 109 / 2;

		const int airshipButtonWidth = 297 / 2;
		const int airshipButtonHeight = 114 / 2;

		const int mechButtonWidth = 351 / 2;
		const int mechButtonHeight = 175 / 2;

		const int coreButtonWidth = 251 / 2;
		const int coreButtonHeight = 157 / 2;

		const int mapViewWidth = 624/2;
		const int mapViewHeight = 56/2;


		if (showMap) {
			if (GUI.Button (new Rect (sW/2 - resumeButtonWidth/6, sH - 150, resumeButtonWidth/3, resumeButtonHeight/3), "", GUIstyles.GetPauseResumeStyle())){
				showMap = false;
			}

			if (GUI.Button (new Rect (sW/2 - mapViewWidth/2, sH - 50, mapViewWidth, mapViewHeight), "", GUIstyles.GetMapViewStyle())){
				showMap = false;
			}
		}


		if (showPauseMenu)
		{
			//GUI.Box(new Rect(boxX,boxY,250,250),"Menu", boxStyle); //background

			if (GUI.Button (new Rect (sW/2 - resumeButtonWidth/6, 30, resumeButtonWidth/3, resumeButtonHeight/3), "", GUIstyles.GetPauseResumeStyle())){
				showPauseMenu = false;
			}

			if (GUI.Button (new Rect (sW/2 - settingsButtonWidth/6, 146, settingsButtonWidth/3, settingsButtonHeight/3), "", GUIstyles.GetSettings2MenuStyle())){
				pressedSettings = !pressedSettings;
			}
					if (settings) {
						volumeLevel = GUI.HorizontalSlider(new Rect(sW/2 - 100, 230, 200, 20), volumeLevel, 0.0f, 10.0f);
					}

			if (GUI.Button (new Rect (sW/2 - menuButtonWidth/6, 243, menuButtonWidth/3, menuButtonHeight/3), "", GUIstyles.GetPauseMainMenuStyle())){
				Application.LoadLevel(0);
			}

			if (GUI.Button (new Rect (sW/2 - quitButtonWidth/6, 350, quitButtonWidth/3, quitButtonHeight/3), "", GUIstyles.GetQuitMenu2Style())){
				Application.Quit();
			}


			if(GUI.Button(new Rect(sW/2 - cityButtonWidth - airshipButtonWidth - 45, sH - 100, cityButtonWidth, cityButtonHeight),"", GUIstyles.GetCityStyle())){
				Application.LoadLevel("Level01");
			}
			
			if(GUI.Button(new Rect(sW/2 - airshipButtonWidth - 15, sH - 100, airshipButtonWidth, airshipButtonHeight),"", GUIstyles.GetAirshipStyle())){
				Application.LoadLevel("level02c");
			}
			
			if(GUI.Button(new Rect(sW/2 + 15, sH - 120, mechButtonWidth, mechButtonHeight),"", GUIstyles.GetMechDistrictStyle())){
				Application.LoadLevel("level03");
			}
			
			if(GUI.Button(new Rect(sW/2 + mechButtonWidth + 45, sH - 110, coreButtonWidth, coreButtonHeight),"", GUIstyles.GetCoreStyle())){
				Application.LoadLevel("level04");
			}



//			if(GUI.Button(new Rect(sW/2 - 40, sH/2 - 100, 80,20),"Resume")){
//				showPauseMenu = false;
//			}
//
//			if(GUI.Button(new Rect(sW/2 - 40, sH/2 - 70, 80,20),"Main Menu")){
//				Application.LoadLevel(0);
//			}
//
//			volumeLevel = GUI.HorizontalSlider(new Rect(sW/2 - 100, sH/2 - 40, 200, 20), volumeLevel, 0.0f, 10.0f);
//
//			if(GUI.Button(new Rect(sW/2 - 140, sH/2 - 10, 280, 20),"Level 1: The City")){
//				Application.LoadLevel("Level01");
//			}
//			
//			if(GUI.Button(new Rect(sW/2 - 140, sH/2 + 20, 280, 20),"Level 2: The Airship")){
//				Application.LoadLevel("level02c");
//			}
//			
//			if(GUI.Button(new Rect(sW/2 - 140, sH/2 + 50, 280, 20),"Level 3: The Mechanical District")){
//				Application.LoadLevel("level03");
//			}
//			
//			if(GUI.Button(new Rect(sW/2 - 140, sH/2 + 80, 280, 20),"Level 4: The Core")){
//				Application.LoadLevel("level04");
//			}
		}

		if (pickedUp) {
			GUI.Box (new Rect (470, -40, 700, 700), "", GUIstyles.GetScrollStyle());
			GUI.Box (new Rect (600, 70, 350, 380), thisMessage, GUIstyles.GetScrollTextStyle());
			paused = true;
		}

		else if (!pickedUp) paused = false;

		if(GUI.Button(new Rect(boxX + 360,boxY + 550,80,20),"Pause"))
		{
			paused = true;
		}


		if(paused == true || showPauseMenu == true || showMap == true || Camera.main.orthographicSize != 13)
		{
			Time.timeScale = 0;
		}


		else if(paused == false || showPauseMenu == false || (showMap == false && Camera.main.orthographicSize == 13))
		{
			Time.timeScale = 1;
		}

	}
}