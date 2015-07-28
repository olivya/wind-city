using UnityEngine;
using System.Collections;

public class upController : MonoBehaviour {

	//GameObject tutorial = GameObject.Find ("tutorial");
	GameObject pressUp = GameObject.Find ("pressUp");
	
	void Start () {

	}

	void Update () {

		float currentTutorial = tutorialTriggers.currentTutorial;

		if (currentTutorial == 3) pressUp.renderer.enabled = true;
		else pressUp.renderer.enabled = false;

	}
}
