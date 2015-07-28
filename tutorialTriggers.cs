using UnityEngine;
using System.Collections;

public class tutorialTriggers : MonoBehaviour {

	float gearCount;
	public GUIStyle gearNoticeStyle;
	public bool notEnoughGears;
	public bool notEnoughMessage;
	public bool enoughMessage;

//	public bool tut1;public bool tut2;public bool tut3;public bool tut4;public bool tut5;public bool tut6;
//	public bool tut7;public bool tut8;public bool tut9;public bool tut10;public bool tut11;

	public bool triggerDeactivated;
	public static float currentTutorial;

	float count = 1;

	public bool endOfTut;
	public bool respawned;
	public bool inTutorial = true;

	public float sW;
	public float sH;

	public Texture tut01; public Texture tut02; //public Texture tut03;

	bool next;

	//public GUIStyle testTutorial;

	void Start () {
//		tut1 = true;tut2 = false;tut3 = false;tut4 = false;tut5 = false;tut6 = false;tut7 = false;tut8 = false;
//		tut9 = false;tut10 = false;tut11 = false;//tut12 = false;

		GameObject player = GameObject.Find ("player");
		player.GetComponent<playerHp> ().hideHP = true;
		player.GetComponent<playerMP> ().hideMP = true;
		player.GetComponent<gearCount> ().hideGearCount = true;

		GameObject pressUp = GameObject.Find ("pressUp");
		pressUp.renderer.enabled = false;

		currentTutorial = 1;
		triggerDeactivated = false;
	}

	void Update () {

		//currentTutorial = 0;

		respawned = GameObject.Find ("player").GetComponent<playerHp> ().respawned;
		endOfTut = GameObject.Find ("endOfTutorial").GetComponent<endOfTutorial> ().endOfTut;

		GameObject mpParticles = GameObject.Find ("mpParticles");
		//if (currentTutorial < 5) mpParticles.particleSystem.Stop();
		//else mpParticles.particleSystem.Play();

//		if(Input.GetKeyDown(KeyCode.Return)) {
//			count = count - 1;
//		
//			if (count > -1) {
//				currentTutorial = currentTutorial + 1;
//			}
//
//			else currentTutorial = currentTutorial;
//
//			print (currentTutorial);
//		}
//
//		if(Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace)) {
//			currentTutorial = currentTutorial - 1;
//		}
	}


	void OnTriggerEnter2D(Collider2D collider) {

		//bool facingRight = GameObject.Find ("player").GetComponent<playerController> ().facingRight;

//		if (collider.tag == "windAtk" && currentTutorial == 4) {
//				count = count - 1;
//
//			if (count > -1 && !triggerDeactivated)
//				{
//					currentTutorial = currentTutorial + 1;
//					triggerDeactivated = true;
//				}
//			}

		if (collider.tag == "Player") {
			count = count - 1;

			if (count > -1)
			{
				currentTutorial = currentTutorial + 1;
				//triggerDeactivated = true;
			}
		}

//		else if (collider.tag == "Player") {
//			count = count - 1;
//			
//			if (count > -1)
//			{
//				currentTutorial = currentTutorial - 1;
//				//triggerDeactivated = true;
//			}
//		}

	//	count = 1;

	}

	void OnTriggerExit2D(Collider2D collider) {
		count = 1;
	}

	void OnGUI() {

		sW = Screen.width;
		sH = Screen.height;

		float scrollWidth = sW/2 - 50;
		float scrollHeight = scrollWidth / 1.5f;

		GameObject player = GameObject.Find ("player");
		GameObject pressUp = GameObject.Find ("pressUp");

//		if (currentTutorial == 1) {
//			//GUI.Box (new Rect (20, sH - scrollHeight - 20, scrollWidth, scrollHeight), "Use left and right arrow keys to run.", GUIstyles.GetTutorialStyle());
//			GUI.DrawTexture(new Rect(20, sH - scrollHeight - 20, scrollWidth, scrollHeight), tut01, ScaleMode.StretchToFill);
//		}
//
//		if (currentTutorial == 2) {
//			//GUI.Box (new Rect (sW-300, 30, 300, 20), "Use up arrow to jump.", GUIstyles.GetTutorialStyle());
//			GUI.DrawTexture(new Rect(20, sH - scrollHeight - 20, scrollWidth, scrollHeight), tut02, ScaleMode.StretchToFill);
//		}
//
//		if (currentTutorial == 3) {
//
//			if(Input.GetKey(KeyCode.UpArrow)) pressUp.renderer.enabled = true;
//			else if (player.GetComponent<playerController> ().grounded) pressUp.renderer.enabled = false;
//	
//			GUI.Box (new Rect (sW-300, 30, 300, 20), "Quickly tapping the up arrow while in the air will allow you to hover for a limited period of time.", GUIstyles.GetTutorialStyle());
//		}
//
//		if (currentTutorial == 4) {
//
//			pressUp.renderer.enabled = false;
//			GUI.Box (new Rect (sW-300, 30, 300, 20), "Press space to use your wind attack to fight enemies.", GUIstyles.GetTutorialStyle());
//		}
//
//		if (currentTutorial == 5) {
//			GUI.Box (new Rect (sW-300, 30, 300, 20), "Your magic energy is denoted by these particles on your cloak. Immediately after attacking, they will take a moment to regenerate themselves, during which time you cannot shoot.", GUIstyles.GetTutorialStyle2());
//		}

		if (currentTutorial == 1) {
			player.GetComponent<playerHp> ().hideHP = false;
			GUI.Box (new Rect (sW-300, 30, 300, 20), "", GUIstyles.GetTutorialStyle2());
		}

		if (currentTutorial == 2) {
			player.GetComponent<playerMP> ().hideMP = false;
			GUI.Box (new Rect (sW-300, 30, 300, 20), "", GUIstyles.GetTutorialStyle2());
		}

		if (currentTutorial == 3) {
			player.GetComponent<playerMP> ().hideMP = false;
			player.GetComponent<gearCount> ().hideGearCount = false;
			inTutorial = false;
			GUI.Box (new Rect (sW-300, 30, 300, 20), "", GUIstyles.GetTutorialStyle2());
		}

		if (currentTutorial == 4) {
			player.GetComponent<playerMP> ().hideMP = false;
			player.GetComponent<gearCount> ().hideGearCount = false;

			//GUI.Box (new Rect (sW-300, 30, 300, 20), "", GUIstyles.GetTutorialStyle());
		}

		if (currentTutorial == 10 || currentTutorial == 11) {

			GUI.Box (new Rect (sW-300, 30, 300, 20), "", GUIstyles.GetTutorialStyle3());
		}

		if (currentTutorial == 12) {
			player.GetComponent<playerMP> ().hideMP = false;
			player.GetComponent<gearCount> ().hideGearCount = false;
			player.GetComponent<playerHp> ().hideHP = false;
			GUI.Box (new Rect (sW-300, 30, 300, 20), "", GUIstyles.GetTutorialStyle3());

			inTutorial = false;
		}
	}
}
