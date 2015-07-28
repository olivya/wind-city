using UnityEngine;
using System.Collections;

public class bossAi : MonoBehaviour {
	
	public bool facingRight;
	public bool noticed;
	public float distance;
	public float minDistance = 10;
	public Transform player;
	public bool tooClose;
	public float speed = 3f;
	Animator enemyAnim;
	public Transform bossShotPrefab;
	public Transform bossShotPrefab2;
	
	public float shootingRate = 1f;
	private float shootCooldown;
	
	public BoxCollider2D body;
	public BoxCollider2D detection;
	
	
	public float playerPosX;
	
	void Start () {
		shootCooldown = 0f;
		facingRight = true;
		noticed = false;
		enemyAnim = GetComponent<Animator>();
		tooClose = false;
		enemyAnim.SetFloat("Speed", 0);
//		GameObject enemy;
		
		Invoke("Flip", 0f);
	}
	
	
	
	void OnTriggerStay2D(Collider2D other) {
		
		if (other.tag == "Player") {
			noticed = true;

			Attack (true);
		}
		
		//		if(other.tag == "windAtk") {
		//			Physics2D.IgnoreCollision(other.collider2D, detection);
		//			}
	}
	
	public void Attack(bool isEnemy){
		if (CanAttack) {
			shootCooldown = shootingRate;
			
			var shotTransform = Instantiate(bossShotPrefab) as Transform; // Create a new shot
			var shot2Transform = Instantiate (bossShotPrefab2) as Transform;
			
			shotTransform.position = new Vector2(transform.position.x, transform.position.y + 1); // Assign position
			shot2Transform.position = new Vector2(transform.position.x, transform.position.y - 4);
			
			shotScript shot = shotTransform.gameObject.GetComponent<shotScript>(); // The is enemy property
			
			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}
			
			moveScript move = shotTransform.gameObject.GetComponent<moveScript>(); // Make the weapon shot always towards it
		
			if (move != null) {
				if(facingRight){
					move.direction = this.transform.right * -1;
					//shotTransform.localScale = new Vector2(-3, 3);
				}
				
				if(!facingRight){
					move.direction = this.transform.right * 1;
					//shotTransform.localScale = new Vector2(-3, 3);
				}
			}
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			noticed = false;
		}
	}
	
	
	
	void Update () {

		Attack (true);
		
		enemyAnim.SetBool("Attack",noticed);
		
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
		
		GameObject player2 = GameObject.Find("player");
		playerPosX = player2.GetComponent<playerController>().playerPosX;
		
		distance = transform.position.x - playerPosX;
		
		//		distance = transform.position.x - player.position.x;
		//		//print (distance);
		//		
		//if (distance <= minDistance && distance > 0 && facingRight) {
		//		if (distance <= minDistance && distance > 0 && facingRight) {
		//			Flip ();
		//		}
		//
		//		//if (distance >= minDistance * -1 && distance < 0 && !facingRight) {
		//		if (distance >= minDistance * -1 && distance < 0 && !facingRight) {
		//			Flip ();
		//		}
		//		
		//		if (distance >= minDistance * -1 && distance < 0 && facingRight) noticed = true;
		//		else if (distance <= minDistance && distance > 0 && !facingRight) noticed = true;
		//		else noticed = false;
		
		//distance = transform.position.x - player.position.x;
		
		if (noticed) CancelInvoke();
		//if (!noticed && !IsInvoking("Flip")) InvokeRepeating("Flip", 0f, Random.Range(1f,2f));
		
		//		if (noticed && facingRight && !tooClose) {
		//			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		//			enemyAnim.SetFloat("Speed", Mathf.Abs(speed));
		//		}
		//		
		//		if (noticed && !facingRight && !tooClose) {
		//			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		//			enemyAnim.SetFloat("Speed", Mathf.Abs(speed));
		//		}
		
		//		if (Mathf.Abs (distance) < 2) {
		//			tooClose = true;
		//			enemyAnim.SetFloat("Speed", 0);
		//		}
		if (Mathf.Abs (distance) < 3.5f) {
			tooClose = true;
			//print ("tooClose");
			enemyAnim.SetFloat("Speed", 0);
		}
		
		else tooClose = false;
		
		if (!tooClose && !noticed) {
			enemyAnim.SetFloat ("Speed", 0);
		}
		
	}
	
	void Flip() {
		Vector3 theScale = transform.localScale; //get local scale...
		theScale.x *= -1; //...flip the x axis...
		transform.localScale = theScale; //...and  apply it back to local scale
		facingRight = !facingRight;
	}
	
	public bool CanAttack {
		get {
			return shootCooldown <= 0f;
		}
	}
}
