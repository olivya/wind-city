using UnityEngine;
using System.Collections;

public class checkPoint : MonoBehaviour {

	public Transform spawnPoint;

	//public bool reachedFirstCheckPoint = false;
	
	void OnTriggerEnter2D(Collider2D collider) {
		//reachedFirstCheckPoint = true;
		pointReached saved = collider.gameObject.GetComponent<pointReached> ();


		//print ("reached first one");
		
		if (saved) {
			spawnPoint.position = new Vector2(transform.position.x, transform.position.y);
			//print(transform.position.x + " , " + transform.position.y);
			//spawnPoint.position = transform.position;
			//Destroy(saved.gameObject); // Remember to always target the game object, otherwise you will just remove the script
		}
	}
}