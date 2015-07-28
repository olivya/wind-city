using UnityEngine;
using System.Collections;

public class nextButtonController : MonoBehaviour {

	public void Start(){

		GameObject player = GameObject.Find ("player");
//		player.GetComponent<playerHp> ().hideHP = true;
//		player.GetComponent<playerMP> ().hideMP = true;
	
		}
	
	public void OnClick(){

		//Debug.Log ("next button clicked");

		GameObject tutorialHolder = GameObject.Find("tutorialHolder"); 
		GameObject player = GameObject.Find("player");
		//GameObject mpParticles = GameObject.Find("mpParticles");
		GameObject testPlatform = GameObject.Find ("testPlatform");
		GameObject testPlatform2 = GameObject.Find ("testPlatform2");

//		bool tut1 = tutorialHolder.GetComponent<tutorialPopups>().tut1;
//		bool tut2 = tutorialHolder.GetComponent<tutorialPopups>().tut2;

		if (tutorialHolder.GetComponent<tutorialPopups>().tut1) {
			tutorialHolder.GetComponent<tutorialPopups>().tut1 = false;
			tutorialHolder.GetComponent<tutorialPopups>().tut2 = true;
		}

		else if (tutorialHolder.GetComponent<tutorialPopups>().tut2) {
			tutorialHolder.GetComponent<tutorialPopups>().tut2 = false;
			tutorialHolder.GetComponent<tutorialPopups>().tut3 = true;
			testPlatform.renderer.enabled = true;
			testPlatform2.renderer.enabled = true;
		}

		else if (tutorialHolder.GetComponent<tutorialPopups>().tut3) {
			tutorialHolder.GetComponent<tutorialPopups>().tut3 = false;
			tutorialHolder.GetComponent<tutorialPopups>().tut4 = true;
		}

		else if (tutorialHolder.GetComponent<tutorialPopups>().tut4) {
			tutorialHolder.GetComponent<tutorialPopups>().tut4 = false;
			tutorialHolder.GetComponent<tutorialPopups>().tut5 = true;
			//mpParticles.particleSystem.Play();
		}

		else if (tutorialHolder.GetComponent<tutorialPopups>().tut5) {
			tutorialHolder.GetComponent<tutorialPopups>().tut5 = false;
			tutorialHolder.GetComponent<tutorialPopups>().tut6 = true;
			player.GetComponent<playerMP> ().hideMP = false;
		}

		else if (tutorialHolder.GetComponent<tutorialPopups>().tut6) {
			tutorialHolder.GetComponent<tutorialPopups>().tut6 = false;
			tutorialHolder.GetComponent<tutorialPopups>().tut7 = true;
			player.GetComponent<playerHp> ().hideHP = false;
		}

		else if (tutorialHolder.GetComponent<tutorialPopups>().tut7) {
			tutorialHolder.GetComponent<tutorialPopups>().tut7 = false;
			tutorialHolder.GetComponent<tutorialPopups>().tut8 = true;
			player.GetComponent<gearCount> ().hideGearCount = false;
		}

		else if (tutorialHolder.GetComponent<tutorialPopups>().tut8) {
			tutorialHolder.GetComponent<tutorialPopups>().tut8 = false;
			tutorialHolder.GetComponent<tutorialPopups>().tut9 = true;
		}

		else if (tutorialHolder.GetComponent<tutorialPopups>().tut9) {
			Application.LoadLevel("PROTOTYPE01");
		}

		//print ("tut1 is " + tutorialHolder.GetComponent<tutorialPopups>().tut1);
		//print ("tut2 is " + tutorialHolder.GetComponent<tutorialPopups>().tut2);

		
		//Application.LoadLevel ("Level02");
	}
}
