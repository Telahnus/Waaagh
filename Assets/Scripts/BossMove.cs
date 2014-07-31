using UnityEngine;
using System.Collections;

public class BossMove : MonoBehaviour {

	public float speed;
	private bool moveRight = true;

	void Update(){
		if (transform.position.x < -4) {moveRight = true;} 
		else if (transform.position.x > 4) { moveRight = false;}

		if (moveRight) {transform.Translate (Vector3.right * Time.deltaTime * speed);}
		else if (!moveRight){transform.Translate(Vector3.left * Time.deltaTime * speed);}
		
		transform.Translate (Vector3.forward * -1 * Time.deltaTime * speed);
	}

}
