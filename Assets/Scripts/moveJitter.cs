using UnityEngine;
using System.Collections;

/* Creates jittery movement where object accelerates and decelerates 
 * seemingly at random. Top speed, bottom speed, and acceleration
 * are randomized given certain ranges. */

public class moveJitter : MonoBehaviour {
	
	public float speed;
	public float topSpeed;
	public float botSpeed;
	public Vector2 accelRange; //works best with values around 0.3f

	private bool moveRight;
	private float currentSpeed;
	private float accel = .3f;
	private float top;
	private float bot;
	private bool accelerate;
	
	void Start () {

		if (transform.position.x < 0) moveRight = true;		
		else moveRight = false;

		if (Random.Range (0,2)==1) {accelerate = true;}
		else {accelerate = false;}
		bot = botSpeed;
		top = topSpeed;
		currentSpeed = Random.Range (botSpeed, topSpeed);

	}

	void Update () {

		if (currentSpeed <= bot) {
			accelerate = true;
			top = Random.Range (speed*.5f , topSpeed);
			accel = Random.Range (accelRange.x, accelRange.y); //randomizes acceleration
		}
		if (currentSpeed >= top) {
			accelerate = false;
			bot = Random.Range (botSpeed , speed*.5f);
			accel = Random.Range (accelRange.x, accelRange.y);
		}
		
		// math lerp accelerates smoothly up and down
		if (accelerate) currentSpeed = Mathf.Lerp (bot, top, Time.time*accel);	
		if (!accelerate) currentSpeed = Mathf.Lerp (top, bot, Time.time*accel);	

		// apply movement
		if (moveRight)transform.Translate(Vector3.right * Time.deltaTime * currentSpeed);
		else transform.Translate(Vector3.left * Time.deltaTime * currentSpeed);
	}
}
