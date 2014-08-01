using UnityEngine;
using System.Collections;

public class Guard7 : MonoBehaviour {
	
	public float baseSpeed;
	private float speed;
	private bool moveRight;
	private bool placed;
	private float rX;
	private float rY;
	private float rZ;
	
	void Start(){
		
		//applying proper scale
		Vector3 scale = new Vector3(); //creating temporary vector3 scale
		scale.y = 1.5f; //proper height
		scale.z = 1f; 
		placed = false;
		
		// determine track
		while (!placed) {
			rZ = Random.Range (1, 21); // randomize depth
			if (rZ == 5 || rZ == 15) {
				rZ++;
			}
			
			//guard7 l: 20,06,13 r: 12,02,18
			
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
		
		rY = transform.localScale.y/ 2; //bump transform up by half height to keep level with floor
		
		Vector3 spawnLocation = new Vector3 (rX,rY,rZ);
		
		transform.position = spawnLocation;
		transform.localScale = scale;
		
		//Set direction
		if (transform.position.x < 0) {
			moveRight = true;		
		} else {moveRight = false;}
		
		//speed = speed*Random.Range(.7f,1.1f);
	}
	
	void Update(){
		speed = baseSpeed + Random.Range(-2f,0.5f); //rickety movement
		if (moveRight){
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		} else {
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		
		if (Mathf.Abs (transform.position.x) > 10) {
			Destroy(gameObject);
		}
		
	}
	
}
