using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int currentLives;
	public Text livesUI;

	void Start() {
		livesUI.text = "Lives: " + currentLives.ToString();
	}

	void Update() {
		livesUI.text = "Lives: " + currentLives.ToString();
	}

}
