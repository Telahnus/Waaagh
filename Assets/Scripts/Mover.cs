using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	//Rename Guard3

	public float speed;
	private bool moveRight;

	void Start(){

		float rZ = Random.Range (1,21);
		if (rZ==5||rZ==15){rZ++;}

		float rX = Random.Range (0,2);
		if (rX == 0){rX = -7;
		}else if (rX == 1){rX = 7;
		}

		float rY = transform.localScale.y/ 2;

		Vector3 spawnLocation = new Vector3 (rX,rY,rZ);

		transform.position = spawnLocation;

		//Set direction
		if (transform.position.x < 0) {
			moveRight = true;		
		} else {moveRight = false;}

		//speed = speed*Random.Range(.7f,1.1f);
	}
	
	void Update(){
		speed = 2+Random.Range(-1.5f,0.5f); //it does make the jostle about like rickety
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
