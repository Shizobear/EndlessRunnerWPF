using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	// Use this for initialization
	public GameObject destructionPoint;

	private void Awake() {
		destructionPoint = GameObject.Find("PlatformDestructionPoint");
	}	
	// Update is called once per frame
	void Update () {
		
		if(transform.position.x < destructionPoint.transform.position.x) {
			
			gameObject.SetActive(false);

		}

	}
}
