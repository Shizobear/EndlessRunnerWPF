using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float moveSpeed;
	public float jumpForce;
	public bool grounded;
	public LayerMask whatIsObsticle;

	private Rigidbody2D playerRigidbody;
	private Collider2D playerCollider;
	private Animator playerAnimator;
	

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D>();
		playerCollider = GetComponent<Collider2D>();
		playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.IsTouchingLayers(playerCollider, whatIsObsticle);

		playerRigidbody.velocity = new Vector2(moveSpeed, playerRigidbody.velocity.y);

		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && grounded) {
				playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
		}

		playerAnimator.SetFloat("Speed", playerRigidbody.velocity.x);
		playerAnimator.SetBool("Grounded", grounded);
	}
}
