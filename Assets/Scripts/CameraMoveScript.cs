using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour {

	
	// Use this for initialization
	public GameObject thePlayer;
	public CharacterMovementModel cMovement;
	private Vector3 lastPlayerPosition;
	private float distanceToMove;
	void Awake () {
		thePlayer = GameObject.Find("Player");
		cMovement = thePlayer.GetComponent<CharacterMovementModel>();
	}

	void Start() {
		lastPlayerPosition = thePlayer.transform.position;	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateCameraPosition();
	}

    private void UpdateCameraPosition()
    {
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		lastPlayerPosition = thePlayer.transform.position;
    }
}
