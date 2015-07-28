using UnityEngine;
using System.Collections;

public class toLevel02 : MonoBehaviour {

	float gearCount;
	//public GUIStyle gearNoticeStyle;
	public bool notEnoughGears;
	public bool notEnoughMessage;
	public bool enoughMessage;

	// Use this for initialization
	void Start () {
		notEnoughGears = true;
		notEnoughMessage = false;
		enoughMessage = false;
		//gearCount = gearCount.GetComponent<enemyHp>();

	
	}
	
	// Update is called once per frame
	void Update () {

		GameObject player = GameObject.Find("player");
		gearCount = player.GetComponent<gearCount>().gearCounter;
		//print(gearCount);

		if (gearCount == 10) notEnoughGears = false;

	}

	void OnTriggerEnter2D(Collider2D collider) {

		if (collider.tag == "Player" && gearCount == 10) {
			//print ("to level 02");
			enoughMessage = true;

			if (Application.loadedLevelName == "Level01") {
				Application.LoadLevel ("level02c");
			}

			if (Application.loadedLevelName == "level02c") {
				Application.LoadLevel ("level03");
			}

			if (Application.loadedLevelName == "level03") {
				Application.LoadLevel ("level04");
			}
		}

	}

	void OnTriggerStay2D(Collider2D collider) {
				if (notEnoughGears) {
						notEnoughMessage = true;
				}
		}

		void OnTriggerExit2D(Collider2D collider) {
			if (notEnoughGears) { notEnoughMessage = false;
			}
	}

	void OnGUI() {
		if (Application.loadedLevelName != "level04") {
				if (notEnoughMessage) {
						GUI.Box (new Rect (10, 500, Screen.width / 8, 20), "Need all 10 gears to proceed to next level!", GUIstyles.GetMessageStyle ());
				}

				if (enoughMessage) {
						GUI.Box (new Rect (10, 500, Screen.width / 8, 20), "Loading next level...", GUIstyles.GetMessageStyle ());
				}
		}

		else if (Application.loadedLevelName == "level04")
				if (notEnoughMessage) {
						GUI.Box (new Rect (10, 500, Screen.width / 8, 20), "Need all 10 gears to face the boss!", GUIstyles.GetMessageStyle ());
				}
		}

	}


