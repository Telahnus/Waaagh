using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	
	public float baseSpeed;
	private float speed;
	private float top;
	private float bot;
	
	private bool accelerate;
	private float accel = 1f;
	private bool moveRight;
	
	private bool placed;
	private float rX;
	private float rY;
	private float rZ;
	
	void Start(){
		
		// apply proper scale
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
		
		// set direction
		if (transform.position.x < 0) moveRight = true;		
		else moveRight = false;
		
		// randomize and set speed params
		if (Random.Range (0,2)==1) {accelerate = true;}
		else {accelerate = false;}
		//bot = baseSpeed * .2f;
		//top = baseSpeed * 1f;
		speed = Random.Range (bot, top);
	}
	
	void Update(){
		
		/* the jerky randomized movement is better for "real" people
		 * rather than targets moving along track
		 * use following code for later levels
		 * but keep smooth movement for now on level 1
		 */
		
		// set top and bottom speed within random range
		// set new accel speed
		if (speed <= bot) {
			accelerate = true;
			top = Random.Range (baseSpeed*.5f,baseSpeed*1f);
			accel = Random.Range (.2f,.7f);
		}
		if (speed >= top) {
			accelerate = false;
			bot = Random.Range (baseSpeed*0f,baseSpeed*.5f);
			accel = Random.Range (.2f,.7f);
		}
		
		// math lerp accelerates smoothly up and down
		// modifying by .3 seems to be good
		if (accelerate) speed = Mathf.Lerp (bot, top, Time.time*accel);	
		if (!accelerate) speed = Mathf.Lerp (top, bot, Time.time*accel);	
		
		
		// apply movement
		if (moveRight)transform.Translate(Vector3.right * Time.deltaTime * speed);
		else transform.Translate(Vector3.left * Time.deltaTime * speed);
		
		if (Mathf.Abs (transform.position.x) > 10) Destroy(gameObject);
		
	}
	
}
