// From unity survival shooter tutorial
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {

	public PlayerScript player;
	public static GameControllerScript instance;
	public float restartDelay = 5f;
	private int level = 1;
	public float levelStartDelay = 2f;
	private Text levelText;
	private GameObject levelImage;
	private bool doingSetup;
	public Vector2 noMovement = new Vector2(0f,0f);

	Animator anim;
	float restartTimer;

	void Awake() {
		instance = this;
		// Set up the reference
		InitGame ();
	}

	private void OnLevelWasLoaded(int index){
		level++;
		InitGame();
	}

	void InitGame(){
		player = GameObject.Find("Player").GetComponent<PlayerScript>();
		player.canControl = false;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = "Level " + level;
//		enemies.clear ();
//		boardScript.SetupScene (level);
		Invoke ("HideLevelImage", levelStartDelay);
	}

	private void HideLevelImage() {
		levelImage.SetActive (false);
		GameObject.Find("Player").GetComponent<PlayerScript>().canControl = true;
	}

	void Update() {
		// If player has contacted enemy
		player = GameObject.Find("Player").GetComponent<PlayerScript>();
		if (player.gameOver) {
			// Tell the animator the game is over
			// Don't have animator set up yet
			player.canControl = false;
			GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = noMovement;
			Invoke ("GameOver", levelStartDelay); 
//			// increment a timer to count up to restarting
//			restartTimer += Time.deltaTime;
//
//			// if it reaches the restart delay
//			if (restartTimer >= restartDelay) {
//				// Reload the currently loaded level
//				SceneManager.LoadScene("game");
//			}
		}
	}

	private void GameOver() {
		levelText.text = "Game Over";
		levelImage.SetActive (true);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
