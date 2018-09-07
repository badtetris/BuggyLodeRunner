using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator _anim;
	private SpriteRenderer _spriteRenderer;

	private PlayerMovement _movement;

	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_movement = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

		// To ensure we don't do anything when the game is paused.
		if (Time.timeScale == 0) {
			_anim.enabled = false;
			return;
		}
		else {
			_anim.enabled = true;
		}

		_anim.SetBool("Walking", _movement.horizontalVelocity == 0 && (_movement.onGround || _movement.onRope));
		_anim.SetBool("OnRope", _movement.onRope && !_movement.droppingFromRope);
		_anim.SetBool("Climbing", _movement.climbing);
		_anim.SetBool("OnLadder", _movement.onLadder);
		_anim.SetBool("OnGround", _movement.onGround);
		if (_movement.horizontalVelocity < 0) {
			_spriteRenderer.flipX = true;
		}
		else if (_movement.horizontalVelocity > 0) {
			_spriteRenderer.flipX = false;
		}
	}
}
