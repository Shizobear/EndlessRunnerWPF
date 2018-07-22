using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private int currentLives;
	public int lives;
	public Text livesUI;

	void Start() {
		currentLives = lives;
		livesUI.text = "Lives: " + currentLives.ToString();
	}

	void Update() {
		livesUI.text = "Lives: " + currentLives.ToString();
	}

	public void setCurrentLives(int currentLiv) {
		currentLives = currentLiv;
	}

	public int getCurrentLives() {
		return currentLives;
	}

	public void gameRestart() {
		currentLives = lives;
	}

}
