using UnityEngine;
using System.Collections;

public class tutorialStartButtonController : MonoBehaviour {
	
	public void OnClick(){
		Application.LoadLevel ("startMenu");
	}
}
