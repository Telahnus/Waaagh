using UnityEngine;
using System.Collections;

public class MeleeControls : MonoBehaviour {

	//float xPos = Screen.width/10;
	//float yPos = Screen.height-50;
	//public GameObject mob1;

	public GameObject mmA;
	public GameObject mmS;
	public GameObject mmD;
	public GameObject mmF;

	public GameObject shoot;
	public GameObject smash;
	public GameObject stomp;
	public GameObject chop;
	Vector3 loc = new Vector3 (0,1.5f,-.5f);

	void Start(){
		StartCoroutine ("SpawnMelee");
	}

	void Update(){

		if(Input.GetKeyDown (KeyCode.A)) {
			Destroy (GameObject.FindGameObjectWithTag("A"));
			powMark ();
		}
		if(Input.GetKeyDown (KeyCode.S)) {
			Destroy (GameObject.FindGameObjectWithTag("S"));
			powMark ();
		}
		if(Input.GetKeyDown (KeyCode.D)) {
			Destroy (GameObject.FindGameObjectWithTag("D"));
			powMark ();
		}
		if(Input.GetKeyDown (KeyCode.F)) {
			Destroy (GameObject.FindGameObjectWithTag("F"));
			powMark ();
		}

	}

	void targeting(){
		Vector3 tPos = new Vector3 (0,0,-.3f);
		tPos.y = Random.Range (0.8f, 1.9f);
		tPos.x = Random.Range (-.8f, .8f);
		int letter = Random.Range (1, 5);
		if (letter==1)Instantiate (mmA,tPos,Quaternion.identity);
		if (letter==2)Instantiate (mmS,tPos,Quaternion.identity);
		if (letter==3)Instantiate (mmD,tPos,Quaternion.identity);
		if (letter==4)Instantiate (mmF,tPos,Quaternion.identity);
		
	}

	void powMark (){
		int rand = Random.Range (1,5);
		if (rand==1)Instantiate (shoot,loc,Quaternion.identity);
		if (rand==2)Instantiate (smash,loc,Quaternion.identity);
		if (rand==3)Instantiate (stomp,loc,Quaternion.identity);
		if (rand==4)Instantiate (chop,loc,Quaternion.identity);
	}

	IEnumerator SpawnMelee(){
		for (int i=0; i<10; i++){
			targeting();	
			yield return new WaitForSeconds(Random.Range (5,10));
		}		
		
	}
	
}
