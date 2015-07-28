using UnityEngine;
using System.Collections;

public class playerMP : MonoBehaviour {
	
	public int maxMagic = 10;
	public int curMagic = 10;
	private float magicBarlength;
	private float maxMagicBarWidth = Screen.width / 2.5f;
	public GUIStyle magicStyleFront;
	public GUIStyle magicStyleBack;
	public float timeSinceLastMagicIncrease;
	
	public bool hideMP = false;

	bool inTutorial;
	
	// Use this for initialization
	void Start () {
		magicBarlength = maxMagicBarWidth;
	}
	
	// Update is called once per frame
	void Update () {

		inTutorial = false;
		if (Application.loadedLevelName == "Level01") {
			inTutorial = GameObject.Find ("tutorial").GetComponent<tutorialTriggers> ().inTutorial;
		}

		if (Time.time - timeSinceLastMagicIncrease > 6) {
			AdjustCurMagic(1);
			timeSinceLastMagicIncrease = Time.time;
		}
		
		if (GameObject.Find ("player").GetComponent<playerHp> ().respawned) {
			AdjustCurMagic (10);
		}
		
	}
	
	void OnGUI() {
		if (!hideMP) {
			GUI.Box (new Rect (10, 50, maxMagicBarWidth, 30), "", magicStyleBack);
			GUI.Box (new Rect (10, 50, magicBarlength, 30), "", magicStyleFront);
			//GUI.Box (new Rect (10, 50, magicBarlength, 20), "", GUIstyles.GetMPStyleFront());


		}
	}
	
	public void AdjustCurMagic (int adj) {
		//if (!inTutorial) {
			curMagic += adj;
			if (curMagic < 0) {
					curMagic = 0;
			}

			if (curMagic > maxMagic) {
					curMagic = maxMagic;
			}

			if (maxMagic < 1) {
					maxMagic = 1;
			}

			magicBarlength = (Screen.width / 2.5f) * (curMagic / (float)maxMagic);
		//}

		//else print ("NOT ADJUSTING MAGIC POWER BECAUSE IN TUTORIAL.");
	}
	
	public bool enoughMagicToAttack() {
		return curMagic > 0;
	}	
}

