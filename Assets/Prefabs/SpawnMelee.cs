using UnityEngine;
using System.Collections;

public class SpawnMelee : MonoBehaviour {

	public GameObject mob1;

	// Use this for initialization
	void Start () {
		StartCoroutine ("SpawnMel");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SpawnMel(){
			for (int i=0; i<10; i++){
				Instantiate (mob1, new Vector3(Random.Range (-1f,1f),.7f,-.3f), Quaternion.identity);
				yield return new WaitForSeconds(Random.Range (5,10));
			}		

	}
}
