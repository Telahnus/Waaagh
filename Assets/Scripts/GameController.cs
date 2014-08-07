using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	//ATTRIBUTES
	public GameObject mob1;
	public GameObject mob3;
	public GameObject mob2;
	public GameObject boss;
	public Vector3 spawnPosition;
	public float spawnWait;
	public float waveWait;
	public float startWait;
	public GUIText scoreText;
	public GUIText ammoText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText winText;
	private int score;
	public int ammo;
	private bool gameOver;
	private bool win;
	private GameObject target;
	
	void Start () 
	{
		gameOver = false;
		win = false;
		gameOverText.text = "";
		restartText.text = "";
		winText.text = "";
		score = 0;
		UpdateScore ();
		UpdateAmmo ();
		//StartCoroutine ("SpawnWaves");
	}

	void Update (){
		if (score >= 50) Win ();
		if (win || gameOver) {
			StopCoroutine ("SpawnWaves");
			if (Input.GetKeyDown (KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void SpawnBoss(){
		Vector3 spawnLocation = new Vector3 (0,1,20);
		Instantiate (boss, spawnLocation, Quaternion.identity);
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);

		while(true){
			for (int j = 0; j<3; j++){
				for (int i = 0; i<10; i++){

					//Randomize which mob to spawn
					//GameObject target = new GameObject();
					int mobType = Random.Range (1,4);
					if (mobType == 1){target = mob1;}
					else if (mobType == 2) {target = mob2;}
					else if (mobType == 3) {target = mob3;}

					Instantiate (target, new Vector3(0,-10,0), Quaternion.identity);
					yield return new WaitForSeconds (spawnWait-.1f*i);
				}
				yield return new WaitForSeconds (waveWait);
			}
			yield return new WaitForSeconds (3);
			SpawnBoss ();
			yield break;
		}
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		restartText.text = "Press 'R' for Restart";
	}
	
	public void Win ()
	{
		winText.text = "You won!";
		win = true;
		restartText.text = "Press 'R' for Restart";
	}

	//GUI ELEMENTS

	public void AddScore (int newScoreValue){
		score += newScoreValue;
		UpdateScore ();}
	void UpdateScore(){scoreText.text = "Score: " + score;}
	public void AddAmmo (int newAmmoValue){
		ammo += newAmmoValue;
		UpdateAmmo ();}
	public void ReloadAmmo (int newAmmoValue){
		ammo = newAmmoValue;
		UpdateAmmo ();}
	void UpdateAmmo(){ammoText.text = "Ammo: " + ammo;}
	public int GetAmmo(){return ammo;}
	
}
