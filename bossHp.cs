using UnityEngine;
using System.Collections;

public class bossHp : MonoBehaviour {
	
	public int maxHealth = 15; //HP
	public bool isEnemy = true; //(this object is enemy)
	
	public int curHealth = 15; 
	public Vector3 screenPosition;
	public Transform target;
	private float healthBarlength;
	private float maxHealthBarlength;
	public GUIStyle enemyHealthStyle;
	public Vector3 originalPos;
	GameObject storm;
	public float blinkTime;

	public AudioClip bossHit;

	//initialization
	void Start () {
		maxHealthBarlength = Screen.width / 8;
		healthBarlength = maxHealthBarlength;

		storm = GameObject.Find("storm2");
		blinkTime = 0;

	}
	
	//called once per frame
	void Update () {
		screenPosition = Camera.main.WorldToScreenPoint(target.position);
		screenPosition.y = Screen.height - screenPosition.y;

		if (blinkTime > 0) {
			audio.PlayOneShot (bossHit);
			blinkTime = blinkTime - 1;
			
			if (blinkTime % 5 != 0) {
				storm.renderer.enabled = false;
			}
			
			else {
				storm.renderer.enabled = true;
			}
		}
		else storm.renderer.enabled = true;
	}
	
	void OnGUI() {

		GUI.Box (new Rect (screenPosition.x, screenPosition.y - 40, maxHealthBarlength, 20), "", GUIstyles.GetEnemyHPStyleBack());
		GUI.Box (new Rect (screenPosition.x, screenPosition.y - 40, healthBarlength, 20), "", GUIstyles.GetEnemyHPStyleFront());
		
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
			Destroy(storm.gameObject);
		}
		
		healthBarlength = (curHealth / (float) maxHealth) * maxHealthBarlength;

		print (curHealth);
	}

	void OnTriggerStay2D(Collider2D collider) {
		shotScript shot = collider.gameObject.GetComponent<shotScript>(); //variable of type shotScript that is called shot, setting it to whether the object that collided has a shotScript or not
		if(shot != null) {
			if (blinkTime == 0){
				if (shot.isEnemyShot != isEnemy) {
					//audio.PlayOneShot (bossHit);
					AdjustcurHealth(-1);
					blinkTime = 20;
					Destroy(shot.gameObject);
				}
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		slashScript slash = collider.gameObject.GetComponent<slashScript> (); //variable of type shotScript that is called shot, setting it to whether the object that collided has a shotScript or not
		if (slash != null) {
			if (slash.isEnemyShot != isEnemy) {
				AdjustcurHealth (-1);
				Destroy (slash.gameObject);
			}
		}
	}
	
}
