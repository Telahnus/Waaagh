using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	public float wounds;
	private float max;
	public float speed;
	private bool moveRight = true;
	private GameController gameController;
	private int leftBound = -4;
	private int rightBound = 4;

	void Start() {
		max = wounds;
		renderer.material.color = new Color(0, wounds/max, 0);

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		}if (gameController == null){
			Debug.Log ("Cannot find 'GameController' script");
		}

	}

	void Update(){

		//keeps movement within bounds
		//recalculates bounds each time it hits the edge to create randomized zigzag
		if (transform.position.x < leftBound) {
			moveRight = true;
			rightBound = Random.Range (-3,4);
			Debug.Log ("left:"+ leftBound+" right: "+ rightBound);
		} 
		else if (transform.position.x > rightBound) {
			moveRight = false;
			leftBound = Random.Range (-4,3);
			Debug.Log ("left:"+ leftBound+" right: "+ rightBound);
		}
		
		if (moveRight) {transform.Translate (Vector3.right * Time.deltaTime * speed);}
		else if (!moveRight){transform.Translate(Vector3.left * Time.deltaTime * speed);}
		
		transform.Translate (Vector3.forward * -1 * Time.deltaTime * speed);

		if (transform.position.z < -10) {
			Destroy (gameObject);
			gameController.GameOver ();
		}
	}

	public void hit(){
		wounds--;
		renderer.material.color = new Color(0, wounds/max, 0);
		if (wounds == 0) {
			Destroy (gameObject);
			gameController.Win ();
		}
	}
}
