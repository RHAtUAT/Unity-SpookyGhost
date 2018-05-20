using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool isPaused = false;
	public GameObject pauseMenuUI;


	public float playTime;
	public int playerScore;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {

			if (isPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

    //Resume the game
	public void Resume()
	{
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		isPaused = false;
	}

    //Pause the game
	 void Pause()
	{
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		isPaused = true;
	}

    //Summons the save game method in the ScoreSystem class
	public void SaveGame(){
	
		ScoreSystem.datamanagement.SaveData ();
	}


    //Quit the game
	public void QuitGame()
	{
        Application.Quit();
	}

}
