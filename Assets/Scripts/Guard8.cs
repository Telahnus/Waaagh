using UnityEngine;
using System.Collections;

public class Guard8 : MonoBehaviour {

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
		
		// determine track, guard8 l: 03,17,10 r: 09,16,07
		while (!placed) {
			rZ = Random.Range (1, 21); // randomize depth
			if (rZ == 5 || rZ == 15) rZ++;

			// depth determines direction of movement
			if (rZ == 03 || rZ == 17 || rZ == 10) {
				rX = -7;
				scale.x = 1.36f; // flip texture depending on direction
				placed = true;
			} else if (rZ == 09 || rZ == 16 || rZ == 07) {
				rX = 7;
				scale.x = -1.36f;
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
