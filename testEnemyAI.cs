using UnityEngine;
using System.Collections;

public class testEnemyAI : MonoBehaviour {

	public bool facingRight;
	public bool noticed;
	public float distance;
	public float minDistance = 10;
	public Transform player;
	public bool tooClose;
	public float speed = 3f;
	Animator enemyAnim;
	public Transform shotPrefab;

	float shootingRate;
	private float shootCooldown;
	
	public float playerPosX;

	public float noticeCount = 30;

	bool aboutToRespawn;

//	GameObject player = GameObject.Find ("player");

	void Start () {
		shootCooldown = 0f;
		facingRight = true;
		noticed = false;
		enemyAnim = GetComponent<Animator>();
		tooClose = false;
		enemyAnim.SetFloat("Speed", 0);
		GameObject enemy;
		InvokeRepeating("Flip", 0f, Random.Range(1f,2f));
	}

	void OnTriggerStay2D(Collider2D other) {

		if (other.tag == "Player") {
			if(aboutToRespawn) noticed = false;
			else noticed = true;
			
			if (noticeCount > 0) noticeCount = noticeCount - 1;

			//print (noticeCount);

			if (!facingRight && !tooClose) {
					transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
					enemyAnim.SetFloat ("Speed", Mathf.Abs (speed));
			}

			if (facingRight && !tooClose) {
					transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
					enemyAnim.SetFloat ("Speed", Mathf.Abs (speed));
			}

			if (noticeCount == 0 && !aboutToRespawn) Attack (true);
		}
	}

	public void Attack(bool isEnemy){
		if (CanAttack) {
			shootCooldown = shootingRate;
			
			var shotTransform = Instantiate(shotPrefab) as Transform; // Create a new shot
			
			shotTransform.position = transform.position; // Assign position
			
			shotScript shot = shotTransform.gameObject.GetComponent<shotScript>(); // The is enemy property
			
			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}
			
			moveScript move = shotTransform.gameObject.GetComponent<moveScript>(); // Make the weapon shot always towards it
			
			if (move != null) {
				if(facingRight){
					move.direction = this.transform.right;
					shotTransform.localScale = new Vector2(-3, 3);
				}

				if(!facingRight){
					move.direction = this.transform.right * -1;
					//shotTransform.localScale = new Vector2(-3, 3);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Player") {
			noticed = false;
			noticeCount = 30;
		}
	}

	void Update () {
		GameObject player = GameObject.Find("player");
		playerPosX = player.GetComponent<playerController>().playerPosX;
		aboutToRespawn = player.GetComponent<playerHp> ().aboutToRespawn;

		enemyAnim.SetBool("Attack",noticed);

		shootingRate = Random.Range(0.2f, 1.7f);
		//print (shootingRate);

		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}

		distance = transform.position.x - playerPosX;

		if (noticed) CancelInvoke();
		if (!noticed && !IsInvoking("Flip")) InvokeRepeating("Flip", 0f, Random.Range(1f,2f));

		if (Mathf.Abs (distance) < 4.5f) {
			tooClose = true;
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
