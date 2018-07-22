using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	private bool paused = false;
	public GameObject pauseMenu;

	public void PauseGame() {
		paused = true;
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);
	}

	public void ResumeGame() {
		paused = false;
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}

	public void RestartGame() {
		paused = false;
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		FindObjectOfType<GameManager>().Reset(true);
	}

	public void QuitToMain() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(mainMenuLevel);
	}

	public bool isPaused() {
		return paused;
	}
}
