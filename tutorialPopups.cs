using UnityEngine;
using System.Collections;

public class tutorialPopups : MonoBehaviour {

	public GUIStyle tutorialStyle;
	public GUIStyle tutorialStyle2;

	public bool tut1;
	public bool tut2;
	public bool tut3;
	public bool tut4;
	public bool tut5;
	public bool tut6;
	public bool tut7;
	public bool tut8;
	public bool tut9;
	public bool tut10;
	public bool tut11;
	public bool tut12;



	void Start () {
		tut1 = true;
		tut2 = false;
		tut3 = false;
		tut4 = false;
		tut5 = false;
		tut6 = false;
		tut7 = false;
		tut8 = false;
		tut9 = false;
		tut10 = false;
		tut11 = false;
		tut12 = false;

		GameObject player = GameObject.Find ("player");
		player.GetComponent<playerHp> ().hideHP = true;
		player.GetComponent<playerMP> ().hideMP = true;
		player.GetComponent<gearCount> ().hideGearCount = true;

		GameObject testPlatform = GameObject.Find ("testPlatform");
		GameObject testPlatform2 = GameObject.Find ("testPlatform2");
		testPlatform.renderer.enabled = false;
		testPlatform2.renderer.enabled = false;



	}
	
	// Update is called once per frame
	void Update () {

//		GameObject mpParticles = GameObject.Find ("mpParticles");
//		if (tut1) mpParticles.particleSystem.Stop();
//		if (tut5) mpParticles.particleSystem.Play();


		//GameObject player = GameObject.Find("player");
		//hovering = player.GetComponent<playerController> ().hovering;

		//if (hovering) firstHover = 0;

		//print (firstHover);
	
	}

	void OnGUI() {
		if (tut1) {
			GUI.Box (new Rect (730, 20, Screen.width / 3, 20), "Use left and right arrow keys to run.", tutorialStyle);
		}

		else if (tut2) {
			GUI.Box (new Rect (730, 20, Screen.width / 3, 20), "Use up arrow to jump.", tutorialStyle);
		}

		else if (tut3) {
			GUI.Box (new Rect (730, 20, Screen.width / 3, 20), "Press up arrow again near top of jump to hover. Practice timing it correctly to get up on one of these platforms. A running start may help.", tutorialStyle2);
		}

		else if (tut4) {
			GUI.Box (new Rect (730, 20, Screen.width / 3, 20), "Press space to use a wind attack, which you can use to defeat enemies.", tutorialStyle);
		}

		else if (tut5) {
			GUI.Box (new Rect (730, 20, Screen.width / 3, 20), "Attacking uses up energy - the particles on your cloak indicate if you have enough to attack at any specific moment. They regenerate automatically over time.", tutorialStyle2);
		}

		else if (tut6) {
			GUI.Box (new Rect (730, 20, Screen.width / 3, 20), "This blue bar indicates your magic power overall, and depletes each time you attack. It also regenerates automatically, but more slowly than energy, so be careful.", tutorialStyle2);
		}

		else if (tut7) {
			GUI.Box (new Rect (730, 20, Screen.width / 3, 20), "Remember, enemies will be attacking you too! This red bar indicates your health. Find potions to regenerate your health.", tutorialStyle2);
		}

		else if (tut8) {
			GUI.Box (new Rect (730, 20, Screen.width / 3, 20), "In Wind City, you need a certain amount of gears to proceed to dangerous areas. How many you need is displayed here.", tutorialStyle2);
		}

		else if (tut9) {
			GUI.Box (new Rect (730, 20, Screen.width / 3, 20), "Ready to play? Hit 'next' again to begin your adventure! You can pause at anytime by hitting the ESC key.", tutorialStyle);
		}
	}
}
