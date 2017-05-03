using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour {

	public GameObject gameOverUI;
	public GameObject gameWinUI;
	public GameObject player;
	public Text ammoText;
	bool gameIsDone;
	// Use this for initialization
	void Start () {
		EnemyScript.OnPlayerSpotted += ShowGameOverUI;
		FindObjectOfType<PlayerScript>().OnExitReached += ShowGameWinUI;
	}
	
	// Update is called once per frame
	void Update () {
		ammoText.text = player.GetComponent<GunControllerScript>().currentGun.ammoCount.ToString();
		if(gameIsDone){
			if (Input.GetKeyDown(KeyCode.Space)){
				SceneManager.LoadScene (0);
			}
		}
	}

	void ShowGameOverUI(){
		OnGameDone(gameOverUI);
	}

	void ShowGameWinUI(){
		OnGameDone(gameWinUI);
	}

	void OnGameDone (GameObject gameDoneUI){
		gameDoneUI.SetActive(true);
		gameIsDone = true;
		EnemyScript.OnPlayerSpotted -= ShowGameOverUI;
		FindObjectOfType<PlayerScript>().OnExitReached -= ShowGameWinUI;
	}
}
