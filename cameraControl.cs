using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
	
	public Transform target;
	public float normalCamSize = 5;
	public float zoomOutCamSize = 8;
	float playerStartHeight;
	public bool grounded;
	public bool respawned;
	float playerCurHeight;
	public Vector3 position;
	public float heightChangeRate = 0.1f;
	
	Animator anim;
	
	//public bool falling;
	public bool stopMovingCamera;
	
	float heightAdj;
	//float widthAdj;

	float old_pos;

	void Start () {
		Camera.main.orthographicSize = normalCamSize;
	}
	
	void Update () {
		
		position = transform.position;
		position.x = target.position.x;
		heightAdj = target.position.y + 0.5f;
		transform.position = position;
		
		heightAdj = target.position.y + 0.5f;
		
		GameObject player = GameObject.Find("player");
		grounded = player.GetComponent<playerController>().grounded;
		stopMovingCamera = player.GetComponent<playerHp>().stopMovingCamera;
		anim = player.GetComponent<Animator>();

		GameObject pauseMenu = GameObject.Find("pauseMenu");
		bool showMap = pauseMenu.GetComponent<pauseScreen>().showMap;

		
		//falling = player.GetComponent<playerHp>().falling;
		
		//print ("camera is" + (position.y - heightAdj) + "compared to current player height");
		
		//heightAdj = PLAYER'S Y-POSITION (height)
		//position.y = CAMERA'S Y-POSITION (height)

		if (showMap) {

			if (Camera.main.orthographicSize < 50) { 
				Camera.main.orthographicSize = Camera.main.orthographicSize + 1f;
			}
		}

		else {
			if (Camera.main.orthographicSize > 13) { 
				Camera.main.orthographicSize = Camera.main.orthographicSize - 1f;
			}
		}

//		else if (Camera.main.orthographicSize > 30) { 
//			Camera.main.orthographicSize = Camera.main.orthographicSize - 1f;
//		}
		
		if (grounded && Mathf.Abs (heightAdj - position.y) <= 1 && !stopMovingCamera) {
			//print ("difference is too small to bother changing camera height");
			transform.position = position;
		}
		
		else if(grounded) {
//			if (Camera.main.orthographicSize > normalCamSize) { 
//				Camera.main.orthographicSize = Camera.main.orthographicSize - 0.05f;
//			}
//			
			if (heightAdj - position.y > 10) { 
				//print ("PROBABLY JUST RESPAWNED");
				stopMovingCamera = false;
				position.x = target.position.x; //return camera to player immediately (otherwise have to wait while it slowly increases by 0.2f to return to wherever player respawned...)
				position.y = heightAdj;
			}
			
			else if (heightAdj > position.y && heightAdj != position.y) { //as long as player is higher than the camera...
				//print ("landed higher");
				position.y = position.y + 0.2f; //...add 0.2f to camera height
			}
			
			else if (heightAdj < position.y && heightAdj != position.y) { //as long as player is lower than the camera...
				//print ("landed lower");
				position.y = position.y - 0.2f; //...minus 0.2f from camera height
			}
			
			else if (heightAdj == position.y){ //if the player & camera height have 'met' in the middle...
				position.y = heightAdj; //just leave it
			}
			
			transform.position = position;
		}
		
		else if (!grounded && !stopMovingCamera) {
//			if (Camera.main.orthographicSize < zoomOutCamSize) { 
//				Camera.main.orthographicSize = Camera.main.orthographicSize + 0.05f;
//			}

			if(heightAdj - position.y > 9) { //as long as the player is more than 5 units higher than the camera...
				//position.y = Mathf.MoveTowards(position.y, heightAdj, 5 * Time.deltaTime);
				position.y = position.y + 0.3f;
				//print ("adjusting cam");
			}

			else if(heightAdj - position.y > 5) { //as long as the player is more than 5 units higher than the camera...
				//position.y = heightAdj - 5;
				//position.y = position.y + 0.2f; //... add 0.2f to camera height (means camera will only begin to move up once the player is a reasonable distance above it, so it's not jerky)

				position.y = Mathf.MoveTowards(position.y, heightAdj, 7 * Time.deltaTime);
				//position.x = Vector2.MoveTowards (position.x, target.position.x, 10 * Time.deltaTime);

				//print ("adjusting cam");
			}

			if(heightAdj < position.y) { //if player is lower than the camera at ALL...
				position.y = heightAdj; //make them equal (means camera will follow player smoothly if they're dropping)
			}
			
			else if (heightAdj == position.y){
				position.y = heightAdj;
			}

//			if(Mathf.Abs(old_pos - position.y) > 0.1) {
//				transform.position = position;
//				print ("too small difference  to change pos.y");
//			}

			if(Mathf.Abs(old_pos - position.y) < 0.1 && player.rigidbody2D.velocity.y > 0) {
				print ("too small difference  to change pos.y");
			}

			else transform.position = position;
		}
		
//		if (grounded && Camera.main.orthographicSize > normalCamSize) {
//			Camera.main.orthographicSize = Camera.main.orthographicSize - 0.05f;
//		}
		
		if (stopMovingCamera) {
			print ("STOP MOVING CAMERA");
			anim.SetBool("Ground",false);
			//position.y = position.y;
		}

		old_pos = position.y;
	}
}



//using UnityEngine;
//using System.Collections;
//
//public class cameraControl : MonoBehaviour {
	
//	public Transform target;
//	public float normalCamSize = 5;
//	public float zoomOutCamSize = 8;
//	float playerStartHeight;
//	public bool grounded;
//	public bool respawned;
//	float playerCurHeight;
//	public Vector3 position;
//	public float heightChangeRate = 0.1f;
//	
//	Animator anim;
//	
//	//public bool falling;
//	public bool stopMovingCamera;
//	
//	float heightAdj;
//	//float widthAdj;
//	
//	void Start () {
//		Camera.main.orthographicSize = normalCamSize;
//	}
//	
//	void Update () {
//		
//		position = transform.position;
//		position.x = target.position.x;
//		transform.position = position;
//		
//		heightAdj = target.position.y + 0.5f;
//		
//		GameObject player = GameObject.Find("player");
//		grounded = player.GetComponent<playerController>().grounded;
//		stopMovingCamera = player.GetComponent<playerHp>().stopMovingCamera;
//		anim = player.GetComponent<Animator>();
//		
//		//falling = player.GetComponent<playerHp>().falling;
//		
//		//print ("camera is" + (position.y - heightAdj) + "compared to current player height");
//		
//		//heightAdj = PLAYER'S Y-POSITION (height)
//		//position.y = CAMERA'S Y-POSITION (height)
//		
//		//if (grounded && Mathf.Abs (heightAdj - position.y) <= 1 && !stopMovingCamera) {
//		if (Mathf.Abs (heightAdj - position.y) <= 1 && !stopMovingCamera) {
//			//print ("difference is too small to bother changing camera height");
//			transform.position = position;
//		}
//		
//		else if(grounded) {
////			if (Camera.main.orthographicSize > normalCamSize) { 
////				Camera.main.orthographicSize = Camera.main.orthographicSize - 0.05f;
////			}
//			
//			if (heightAdj - position.y > 10) { 
//				//print ("PROBABLY JUST RESPAWNED");
//				stopMovingCamera = false;
//				position.x = target.position.x; //return camera to player immediately (otherwise have to wait while it slowly increases by 0.2f to return to wherever player respawned...)
//				position.y = heightAdj;
//			}
//			
//			else if (heightAdj > position.y && heightAdj != position.y) { //as long as player is higher than the camera...
//				//print ("landed higher");
//				position.y = position.y + 0.2f; //...add 0.2f to camera height
//			}
//			
//			else if (heightAdj < position.y && heightAdj != position.y) { //as long as player is lower than the camera...
//				//print ("landed lower");
//				position.y = position.y - 0.2f; //...minus 0.2f from camera height
//			}
//			
//			else if (heightAdj == position.y){ //if the player & camera height have 'met' in the middle...
//				position.y = heightAdj; //just leave it
//			}
//			
//			transform.position = position;
//		}
//		
//		else if (!grounded && !stopMovingCamera) {
////			if (Camera.main.orthographicSize < zoomOutCamSize) { 
////				Camera.main.orthographicSize = Camera.main.orthographicSize + 0.05f;
////			}
//
//
//			if(heightAdj - position.y > 5 && player.rigidbody2D.velocity.y > 0) { //as long as the player is more than 5 units higher than the camera...
//				position.y = position.y + 0.2f; //... add 0.2f to camera height (means camera will only begin to move up once the player is a reasonable distance above it, so it's not jerky)
//				print ("height adjusting camera now");
//				//position.y = heightAdj - 5;
//			}
//
////			if(player.rigidbody2D.velocity.y < 0 && heightAdj > position.y) {
////				//position.y = heightAdj - 5;
////				position.y = position.y - 0.05f;
////			}
//
//			if(heightAdj < position.y) { //if player is lower than the camera at ALL...
//				position.y = heightAdj; //make them equal (means camera will follow player smoothly if they're dropping)
//			}
//			
//			else if (heightAdj == position.y){
//				position.y = heightAdj;
//			}
//
//			transform.position = position;
//		}
//		
////		if (grounded && Camera.main.orthographicSize > normalCamSize) {
////			Camera.main.orthographicSize = Camera.main.orthographicSize - 0.05f;
////		}
//		
//		if (stopMovingCamera) {
//			//print ("STOP MOVING CAMERA");
//			anim.SetBool("Ground",false);
//			//position.y = position.y;
//		}
//	}
//}



//using UnityEngine;
//using System.Collections;
//
//public class cameraControl : MonoBehaviour {
//	
//	public Transform target;
//	public float normalCamSize = 5;
//	public float zoomOutCamSize = 8;
//	float playerStartHeight;
//	public bool grounded;
//	public bool respawned;
//	float playerCurHeight;
//	public Vector3 position;
//	public float heightChangeRate = 0.1f;
//	
//	Animator anim;
//
//	public bool stopMovingCamera;
//	
//	float heightAdj;
//
//	bool highJump;
//	
//	void Start () {
//		Camera.main.orthographicSize = normalCamSize;
//	}
//	
//	void Update () {
//		
//		position = transform.position;
//		position.x = target.position.x;
//		transform.position = position;
//		
//		heightAdj = target.position.y + 0.5f;
//		
//		GameObject player = GameObject.Find("player");
//		grounded = player.GetComponent<playerController>().grounded;
//		stopMovingCamera = player.GetComponent<playerHp>().stopMovingCamera;
//		anim = player.GetComponent<Animator>();
//
//		//heightAdj = PLAYER'S Y-POSITION (height)
//		//position.y = CAMERA'S Y-POSITION (height)
//		
//		if (grounded && Mathf.Abs (heightAdj - position.y) <= 2 && !stopMovingCamera) {
//			//print ("difference is too small to bother changing camera height");
//			transform.position = position;
//			highJump = false;
//		}
//		
//		else if(grounded) {
//			highJump = false;
//
//			if (heightAdj - position.y > 10) { 
//				//print ("PROBABLY JUST RESPAWNED");
//				stopMovingCamera = false;
//				position.x = target.position.x; //return camera to player immediately (otherwise have to wait while it slowly increases by 0.2f to return to wherever player respawned...)
//				position.y = heightAdj;
//			}
//			
//			else if (heightAdj > position.y && heightAdj != position.y) { //as long as player is higher than the camera...
//				//print ("landed higher");
//				position.y = position.y + 0.2f; //...add 0.2f to camera height
//			}
//			
//			else if (heightAdj < position.y && heightAdj != position.y) { //as long as player is lower than the camera...
//				//print ("landed lower");
//				position.y = position.y - 0.2f; //...minus 0.2f from camera height
//			}
//			
//			else if (heightAdj == position.y){ //if the player & camera height have 'met' in the middle...
//				position.y = heightAdj; //just leave it
//			}
//			
//			transform.position = position;
//		}
//		
//		else if (!grounded && !stopMovingCamera) {
//
//			if(heightAdj - position.y > 5 && heightAdj - position.y < 14) { //as long as the player is more than 5 units higher than the camera...
//				position.y = position.y + 0.3f; //... add 0.2f to camera height (means camera will only begin to move up once the player is a reasonable distance above it, so it's not jerky)
//			}
//
////			if(heightAdj - position.y > 9f) {
////				position.y = heightAdj - 9f;
////				highJump = true;
////			}
//
////			if (player.rigidbody2D.velocity.y < 0 && highJump) {
////
////				if (position.y < heightAdj) {
////					position.y = position.y + 0.0005f;
////				}
////
////			}
//
////			if (heightAdj - position.y > 5 && !highJump) { //as long as the player is more than 5 units higher than the camera...
////				position.y = position.y + 0.3f; //... add 0.2f to camera height (means camera will only begin to move up once the player is a reasonable distance above it, so it's not jerky)
////			}
//
//			else if(heightAdj < position.y) { //if player is lower than the camera at ALL...
//				position.y = heightAdj; //make them equal (means camera will follow player smoothly if they're dropping)
//			}
//			
//			else if (heightAdj == position.y){
//				position.y = heightAdj;
//			}
//			//else position.y = heightAdj;
//
////			if(Mathf.Abs (heightAdj - position.y) <= 2) {
////				transform.position = position;
////			}
//
//			transform.position = position;
//		}
//
//		//print ("camera is " +  (heightAdj - position.y) + " too low");
//
//		if (stopMovingCamera) {
//			//print ("STOP MOVING CAMERA");
//			anim.SetBool("Ground",false);
//		}
//
//	}
//}

//using UnityEngine;
//using System.Collections;
//
//public class cameraControl : MonoBehaviour {
//
//	public Transform target;
//	public float normalCamSize = 5;
//	public float zoomOutCamSize = 8;
//	float playerStartHeight;
//	public bool grounded;
//	public bool respawned;
//	float playerCurHeight;
//	public Vector3 position;
//	public float heightChangeRate = 0.1f;
//
//	Animator anim;
//
//	//public bool falling;
//	public bool stopMovingCamera;
//
//	float heightAdj;
//	//float widthAdj;
//	
//	void Start () {
//		Camera.main.orthographicSize = normalCamSize;
//	}
//
//	void Update () {
//		position = transform.position;
//		position.x = target.position.x;
//		transform.position = position;
//
//		//print ("cameraPos " + position.y);
//
//		heightAdj = target.position.y + 0.5f;
//
//		GameObject player = GameObject.Find("player");
//		grounded = player.GetComponent<playerController>().grounded;
//		stopMovingCamera = player.GetComponent<playerHp>().stopMovingCamera;
//		anim = player.GetComponent<Animator>();
//
//		//bool visible = player.renderer.isVisible;
//
//		//falling = player.GetComponent<playerHp>().falling;
//
//		//print ("camera is" + (position.y - heightAdj) + "compared to current player height");
//
//		//heightAdj = PLAYER'S Y-POSITION (height)
//		//position.y = CAMERA'S Y-POSITION (height)
//
//		//print ("difference is " + (heightAdj - position.y));
//
//		//if (grounded && Mathf.Abs (heightAdj - position.y) <= 1 && !stopMovingCamera) {
//		if (grounded && Mathf.Abs (heightAdj - position.y) <= 1) {
//			//print ("difference is too small to bother changing camera height");
//			transform.position = position;
//		}
//
//		else if(grounded) {
//
//			//print ("grounded");
//
////			if (Camera.main.orthographicSize > normalCamSize) { 
////				Camera.main.orthographicSize = Camera.main.orthographicSize - 0.05f;
////			}
//
//			if (heightAdj - position.y > 10) { 
//				//print ("PROBABLY JUST RESPAWNED");
//				stopMovingCamera = false;
//				position.x = target.position.x; //return camera to player immediately (otherwise have to wait while it slowly increases by 0.2f to return to wherever player respawned...)
//				position.y = heightAdj;
//			}
//
//			else if (heightAdj > position.y && heightAdj != position.y) { //as long as player is higher than the camera...
//				//print ("higher");
//				position.y = position.y + 0.2f; //...add 0.2f to camera height
//			}
//			
//			else if (heightAdj < position.y && heightAdj != position.y) { //as long as player is lower than the camera...
//				//print ("lower");
//				position.y = position.y - 0.2f; //...minus 0.2f from camera height
//			}
//
//			else if (heightAdj == position.y){ //if the player & camera height have 'met' in the middle...
//				position.y = heightAdj; //just leave it
//			}
//
//			transform.position = position;
//		}
//
//		else if (!grounded && !stopMovingCamera) {
//
//			//print (heightAdj-Screen.height);
//
//			//print ("NOT grounded");
//
////			if (Camera.main.orthographicSize < zoomOutCamSize) { 
////				Camera.main.orthographicSize = Camera.main.orthographicSize + 0.05f;
////			}
//
//			//if(heightAdj - position.y > 5 || player.rigidbody2D.velocity.y < 0) { //as long as the player is more than 5 units higher than the camera...
//			if(heightAdj - position.y > 8) {
//				position.y = position.y + 0.3f; //... add 0.2f to camera height (means camera will only begin to move up once the player is a reasonable distance above it, so it's not jerky)
////				position.y = heightAdj - 8;
////				highJump = true;
//				//print (player.rigidbody2D.velocity.y);
//
//			}
//
////			if (player.rigidbody2D.velocity.y < 0 && (heightAdj - position.y > 8)) {
////
////				//print ("falling from jump");
////
////				position.y = position.y - 0.2f;
////
//////				if (heightAdj - position.y > 6) {
//////					position.y = position.y + 0.01f;
//////				}
////				
////			}
//
//			if(heightAdj < position.y) { //if player is lower than the camera at ALL...
//				position.y = heightAdj;
//
////				if (position.y >= heightAdj - 8){
////					position.y = position.y - 0.2f;
//				}
//
//			else position.y = heightAdj - 8; //make them equal (means camera will follow player smoothly if they're dropping)
//		
//		}
//
//
////			if (position.y < heightAdj - 5) {
////				position.y = position.y + 0.3f;
////			}
//
//			else if (heightAdj == position.y){
//				position.y = heightAdj;
//			}
//
//			transform.position = position;
//		//}
//
////		if (grounded && Camera.main.orthographicSize > normalCamSize) {
////			Camera.main.orthographicSize = Camera.main.orthographicSize - 0.05f;
////		}
//
//		if (stopMovingCamera) {
//			//print ("STOP MOVING CAMERA");
//			anim.SetBool("Ground",false);
//			//position.y = position.y;
//		}
//	}
//}
