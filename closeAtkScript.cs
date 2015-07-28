//this script controls cool down on the shooting and instantiates prefab

using UnityEngine;

public class closeAtkScript : MonoBehaviour {
	
	public Transform shotPrefab;
	public float shootingRate = 0.5f;
	
	private float shootCooldown;
	public bool facingRight;
	
	void Start() {
		shootCooldown = 0f;
	}
	
	void Update() {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}

	public void Attack (bool isEnemy)
	{
		doAttack(isEnemy);
	}
	
	public void doAttack(bool isEnemy)
	{
//		playerMP pmp = gameObject.GetComponent<playerMP> ();
		
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			facingRight = gameObject.GetComponent<playerController>().facingRight;
			
			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			//pmp.AdjustCurMagic (-1); //only decrease if shot is actually instantiated
			
			// Assign position (adjusts position x so it instantiates in front of the player)
			if (facingRight) shotTransform.position = new Vector2(transform.position.x - 2, transform.position.y);
			if (!facingRight) shotTransform.position = new Vector2(transform.position.x + 2, transform.position.y);
			
			// The is enemy property
			shotScript shot = shotTransform.gameObject.GetComponent<shotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
				
				if (facingRight) { //determines if player is facing left & flips bullet sprite accordingly
					//shotTransform.localScale = new Vector2(3, 3);
					//move.direction = this.transform.right * -1;
					//move.direction = this.transform.right; // towards in 2D space is the right of the sprite
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


