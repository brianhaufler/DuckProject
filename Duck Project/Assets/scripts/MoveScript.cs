// Taken from pixelnext.io 2d unity game tutorial
using UnityEngine;


// Moves the current game object
public class MoveScript : MonoBehaviour {

	// Object speed
	public Vector2 speed = new Vector2(10,10);

	// Moving direction
	public Vector2 direction = new Vector2 (-1, 0);

	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	
	// Update is called once per frame
	void Update () {
		// Movement 
		movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void FixedUpdate() {
		if (rigidbodyComponent == null)
			rigidbodyComponent = GetComponent<Rigidbody2D> ();

		// Apply moveemnt to the rigidbody
		rigidbodyComponent.velocity = movement;
	}


}
