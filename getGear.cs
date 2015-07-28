using UnityEngine;
using System.Collections;

public class getGear : MonoBehaviour {
	
	public bool gearObtained = true;
	//public AudioClip gearCollect;
	
	void Start () {
		
	}

	void Update(){

		//audio.PlayOneShot (gearCollect);

		if (Camera.main.orthographicSize > 13) { 
			renderer.enabled = false;
		} 

		else renderer.enabled = true;
	}
}
