using UnityEngine;

public class MenuScript : MonoBehaviour {

	public bool pressedSettings;
	public bool settings;
	public bool pressedStart;
	public bool selectLevel;
	static float volumeLevel;

	float sW;
	float sH;

	void Start() {
		settings = false;
		selectLevel = false;
		volumeLevel = 5.0f;
	}

	void OnGUI() {

		const int startButtonWidth = 229;
		const int startButtonHeight = 126;

		const int settingsButtonWidth = 205;
		const int settingsButtonHeight = 112;


		const int quitButtonWidth = 173;
		const int quitButtonHeight = 97;

		const float cityButtonWidth = 301* 0.9f;
		const float cityButtonHeight = 109* 0.9f;
		
		const float airshipButtonWidth = 297* 0.9f;
		const float airshipButtonHeight = 114* 0.9f;
		
		const float mechButtonWidth = 351* 0.9f;
		const float mechButtonHeight = 175* 0.9f;
		
		const float coreButtonWidth = 251* 0.9f;
		const float coreButtonHeight = 157* 0.9f;

		const float backButtonWidth = 368 / 3;
		const float backButtonHeight = 118 / 3;

		//START:
		if (GUI.Button (new Rect (140, 30, startButtonWidth, startButtonHeight), "", GUIstyles.GetStartMenuStyle())){
			//Application.LoadLevel("Level01");
			pressedStart = true;
		}

		//SETTINGS:
		if (GUI.Button (new Rect (140, 179, settingsButtonWidth, settingsButtonHeight), "", GUIstyles.GetSettingsMenuStyle())){
			//settings =! settings;
			pressedSettings = true;
		}

		if (settings) {
			volumeLevel = GUI.HorizontalSlider(new Rect(380, 230, 200, 20), volumeLevel, 0.0f, 10.0f); //, GUIStyle, GUIStyle);
		}

		//QUIT:
		if (GUI.Button (new Rect (160, 310, quitButtonWidth, quitButtonHeight), "", GUIstyles.GetQuitMenuStyle())){
			Application.Quit();
		}

		if (selectLevel == true) {
			GUI.Box (new Rect (0, 0, sW, sH),"", GUIstyles.GetStartBlkScreenStyle());
		}
		
		if (selectLevel) {
			//GUI.Box(new Rect(boxX,boxY,250,250),"Menu", boxStyle); //background
			
			if(GUI.Button(new Rect(sW/2 - cityButtonWidth/2, 30, cityButtonWidth, cityButtonHeight),"", GUIstyles.GetCityStyle())){
				Application.LoadLevel("Level01");
			}
			
			if(GUI.Button(new Rect(sW/2 - airshipButtonWidth/2, 50 + cityButtonHeight, airshipButtonWidth, airshipButtonHeight),"", GUIstyles.GetAirship2Style())){
				Application.LoadLevel("level02c");
			}
			
			if(GUI.Button(new Rect(sW/2 - mechButtonWidth/2, 50 + cityButtonHeight + airshipButtonHeight, mechButtonWidth, mechButtonHeight),"", GUIstyles.GetMechDistrict2Style())){
				Application.LoadLevel("level03");
			}
			
			if(GUI.Button(new Rect(sW/2 - coreButtonWidth/2, 40 + cityButtonHeight + airshipButtonHeight + mechButtonHeight, coreButtonWidth, coreButtonHeight),"", GUIstyles.GetCore2Style())){
				Application.LoadLevel("level04");
			}
			
			if(GUI.Button(new Rect(sW/2 - backButtonWidth/2 - 10, sH - backButtonHeight - 20,backButtonWidth,backButtonHeight),"", GUIstyles.GetBackStyle())){
				pressedStart = false;
			}
		}
	}

	void Update () {

		sW = Screen.width;
		sH = Screen.height;

		AudioListener.volume = volumeLevel/10.0f;

		if(pressedStart) {
			selectLevel = true;
			if(settings) {
				settings = false;
				pressedSettings = false;
			}
		}

		else selectLevel = false;

		if(pressedSettings) {
			settings = true;
			if(selectLevel) {
				selectLevel = false;
				pressedStart = false;
			}
		}

		else settings = false;

	}
}

// Draw a button to start the game
// Center in X, 2/3 of the height in Y
//if (GUI.Button(new Rect( Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 4 + 25) - (buttonHeight / 2), buttonWidth, buttonHeight),"Start!"))	{

//		const int buttonWidth2 = 84;
//		const int buttonHeight2 = 60;
//		
//		// Draw a button to start the game
//		if (
//			GUI.Button(
//			// Center in X, 2/3 of the height in Y
//			new Rect(
//			200,
//			(2 * Screen.height / 2 + 25) - (buttonHeight2 / 2),
//			buttonWidth2,
//			buttonHeight2
//			),
//			"Tutorial"
//			)
//			)
//		{
//			// On Click, load the first level.
//			// "Stage1" is the name of the first scene we created.
//			Application.LoadLevel ("Tutorial");
//		}

//			if(GUI.Button(new Rect(440, 150, 280, 20),"Level 1: The City")){
//				Application.LoadLevel("Level01");
//			}
//
//			if(GUI.Button(new Rect(440, 180, 280, 20),"Level 2: The Airship")){
//				Application.LoadLevel("level02c");
//			}
//
//			if(GUI.Button(new Rect(440, 210, 280, 20),"Level 3: The Mechanical District")){
//				Application.LoadLevel("level03");
//			}
//
//			if(GUI.Button(new Rect(440, 240, 280, 20),"Level 4: The Core")){
//				Application.LoadLevel("level04");
//			}