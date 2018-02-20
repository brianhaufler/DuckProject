// Taken from pixelnext.io 2d unity game tutorial

using UnityEngine;

// Script controls players movement and behavior
public class PlayerScript : MonoBehaviour {

	public GameControllerScript gameController; // Reference to game Controller
	private CircleGuardScript guard;

	// Speed of the player
	public Vector2 speed = new Vector2(15, 15);

	// Movement and the component
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	// Set up booleans for food/enemy contacts
	public bool gameOver = false;
	public bool hasFood = false;
	public bool canControl = true;
	public bool isComplete = false;



	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		// Movement per direction
		movement = new Vector2 (
			speed.x * inputX,
			speed.y * inputY);
	}

	void FixedUpdate() {
		if (canControl) {
			// 5 - Get the component and store the reference
			if (rigidbodyComponent == null) {
				rigidbodyComponent = GetComponent<Rigidbody2D> ();
			}
			// 6 - Move the game object
			rigidbodyComponent.velocity = movement;
		}
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive(false);
			hasFood = true;
		}
		else if (other.gameObject.CompareTag("Enemy")) {
			gameOver = true;
		}
		else if (other.gameObject.CompareTag("Pond") && hasFood) {
		 	isComplete = true;
		}
	}

}
