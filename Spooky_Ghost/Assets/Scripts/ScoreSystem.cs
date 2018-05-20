using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


//###########################
//Still working on this
//###########################
//Currently its broken

public class ScoreSystem : MonoBehaviour {

	public static ScoreSystem datamanagement;
	public int highScore;

	public float playTime;
	public static int playerScore;

    //if no game data exists this creates it
	void Awake(){
		if (datamanagement == null) {
			DontDestroyOnLoad (gameObject);
			datamanagement = this;
		} 
		else if(datamanagement != this){
			Destroy (gameObject);
		}
	}

	//Data is Saved
	public void SaveData(){
		BinaryFormatter BinForm = new BinaryFormatter ();  //Creates bin formatter
		FileStream file = File.Create (Application.persistentDataPath + "/gameInfo.dat"); //Creates File
		gameData data = new gameData(); //Creates container for data
		data.highscore = highScore;
		BinForm.Serialize (file, data); //serializes
		file.Close();
 	}

	//Data is Loaded
	public void LoadData(){
		if (File.Exists (Application.persistentDataPath + "/gameInfo.dat")) {
			BinaryFormatter BinForm = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
			gameData data = (gameData)BinForm.Deserialize (file);
			file.Close();
			highScore = data.highscore;
		}
	}

	// Update is called once per frame
//	void Update () {
//		playTime += Time.deltaTime;
//		if(playTime)
//	}
}

[Serializable]
class gameData{
	public int highscore;

}
