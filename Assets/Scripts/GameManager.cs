using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// public IEnumerator RestartGameCo() {
	// 	theScoreManager.scoreIncreasing = false;


	// 	theScoreManager.scoreCount = 0;
	// 	theScoreManager.scoreIncreasing = true;
	// 	return ;
	// }
}
