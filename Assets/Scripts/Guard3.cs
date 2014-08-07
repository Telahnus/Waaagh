using UnityEngine;
using System.Collections;

public class Guard3 : MonoBehaviour {
	
	private bool placed;
	private float rX;
	private float rY;
	private float rZ;
	
	void Start(){
		
		// apply proper scale
		// !! will depend on original textures scale
		Vector3 scale = new Vector3(); // requires creating temporary vector3 scale
		scale.y = 1.32f; // proper height
		scale.z = 1f; 
		placed = false; //boolean to track if it has been properly placed
		
		// determine track, guard3 l: 01,19,08 r: 11,14,04
		while (!placed) {
			rZ = Random.Range (1, 21); // randomize depth
			if (rZ == 5 || rZ == 15) rZ++;
			
			//depth determines direction of movement
			if (rZ == 1 || rZ == 19 || rZ == 08) {
				rX = -7;
				scale.x = -1.3f; //flip texture depending on direction
				placed = true;
			} else if (rZ == 11 || rZ == 14 || rZ == 04) {
				rX = 7;
				scale.x = 1.3f;
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
