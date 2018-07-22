using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour {

	public string mainMenuLevel;

	public void RestartGame() {
		FindObjectOfType<GameManager>().Reset(true);
	}

	public void QuitToMain() {
		SceneManager.LoadScene(mainMenuLevel);
	}
}
