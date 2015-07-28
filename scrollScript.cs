using UnityEngine;
using System.Collections;

public class scrollScript : MonoBehaviour {

	public float speed = 0;
	float dir;
	bool paused;

	float old_pos;

	
	void Start () {

		GameObject player = GameObject.Find("player");
		old_pos = player.transform.position.x;

	}

	void Update () {

		paused = GameObject.Find ("pauseMenu").GetComponent<pauseScreen> ().paused;

		GameObject player = GameObject.Find("player");
		float move = player.GetComponent<playerController>().move;


		if (move > 0) dir = 1;
		if (move < 0) dir = -1;

		//if (!paused && old_pos != player.transform.position.x) {
		if (!paused && Mathf.Abs(player.transform.position.x - old_pos) > 0.01f) {
			renderer.material.mainTextureOffset = new Vector2 (renderer.material.mainTextureOffset.x + move * speed, 0f);
		}

		//Mathf.Abs(player.transform.position.x - old_pos)
		//print (Mathf.Abs(player.transform.position.x - old_pos));

//		if(old_pos < player.transform.position.x){
//			//print("moving right");
//		}
//
//		if(old_pos > player.transform.position.x){
//			//print("moving left");
//		}

		old_pos = player.transform.position.x;
	}
}

