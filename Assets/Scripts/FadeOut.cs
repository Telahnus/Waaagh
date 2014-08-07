using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	
	float alpha = 1;
	public float fadeSpeed;

	void Start () {
	}

	void Update () {
		alpha -= Time.deltaTime * fadeSpeed;
		renderer.material.color = new Color(1,1,1,alpha);
		if (renderer.material.color.a  <= 0) {
			Destroy (gameObject);		
		}
	}
}
