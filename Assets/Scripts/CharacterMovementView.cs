using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementView : MonoBehaviour
{

    private CharacterMovementModel moveModel;
    private Vector3 lastPosition = new Vector3();
    private Animator playerAnimator;
    // Use this for initialization
    void Awake() {
        moveModel = GetComponent<CharacterMovementModel>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Start() {
        

    }

    // Update is called once per frame
    void Update() {
		playerAnimator.SetBool("Grounded", moveModel.IsGrounded());
		playerAnimator.SetBool("isMoving", true);
    }
}
