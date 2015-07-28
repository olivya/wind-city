using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	
	public float maxSpeed = 10f;
	public float dropSpeed = 10f;
	public bool facingRight = true;
	Animator anim; //reference to Animator
	
	//set up for falling:
	public bool grounded = false; //check if on ground (starts slightly above)
	public Transform groundCheck; //create another object to represent where the ground should be in relation to the character
	float groundRadius = 0.3f; //how big our sphere is going to be when we check for the ground
	public LayerMask whatIsGround; //need to tell character what is considered ground - water? bullet? enemies? (what can the character land on?)
	public float jumpForce = 700f;
	
	// set up for hovering
	float hoverForce; //amount of boost when initiating hover
	public float hoverGravity = 0.5f;
	public float totalHoverTime = 10;
	float hoverTimeRemaining;
	bool hovering = false; //meaning we've not yet used our hover
	public float dropGravity = 3f;
	public Transform other;
	public bool movingRight;
	public bool movingLeft;
	public bool stopMovingCamera;
	public float move;
	public float playerPosX;
	public float timer;
	public float shootTimer;
	public bool isAttacking;
	windAtkScript weapon;

	bool shoot = false;

	public bool facingRightNow;

	GameObject mpParticles;

	bool aboutToRespawn;

	//public AudioClip grunt;

	void Awake () {

	}
	
	void Start () {
		anim = GetComponent<Animator>();
		movingRight = false;
		movingLeft = false;

		mpParticles = GameObject.Find ("mpParticles");
		//mpParticles.particleSystem.Clear();

		//aboutToRespawn = gameObject.GetComponent<playerHp> ().aboutToRespawn;
	}

	void FixedUpdate () {
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); //constantly check if we're on the ground - are we hitting any colliders in this ground detecting circle? will return true or false

		anim.SetBool("Ground",grounded);
		
		if(grounded) {
			hovering = false; //resets hover
			hoverTimeRemaining = 0;
			rigidbody2D.gravityScale = 1f; //returns gravity to normal after hovering
		}
		
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y); //every frame saying "this is how fast we're moving up/down" 
		move = Input.GetAxis("Horizontal"); //by default Input.GetAxis is mapped to the arrow keys
		anim.SetFloat("Speed", Mathf.Abs(move)); //absolute value because you don't care if you're moving left or right, just the speed. the animator handles the rest.

		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y); //taking current velocity, moving left or right based on what key pressed * maxSpeed, leaving y the same
		//else if(aboutToRespawn) rigidbody2D.velocity = new Vector2(0, 0);

		if (move > 0 && facingRight)//if move (input) is greater than zero, and we're not facing right, flip.
			Flip ();
		else if(move < 0 && !facingRight) //else, if move is less than zero, and are ARE facing right, flip.
			Flip();
	}

	void Update() { //read more accurately than FixedUpdate, pressing spacebar might be missed otherwise




		//print ("playerPos " + transform.position.y);

				float move = Input.GetAxis ("Horizontal");
				playerPosX = transform.position.x;
		
				if (move > 0) {
						movingRight = true;
						movingLeft = false;
				}
				if (move < 0) {
						movingLeft = true;
						movingRight = false;
				}
		
				if (move == 0) {
						movingRight = false;
						movingLeft = false;
				}

//		bool shoot = Input.GetKeyDown (KeyCode.Space);
//
//		if (shoot) {
//			windAtkScript weapon = GetComponent<windAtkScript> ();
//			if (weapon != null) {
//					weapon.doAttack (false); //false because the player is not an enemy
//			}
//		}

		
		GameObject player = GameObject.Find("player");
		bool CanAttack = player.GetComponent<windAtkScript>().CanAttack;
		GameObject mpParticles = GameObject.Find ("mpParticles");

		if (Input.GetKeyDown (KeyCode.Space) && !shoot && !isAttacking && CanAttack && Time.timeScale == 1) {
			//shoot = true;
			if (facingRight) facingRightNow = true;
			else if (!facingRight) facingRightNow = false;

			isAttacking = true;
			//mpParticles.particleSystem.Play();
		}

		//else mpParticles.particleSystem.Stop();

//		if (shoot) {
//			shootTimer += Time.deltaTime;
//			print (shootTimer);
//			//print (timer);
//
//			if (shootTimer > 0.3){
//				windAtkScript weapon = GetComponent<windAtkScript>();
//				if (weapon != null) {
//					weapon.doAttack(false); //false because the player is not an enemy
//					shootTimer = 0;
//					shoot = false;
//				}
//			}
//			else shoot = true;
//		}
//		
//		if (Input.GetKeyDown(KeyCode.Space) && CanAttack && !isAttacking) {
//			anim.SetBool("isAttacking",true);
//			isAttacking = true;
//		}

		//TO DO: revert shooting mechs, lower cool down rate, make unable to instantiate new bullet while animation is palying

		weapon = GetComponent<windAtkScript>();
		
		if(isAttacking){
			anim.SetBool("isAttacking",true);
			timer += Time.deltaTime;

			if (timer > 0.3){
				if (weapon != null) {
					weapon.doAttack(false); //false because the player is not an enemy
				}
			}

			if (timer > 0.4){
				anim.SetBool("isAttacking",false);
				timer = 0;
				isAttacking =false;
			}
		}

		bool atk = Input.GetKeyDown (KeyCode.C);
		
		if (atk) {
			closeAtkScript melee = GetComponent<closeAtkScript>();
			if (melee != null){
				melee.doAttack (false);
			}
		}

		//float verticalSpeed = rigidbody2D.velocity.y;
		
		///// JUMPING ////
		
		if(grounded && Input.GetKeyDown(KeyCode.UpArrow) && Time.timeScale == 1) { //should go to input manager and create a jump axis or jump button and then just say jump so it's re-mappable for players
			anim.SetBool("Ground",false); //immediately say we are no longer on the ground
			rigidbody2D.AddForce(new Vector2(0,jumpForce)); //add force, so 'we're jumping now'
			//print("Jump gravity is " + rigidbody2D.gravityScale);
			//audio.PlayOneShot (grunt);
		}

		///// HOVERING ////

		//if(!grounded && !hovering && Input.GetKeyDown(KeyCode.UpArrow)) {
		if(!grounded && Input.GetKeyDown(KeyCode.UpArrow) && Time.timeScale == 1) {
				rigidbody2D.AddForce(new Vector2(0,hoverForce)); 
				//hovering = true;
				rigidbody2D.gravityScale = hoverGravity;
				hoverTimeRemaining = totalHoverTime;
				hoverForce = hoverForce - 40f;
		}
		
		//timer to limit how long player can hover
		if(hoverTimeRemaining > 0) {
			//hovering = true;
			hoverTimeRemaining = hoverTimeRemaining - 1;
		}
		
		if(hoverTimeRemaining == 0) {
			rigidbody2D.gravityScale = 1f; //return gravity to normal after set time
			//if(grounded);
			//hovering = false;
		}

		if (grounded) {
			hoverForce = 200f;
			rigidbody2D.gravityScale = 1f;
		}

		//dropping
		if(!grounded && Input.GetKey(KeyCode.DownArrow)) { //if player holds down key while hovering, will fall faster
			rigidbody2D.gravityScale = dropGravity;
		}
		
		if(!grounded && Input.GetKeyDown(KeyCode.DownArrow)) {
			//print("*** Drop gravity INITIATED and is now "+rigidbody2D.gravityScale+" ***");
		}
		
		if(!grounded && Input.GetKeyUp(KeyCode.DownArrow)) { //if player releases down key while not grounded, gravity will return to either hovering or regular levels (depending on if hover timer is still counting down)
//			if(hovering)
//				rigidbody2D.gravityScale = hoverGravity;
//			if(!hovering)
				rigidbody2D.gravityScale = 1f;
			//print("*** Drop gravity CANCELLED and is now "+rigidbody2D.gravityScale+" ***");
		}

		//print (rigidbody2D.gravityScale);
	}

	void OnTriggerStay2D(Collider2D collider) {
		slopeDetect onSlope = collider.gameObject.GetComponent<slopeDetect>();

		if (onSlope) {
			grounded = true;
			anim.SetBool ("Ground", grounded);
		}

		//if (grounded && onSlope) print ("grounded & on slope");
	}

	void Flip() {
		facingRight = !facingRight; //facing left
		Vector2 theScale = transform.localScale; //get local scale...
		theScale.x *= -1; //...flip the x axis...
		transform.localScale = theScale; //...and  apply it back to local scale
	}
}
