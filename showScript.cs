using UnityEngine;
using System.Collections;

public class showScript : MonoBehaviour {

	public bool displayScript;


	public string thisMessage2;
	GameObject scroll;

	//GameObject scroll = GameObject.GetComponent<pickupScript> ();

	public bool pickedUp;
	public bool paused;

	float count = 1;

	// Use this for initialization
	void Start () {
		pickedUp = false;
		displayScript = false;

		thisMessage2 = "testing";

		//scroll = GameObject.FindWithTag ("scroll");
	}
	
	// Update is called once per frame
	void Update () {

		//scroll = GameObject.GetComponent<pickupScript> ();

		//thisMessage = scroll.GetComponent<pickupScript> ().thisMessage;

		//paused = GameObject.Find ("pauseMenu").GetComponent<pauseScreen> ().paused;

		if(pickedUp && Input.GetKeyDown(KeyCode.Return)) {
			//print ("show Script Put Down");

			pickedUp = false;
			//displayScript = false;
			//paused = false;
			//print ("...put down after viewing.");

			//print ("disappear");
			//Destroy(pickedUp.gameObject);
		}

		else if (pickedUp) {
			//displayScript = true;
			//print ("holding & displaying...");

			//thisMessage = scroll.GetComponent<pickupScript> ().thisMessage;

			//paused = true;
			//print ("show");
		}

	}

	void OnTriggerEnter2D(Collider2D collider) {
//		count = count - 1;


		pickupScript scrollPickedUp = collider.gameObject.GetComponent <pickupScript> ();

//		if (count > -1)
//		{
			if (scrollPickedUp) {
				pickedUp = true;

				thisMessage2 = collider.gameObject.GetComponent <pickupScript> ().thisMessage;

				//print (thisMessage2);

				// Destroy the shot
				Destroy(scrollPickedUp.gameObject); // Remember to always target the game object, otherwise you will just remove the script
		}

//		}
//
//		count = 1;
		//pickedUp = true;
		//if (pickedUp) print ("pickedUp = true");

		//pickupScript pickedUp = collider.gameObject.GetComponent<pickupScript> ();
		//thisMessage = collider.gameObject.GetComponent<pickupScript> ().thisMessage;
		//pickupScript message = collider.gameObject.GetComponent<pickupScript> ();

		//else displayScript = false;
	}

	void OnGUI() {
//		if (pickedUp) {
//			GUI.Box (new Rect (470, -40, 700, 700), "", GUIstyles.GetScrollStyle());
//			GUI.Box (new Rect (600, 70, 350, 380), thisMessage, GUIstyles.GetScrollTextStyle());
//
//		}
	}
}


