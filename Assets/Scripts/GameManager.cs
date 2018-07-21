using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private ScoreManager theScoreManager;
	public Transform platformGenerator;
	private Vector3 platformStartPoint;
	public CharacterMovementModel player;
	private Vector3 playerStartpoint;

	private PlatformDestroyer[] platformList;

	// Use this for initialization
	void Awake () {
		//theScoreManager = FindObjectOfType<ScoreManager>();
	}

	private void Start() {
		platformStartPoint = platformGenerator.position;
		playerStartpoint = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame() {
		Debug.Log("penis");
		StartCoroutine ("RestartGameCo");
	}

	 public IEnumerator RestartGameCo() {
	 	//theScoreManager.scoreIncreasing = false;
		
		player.gameObject.SetActive(false);
		yield return new WaitForSeconds(0.5f);
		platformList = FindObjectsOfType<PlatformDestroyer>();

		for (int i = 0; i < platformList.Length; i++)
		{
			platformList[i].gameObject.SetActive(false);
		}

		player.transform.position = playerStartpoint;
		platformGenerator.position = platformStartPoint;
		player.gameObject.SetActive(true);
	 	//theScoreManager.scoreCount = 0;
	 	//theScoreManager.scoreIncreasing = true;
		
	 }
}
