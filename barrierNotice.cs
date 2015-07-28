using UnityEngine;
using System.Collections;

public class barrierNotice : MonoBehaviour {

	public bool needLeverMessage = false;
	public GUIStyle leverNoticeStyle;

	// Use this for initialization
	void Start () {
		needLeverMessage = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay2D(Collider2D collider) {
		needLeverMessage = true;
	}
	
	void OnTriggerExit2D(Collider2D collider) {
		needLeverMessage = false;
	}
	
	void OnGUI() {
//		if (needLeverMessage) {
//			GUI.Box (new Rect (10, 500, Screen.width / 8, 20), "Need to find the lever to get past the gate", leverNoticeStyle);
//		}
	}
}
