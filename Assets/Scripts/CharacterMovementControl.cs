using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CharacterMovementModel))]
public class CharacterMovementControl : MonoBehaviour
{

    public float jumpHeight = 4;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    public float moveSpeed = 6;
    int jumpCount = 0;
	public float speedMultiplier;
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;


    float gravity;
    float jumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    CharacterMovementModel controller;

    void Start()
    {
        controller = GetComponent<CharacterMovementModel>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
		speedMilestoneCount = speedIncreaseMilestone;
    }

    void Update()
    {
        UpdateMovementParametes();

    }

    private void UpdateMovementParametes()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(1f, Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            velocity.y = jumpVelocity;
            jumpCount++;
        }
        if (controller.collisions.below)
        {
            jumpCount = 0;
        }

		if(controller.transform.position.x > speedMilestoneCount) {

			speedMilestoneCount = speedMilestoneCount + speedIncreaseMilestone;
			moveSpeed = moveSpeed * speedMultiplier;

		} 
        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
