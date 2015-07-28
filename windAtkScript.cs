//this script controls cool down on the shooting and instantiates prefab

using UnityEngine;

public class windAtkScript : MonoBehaviour {
	
	public Transform shotPrefab;
	public float shootingRate = 0.5f;
	
	private float shootCooldown;
	public bool facingRight;

	GameObject player;

	public AudioClip windAtk;

	void Start() {
		shootCooldown = 0f;
		player = GameObject.Find("player");
	}
	
	void Update() {
		//ParticleSystem mpParticles = (ParticleSystem)gameObject.GetComponent("mpParticles");
		//GameObject player = GameObject.Find ("player");
		//GameObject mpParticles = GameObject.Find ("mpParticles");

		playerMP pmp = gameObject.GetComponent<playerMP> ();

		if (shootCooldown > 0 || pmp.curMagic == 0) {
			//mpParticles.particleSystem.Clear();
			//print("particles stopped");
			//Debug.Log (mpParticles);
			shootCooldown -= Time.deltaTime;
		}

		//else mpParticles.Play();


	}

	public void Attack (bool isEnemy)
	{
		playerMP pmp = gameObject.GetComponent<playerMP> (); 
		if(pmp.enoughMagicToAttack()) {

			doAttack(isEnemy);
		}
	}
	
	public void doAttack(bool isEnemy)
	{
		playerMP pmp = gameObject.GetComponent<playerMP> ();
		
		if (CanAttack && pmp.curMagic > 0)
		{
			shootCooldown = shootingRate;
			bool facingRightNow = gameObject.GetComponent<playerController>().facingRightNow;

			//facingRight = gameObject.GetComponent<playerController>().facingRight;

			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			pmp.AdjustCurMagic (-1); //only decrease if shot is actually instantiated
			audio.PlayOneShot (windAtk);

			// Assign position (adjusts posi;tion x so it instantiates in front of the player)
			if (facingRightNow) {
				shotTransform.position = new Vector2(transform.position.x - 1, transform.position.y - 0.75f);
			}
			if (!facingRightNow) {
				shotTransform.position = new Vector2(transform.position.x + 1, transform.position.y - 0.75f);
			}
			
			// The is enemy property
			shotScript shot = shotTransform.gameObject.GetComponent<shotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Make the weapon shot always towards it
			moveScript move = shotTransform.gameObject.GetComponent<moveScript>();
			
			if (move != null) {

				if (facingRightNow) { //determines if player is facing left & flips bullet sprite accordingly
					shotTransform.localScale = new Vector2(-1, -1);
					move.direction = this.transform.right * -1;
//					move.direction = this.transform.right; // towards in 2D space is the right of the sprite
				}
				if (!facingRightNow) {
//					shotTransform.localScale = new Vector2(-1, -1);
//					move.direction = this.transform.right * -1;
					move.direction = this.transform.right;
				}
			}
		}
	}
	
	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}


