using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private ScoreManager theScoreManager;
	public Transform platformGenerator;
	private Vector3 platformStartPoint;
	public CharacterMovementModel player;
	private Vector3 playerStartpoint;
	private PlayerHealth thePlayerHealth;

	private PlatformDestroyer[] platformList;

	public GameOverMenu theGameOverMenu;

	// Use this for initialization
	void Awake () {
		theScoreManager = FindObjectOfType<ScoreManager>();
		thePlayerHealth = FindObjectOfType<PlayerHealth>();
	}

	private void Start() {
		platformStartPoint = platformGenerator.position;
		playerStartpoint = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame() {
		theScoreManager.scoreIncreasing = false;
		player.gameObject.SetActive(false);
		thePlayerHealth.setCurrentLives(thePlayerHealth.getCurrentLives() - 1);

		if (thePlayerHealth.getCurrentLives() == 0) {
			theGameOverMenu.gameObject.SetActive(true);
		} else {
			Reset(false);
		}
		
		// StartCoroutine ("RestartGameCo");
	}

	public void Reset(bool restart) {
		if (restart) {
			theGameOverMenu.gameObject.SetActive(false);
		}

		platformList = FindObjectsOfType<PlatformDestroyer>();

		for (int i = 0; i < platformList.Length; i++) {
			platformList[i].gameObject.SetActive(false);
		}

		player.transform.position = playerStartpoint;
		platformGenerator.position = platformStartPoint;
		player.gameObject.SetActive(true);

		if (restart) {
			theScoreManager.scoreCount = 0;
			thePlayerHealth.gameRestart();
		}

	 	theScoreManager.scoreIncreasing = true;
	}

	//  public IEnumerator RestartGameCo() {
	// 	int currentLives = thePlayerHealth.getCurrentLives();
	// 	thePlayerHealth.setCurrentLives(currentLives - 1);
	//  	theScoreManager.scoreIncreasing = false;
	// 	player.gameObject.SetActive(false);

	// 	yield return new WaitForSeconds(0.5f);
	// 	platformList = FindObjectsOfType<PlatformDestroyer>();

	// 	for (int i = 0; i < platformList.Length; i++) {
	// 		platformList[i].gameObject.SetActive(false);
	// 	}

	// 	player.transform.position = playerStartpoint;
	// 	platformGenerator.position = platformStartPoint;
	// 	player.gameObject.SetActive(true);

	// 	if (thePlayerHealth.getCurrentLives() == 0) {
	// 		theScoreManager.scoreCount = 0;
	// 		thePlayerHealth.gameRestart();
	// 	}

	//  	theScoreManager.scoreIncreasing = true;
	//  }
}
