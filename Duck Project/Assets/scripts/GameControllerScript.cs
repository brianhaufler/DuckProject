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

	Animator anim;
	float restartTimer;

	void Awake() {
		instance = this;
		// Set up the reference
		anim = GetComponent<Animator>();
		InitGame ();
	}

	private void OnLevelWasLoaded(int index){
		level++;
		InitGame();
	}

	void InitGame(){
		doingSetup = true;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = "Level " + level;
//		enemies.clear ();
//		boardScript.SetupScene (level);
		Invoke ("HideLevelImage", levelStartDelay);
	}

	private void HideLevelImage() {
		levelImage.SetActive (false);
		doingSetup = false;
	}

	void Update() {
		// If player has contacted enemy
		if (GameObject.Find("Player").GetComponent<PlayerScript>().GameOver) {
			// Tell the animator the game is over
			// Don't have animator set up yet
			anim.SetTrigger("GameOver");
//
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
}
