using UnityEngine;
using System.Collections;

public class OutOfBounds : MonoBehaviour {

	public float xBound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (transform.position.x) > xBound) {
			Destroy(gameObject);
		}
	}
}
