using UnityEngine;
using System.Collections;

public class Guard7 : MonoBehaviour {
	
	private bool placed;
	private float rX;
	private float rY;
	private float rZ;
	
	void Start(){

		// apply proper scale
		// !! will depend on original textures scale
		Vector3 scale = new Vector3(); // requires creating temporary vector3 scale
		scale.y = 1.5f; // proper height
		scale.z = 1f; 
		placed = false; //boolean to track if it has been properly placed
		
		// determine track, gguard7 l: 20,06,13 r: 12,02,18
		while (!placed) {
			rZ = Random.Range (1, 21); // randomize depth
			if (rZ == 5 || rZ == 15) rZ++;
			
			//depth determines direction of movement
			if (rZ == 20 || rZ == 06 || rZ == 13) {
				rX = -7;
				scale.x = -1.47f; //flip texture depending on direction
				placed = true;
			} else if (rZ == 12 || rZ == 02 || rZ == 18) {
				rX = 7;
				scale.x = 1.47f;
				placed = true;
			}
		}
		
		rY = transform.localScale.y / 2; //bump transform up by half height to keep level with floor
		
		Vector3 spawnLocation = new Vector3 (rX,rY,rZ);
		
		transform.position = spawnLocation;
		transform.localScale = scale;

	}
	
	void Update(){
		
		if (Mathf.Abs (transform.position.x) > 10) Destroy(gameObject);
		
	}
	
}
