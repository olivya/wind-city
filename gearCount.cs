using UnityEngine;
using System.Collections;

public class gearCount : MonoBehaviour {
	
	public int gearCounter = 0;
	//public GUIStyle gearStyle;

	public bool hideGearCount = false;

	public AudioClip gearCollect;

	float gearLoc = Screen.width / 2.5f - 162;

	// Use this for initialization
	void Start () {
	
	}

	void OnGUI() {
		if (!hideGearCount) {
			GUI.Box (new Rect (gearLoc, 90, Screen.width, 20), "Gears: " + gearCounter + "/10", GUIstyles.GetGearCountStyle());
		}
	}

	// Update is called once per frame
	void Update () {
		AdjustgearCount (0);
	
	}

	public void AdjustgearCount (int adj) {
		gearCounter += adj;
		if(gearCounter < 0){
			gearCounter = 0;
		}
	}
	void OnTriggerEnter2D(Collider2D collider) {
		getGear obtained = collider.gameObject.GetComponent<getGear> ();

			if (obtained) {
				AdjustgearCount(1);
				// Destroy the shot
				Destroy(obtained.gameObject); // Remember to always target the game object, otherwise you will just remove the script
				audio.PlayOneShot (gearCollect);
			}
		}
}
