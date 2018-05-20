using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour {

	public float timePlayed = 0;
	public int playerScore = 0;
	// Use this for initialization
	
    //Work In Progress
	// Update is called once per frame
	void Update () {
		timePlayed += Time.deltaTime;
	}
}
