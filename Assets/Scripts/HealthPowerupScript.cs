using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerupScript : MonoBehaviour {

	// Use this for initialization
public int scoreToGive;
	private PlayerHealth playerHealth;
	private AudioSource coinSound;

	// Use this for initialization
	void Start () {
		playerHealth = FindObjectOfType<PlayerHealth>();	
		coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>(); 	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
			if (other.gameObject.name == "Player") {
					playerHealth.setCurrentLives(playerHealth.getCurrentLives() + scoreToGive);
					gameObject.SetActive(false);
					coinSound.Play();
			}
	}
}
