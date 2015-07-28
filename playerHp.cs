using UnityEngine;
using System.Collections;

public class playerHp : MonoBehaviour {
	
	public int maxHealth = 10;
	public int curHealth = 10;
	public int lives = 3;
	private float healthBarlength;
	public bool respawned = false;
	public bool isEnemy = false; // // // // added not an enemy<<<<<<<<<<<<<new
	float gearCount;
	private float maxHealthBarWidth = Screen.width / 2.5f;
	public bool hideHP = false;
	public float blinkTime;
	//Vector3 playerPos;
	//Vector3 camPos;
	bool inTutorial;
	float timer = 0;
	public bool stopMovingCamera = false;
	public bool aboutToRespawn;

	public bool destroyPotion = false;

	public AudioClip potion;
	public AudioClip playerHit;

	float old_pos;

	float potionTimer;

	void Start () {
		healthBarlength = maxHealthBarWidth;
		blinkTime = 0;
		aboutToRespawn = false;
	}

	void Update () {
		inTutorial = false;

		if (Application.loadedLevelName == "Level01") {
			inTutorial = GameObject.Find ("tutorial").GetComponent<tutorialTriggers> ().inTutorial;
		}

		GameObject mainCamera = GameObject.Find("mainCamera");
		//playerPos = mainCamera.GetComponent<cameraControl>().transform.position;
		//camPos = mainCamera.GetComponent<cameraControl>().position;

		GameObject player = GameObject.Find("player");
		Animator anim = player.GetComponent<Animator>();
		float playerPosX = player.transform.position.x;

//		if (aboutToRespawn) {
//			playerPosX = old_pos;
//			anim.SetBool ("death", true);
//
//
//		}
//		else {
//			anim.SetBool ("death", false);
//			player.GetComponent<playerController>().enabled = true;
//		}

		respawned = false;
	
		AdjustcurHealth (0);
		
		if (blinkTime > 0) {



			blinkTime = blinkTime - 1;
			
			if (blinkTime % 4 != 0) {
				player.renderer.enabled = false;
			}
			
			else {
				player.renderer.enabled = true;
			}
		}
		else player.renderer.enabled = true;

		old_pos = player.transform.position.x;

		if (aboutToRespawn) {
			player.rigidbody2D.velocity = new Vector2 (0, player.rigidbody2D.velocity.y);
			playerPosX = old_pos;
		}

//		potionHeal healed = gameObject.GetComponent<potionHeal> ();
//
//		if (destroyPotion) {
//			potionTimer += Time.deltaTime;
//
//			if (potionTimer > 0.3) {
//				Destroy(healed.gameObject);
//				potionTimer = 0;
//				destroyPotion = false;
//			}
//		}

		//print ("old_pos " + old_pos);
		//print ("player transform x " + player.transform.position.x + "vs. playerPosX" + playerPosX);
	}
	
	void OnGUI() {

		if (!hideHP) {
			GUI.Box (new Rect (10, 10, maxHealthBarWidth, 30), "", GUIstyles.GetHPStyleBack());
			GUI.Box (new Rect (10, 90, maxHealthBarWidth, 45), " Lives remaining: " + lives, GUIstyles.GetLifeStyle());
			GUI.Box (new Rect (10, 10, healthBarlength, 30), "", GUIstyles.GetHPStyleFront());
		}
	}
	
	public void AdjustcurHealth (int adj) {
		GameObject player = GameObject.Find("player");
		Animator anim = player.GetComponent<Animator>();
		float playerPosX = player.transform.position.x;

		if(!inTutorial) {

			curHealth += adj;
			
			if(curHealth < 0){ curHealth = 0; }

			if(curHealth > maxHealth){ curHealth = maxHealth; }

			if(maxHealth < 1){ maxHealth = 1; }

			if(curHealth == 0 || curHealth < 0) {
				player.GetComponent<playerController>().enabled = false;
				anim.SetBool ("death", true);

				timer += Time.deltaTime;
				aboutToRespawn = true;
				print ("aboutToRespawn");

				//if(aboutToRespawn) playerPosX = old_pos;

				if(timer > 4){
					lives = lives - 1;
	
					if (lives < 0) {
						Application.LoadLevel (Application.loadedLevelName);
					}
	
					else {
						transform.position = GetComponent<checkPoint>().spawnPoint.position;
					}
	
					curHealth = 10;
					respawned = true;
					anim.SetBool ("death", false);
					player.GetComponent<playerController>().enabled = true;
					timer = 0;
					aboutToRespawn = false;

				}
			}

			healthBarlength = (Screen.width / 2.5f) * (curHealth / (float)maxHealth);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		// Is this a shot?
		enemyShotScript shot = collider.gameObject.GetComponent<enemyShotScript>();
		potionHeal healed = collider.gameObject.GetComponent<potionHeal> ();
		fallDetect fell = collider.gameObject.GetComponent<fallDetect> ();
		cameraFallDetect falling = collider.gameObject.GetComponent<cameraFallDetect> ();
		
		if (shot != null) {
			// Avoid friendly fire
			if (blinkTime == 0){
				if (shot.isEnemyShot != isEnemy) {
					audio.PlayOneShot (playerHit);
					AdjustcurHealth(-1);
					blinkTime = 60;
					// Destroy the shot
					Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
				}
			}
		}

		if (healed) {

			//potionTimer += Time.deltaTime;
			audio.PlayOneShot (potion);
			AdjustcurHealth(1);
			//destroyPotion = true;

			Destroy(healed.gameObject);
		}

		if (fell && inTutorial) {
				Application.LoadLevel (Application.loadedLevelName);
			}
			
		if (fell && !inTutorial) {
			lives = lives - 1;

			if (lives < 0) {
				Application.LoadLevel (Application.loadedLevelName);
			}

			else {
				transform.position = GetComponent<checkPoint>().spawnPoint.position;
			}
			
			curHealth = 10;
			respawned = true;
		}

		if (falling) {
			stopMovingCamera = true;
		}

		else stopMovingCamera = false;

	}
}

