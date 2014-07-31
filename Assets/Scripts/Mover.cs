using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	
	public float speed;
	private bool moveRight;

	void Start(){
		if (transform.position.x < 0) {
			moveRight = true;		
		} else {moveRight = false;}
		speed = speed + (Random.Range (-10, 11) / 5);
	}
	
	void Update(){
		if (moveRight){
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		} else {
			transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
	}
	
}
