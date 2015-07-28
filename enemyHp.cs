using UnityEngine;
using System.Collections;

public class enemyHp : MonoBehaviour {
	
	public int maxHealth = 3; //HP
	public bool isEnemy = true; //(this object is enemy)
	
	public int curHealth = 3; 
	public Vector3 screenPosition;
	public Transform target;
	private float healthBarlength;
	private float maxHealthBarlength;
	public GUIStyle enemyHealthStyle;

	public AudioClip enemyDeath;

	float timer;
	
	//initialization
	void Start () {
		maxHealthBarlength = Screen.width / 8;
		healthBarlength = maxHealthBarlength;
	}
	
	//called once per frame
	void Update () {
		screenPosition = Camera.main.WorldToScreenPoint(target.position);
		screenPosition.y = Screen.height - screenPosition.y;

		if(curHealth == 0) {
			
			timer += Time.deltaTime;
			
			print (timer);
			
			if (timer > 0.3) {
				Destroy(gameObject);
				timer = 0;
			}

		}


	}
	
	void OnGUI() {
		if (gameObject.GetComponent<testEnemyAI> ().noticed || curHealth != 3) { //displays health if spotted OR if enemy has already taken damage
			GUI.Box (new Rect (screenPosition.x - 55, screenPosition.y - 90, maxHealthBarlength, 20), "", GUIstyles.GetEnemyHPStyleBack());
			//GUI.Box (new Rect (screenPosition.x - 55, screenPosition.y - 90, healthBarlength, 20), curHealth + "/" + maxHealth, GUIstyles.GetEnemyHPStyleFront());
			GUI.Box (new Rect (screenPosition.x - 55, screenPosition.y - 90, healthBarlength, 20), "", GUIstyles.GetEnemyHPStyleFront());
		}
		
	}
	
	public void AdjustcurHealth (int adj) {
		curHealth += adj;
		if(curHealth < 0){
			curHealth = 0;
		}
		if(curHealth > maxHealth){
			curHealth = maxHealth;
		}
		if(maxHealth < 1){			
			maxHealth = 1;
		}

		if(curHealth == 0) {

			audio.PlayOneShot (enemyDeath);
		}
		
		healthBarlength = (curHealth / (float)maxHealth) * maxHealthBarlength;
	}
	
	//(check collision and makes AdjustcurHealth int = 1, and minus from curHealth)
	void OnTriggerStay2D(Collider2D collider) {
		//Is this a shot?
		shotScript shot = collider.gameObject.GetComponent<shotScript>(); //variable of type shotScript that is called shot, setting it to whether the object that collided has a shotScript or not
		if(shot != null) {
			//avoid friendly fire
			if (shot.isEnemyShot != isEnemy) {
				AdjustcurHealth(-1);
				//destroy the shot
				//remember to always target the game object, otherwise you will just remove the script
				Destroy(shot.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		slashScript slash = collider.gameObject.GetComponent<slashScript> (); //variable of type shotScript that is called shot, setting it to whether the object that collided has a shotScript or not
		if (slash != null) {
			//avoid friendly fire
			if (slash.isEnemyShot != isEnemy) {
				AdjustcurHealth (-1);
				//destroy the shot
				//remember to always target the game object, otherwise you will just remove the script
				Destroy (slash.gameObject);
			}
		}
	}

}
