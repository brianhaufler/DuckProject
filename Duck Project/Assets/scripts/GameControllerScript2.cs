// From unity survival shooter tutorial
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript2 : MonoBehaviour {

	public PlayerScript2 player;
	public CircleGuards2 enemy;
	public static GameControllerScript2 instance;
	public float restartDelay = 5f;
	private int level = 2;
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
		player = GameObject.Find("Player").GetComponent<PlayerScript2>();
		player.canControl = false;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = "Level " + level;
//		enemies.clear ();
//		boardScript.SetupScene (level);
		Invoke("HideLevelImage", levelStartDelay);
	}

	private void HideLevelImage() {
		levelImage.SetActive (false);
		GameObject.Find("Player").GetComponent<PlayerScript2>().canControl = true;
	}

	void Update() {
		// If player has contacted enemy
		player = GameObject.Find("Player").GetComponent<PlayerScript2>();
		if (player.gameOver) {
			// Tell the animator the game is over
			// Don't have animator set up yet
			player.canControl = false;
			GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = noMovement;
			Invoke("GameOver", levelStartDelay); 
//			// increment a timer to count up to restarting
//			restartTimer += Time.deltaTime;
//
//			// if it reaches the restart delay
//			if (restartTimer >= restartDelay) {
//				// Reload the currently loaded level
//				SceneManager.LoadScene("game");
//			}
		} else if(player.isComplete) {
			player.canControl = false;
			GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = noMovement;
			GameObject.Find("Enemy").GetComponent<Rigidbody2D>().velocity = noMovement;
			Invoke("Complete", levelStartDelay);
		}
	}

	private void GameOver() {
		levelText.text = "Game Over";
		levelImage.SetActive(true);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void Complete() {
		levelText.text = "Level Complete!";
		levelImage.SetActive(true);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
