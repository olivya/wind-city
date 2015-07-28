using UnityEngine;
using System.Collections;

public class objectSpawner : MonoBehaviour {
	
	//public float spawnTime = 5f;		// The amount of time between each spawn.
	//public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject targetObject;		// Array of enemy prefabs.
	private GameObject spawned;
	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		//InvokeRepeating("Spawn", spawnDelay, spawnTime);
		Invoke ("Spawn", 0);
	}
	
	void Update (){
		if (GameObject.Find ("player").GetComponent<playerHp>().respawned) {	
			//print ("REPLACE ME");
			Destroy(spawned);
			Invoke ("Spawn", 0);
		}
	}
	
	void Spawn ()
	{
		// Instantiate a random enemy.
		//int enemyIndex = Random.Range(0, enemies.Length);
		spawned = (GameObject) Instantiate(targetObject, transform.position, transform.rotation);

	}
}