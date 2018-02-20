// https://answers.unity.com/questions/607100/how-to-make-an-ai-to-follow-the-player-in-2d-c.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGuardScript : MonoBehaviour {

	private float RotateSpeed = 1.5f;
	private float ChaseSpeed = 4f;
	private float Radius = 2.5f;
	private GameObject target;
	private PlayerScript player;

	private Vector2 _centre;
	private float _angle;

	private void Start()
	{
		target = GameObject.Find("Player"); // The target of the game object
		player = GameObject.Find("Player").GetComponent<PlayerScript>();
		_centre = transform.position;
	}

	private void Update()
	{
		if (player.hasFood) {
			
			transform.position += (target.transform.position-transform.position).normalized * Time.deltaTime * ChaseSpeed;
		} else {
			_angle += RotateSpeed * Time.deltaTime;

			var offset = new Vector2 (Mathf.Sin (_angle), Mathf.Cos (_angle)) * Radius;
			transform.position = _centre + offset;
		}

		if(player.isComplete) {
			transform.position = (target.transform.position-transform.position).normalized;
		}
	}

}
