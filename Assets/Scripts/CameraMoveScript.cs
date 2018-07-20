using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public Transform cameraTransform;
	void Awake () {
		cameraTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
