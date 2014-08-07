using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	private float nextFire;
	public float fireRate;
	public float reloadRate;
	public AudioClip shot;
	public AudioClip empty;
	public AudioClip reload;
	private GameController gameController;
	private BossController bossController;
	public GameObject hole;
	private bool burst = false;
	private float bonusTime;
	private float fireTemp;

	void Start (){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		} else if (gameController == null){
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void Update () {

		Ray rayTest = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitTest;
		if (Physics.Raycast (rayTest, out hitTest, Mathf.Infinity)) {
			Debug.DrawLine (rayTest.origin, hitTest.point);
		}

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			if (gameController.GetAmmo()>0){

				nextFire = Time.time + fireRate;
				audio.PlayOneShot(shot);
				gameController.AddAmmo(-1);

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {

					//BULLET MARKS

					/*need to fix this!! not sure how to rotate quad, then face
					 * works for fences, but not walls/floor
					var hitRotation = Quaternion.Euler(0,0,Random.Range (0f,360f));
					hitRotation *= Quaternion.FromToRotation(Vector3.back, hit.normal);*/

					var hitRotation = Quaternion.FromToRotation(Vector3.back, hit.normal);
					Vector3 point = hit.point + .1f*hit.normal;
					GameObject clone = Instantiate (hole, point, hitRotation) as GameObject;
					clone.transform.parent = hit.transform;

					//use parent transform, which has no scale, so no skew
					//clone.transform.parent = hit.transform.parent;

					if (hit.collider.tag == "target"){
						gameController.AddScore(1);
						if (hit.transform.childCount>=3){
							gameController.AddScore (3);
							Destroy(hit.transform.gameObject);
						}
					}

					if (hit.collider.tag == "bonus"){
						burst = true;
						bonusTime = Time.time + 5;
						fireTemp = fireRate;
						fireRate = 0.5f;
						Destroy(hit.transform.gameObject);
					}

					if (hit.collider.tag == "boss"){
						GameObject bossControllerObject = GameObject.FindWithTag ("boss");
						if (bossControllerObject != null){
							bossController = bossControllerObject.GetComponent <BossController>();
						} else if (bossController == null){
							Debug.Log ("Cannot find 'BossController' script");
						}
						bossController.hit();
					}

				}
			} else {
				audio.PlayOneShot (empty);
				nextFire = Time.time + .2f;
			}

		}

		if (burst && Time.time > bonusTime) {
			fireRate = fireTemp;
			burst = false;
		}

		if (Input.GetButton ("Fire2") && Time.time > nextFire) {
			gameController.ReloadAmmo (8);	
			nextFire = Time.time + reloadRate;
			audio.PlayOneShot (reload);
		}

	}
}
