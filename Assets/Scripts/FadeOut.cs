using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {
	
	float alpha = 1;
	public float fadeSpeed;

	void Start () {
	}

	void Update () {
		alpha -= Time.deltaTime * fadeSpeed;
		renderer.material.color = new Color(255,255,255,alpha);
		if (renderer.material.color.a  <= 0) {
			Destroy (gameObject);		
		}
	}
}
