using UnityEngine;
using System.Collections;

public class moveSmooth : MonoBehaviour {

	private bool moveRight;
	public float speed;
	
	void Start () {
		if (transform.position.x < 0) moveRight = true;		
		else moveRight = false;
	}

	void Update () {
		if (moveRight)transform.Translate(Vector3.right * Time.deltaTime * speed);
		else transform.Translate(Vector3.left * Time.deltaTime * speed);
	}
}
