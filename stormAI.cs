using UnityEngine;
using System.Collections;

public class stormAI : MonoBehaviour {
	
	public bool facingRight;
	public bool noticed;
	public float distance;
	public float minDistance = 10;
	public Transform player;
	public bool tooClose;
	public float speed = 2f;
	//Animator enemyAnim;
	//public Transform shotPrefab;

	public Transform bossShotPrefab;
	public Transform bossShotPrefab2;
	
	public float shootingRate = 1f;
	private float shootCooldown;
	
	public float playerPosX;
	
	public float noticeCount = 30;
	
	bool aboutToRespawn;

	float shotCount;
	float timer;

	//Vector2 originalPosition;

	GameObject stormCloud;

	public Vector3 originalPos;

	//	GameObject player = GameObject.Find ("player");
	
	void Start () {
		shootCooldown = 0f;
		facingRight = true;
		//noticed = false;
		//enemyAnim = GetComponent<Animator>();
		//tooClose = false;
		//enemyAnim.SetFloat("Speed", 0);
		GameObject enemy;
		//InvokeRepeating("Flip", 0f, Random.Range(1f,2f));

		stormCloud = GameObject.Find ("stormCloud");
		stormCloud.particleSystem.Play();

		//originalPosition = new Vector2(transform.position.x, transform.position.y);
		originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

		shotCount = 10;
	}
	
	void OnTriggerStay2D(Collider2D other) {
		
		if (other.tag == "Player") {

			if(!aboutToRespawn) Attack (true);

		}
	}
	
	public void Attack(bool isEnemy){
		if (CanAttack && shotCount > 0) {
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
				}
				
				if(!facingRight){
					move.direction = this.transform.right;
					shotTransform.localScale = new Vector2(-3, 3);
					shot2Transform.localScale = new Vector2(-3, 3);
					//shotTransform.localScale = new Vector2(-3, 3);
				}
			}

			shotCount = shotCount - 1;
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

		
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}

		//transform.Translate(speed * Time.deltaTime, transform.position.y - 1 * Time.deltaTime,0);
		//transform.position = new Vector3(Mathf.PingPong(transform.position.x, transform.position.x+3), transform.position.y, transform.position.z);

//		float x = Mathf.PingPong(Time.time, 3);
//		float y = gameObject.transform.position.y;
//		float z = gameObject.transform.position.z;
//		transform.position = new Vector3(x, y, z);

		float xMovement = Mathf.PingPong (Time.time * 2, 3);
		float yMovement = Mathf.PingPong(Time.time, 2);
		transform.position = originalPos + new Vector3(xMovement, yMovement, 0);

//		print ("x " + transform.position.x);
//		print ("y " + transform.position.y);

		if (shotCount == 0) {
			timer += Time.deltaTime;

			if (timer > Random.Range(2.0f, 4.0f)){
				//print (timer);
				//print ("SHOOTING BREAK");
				shotCount = 10;
				timer = 0;
			}
		}
//		
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
