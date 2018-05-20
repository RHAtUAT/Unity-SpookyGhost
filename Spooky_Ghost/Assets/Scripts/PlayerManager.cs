using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	public int playerSpeed = 10;
	public float playerJumpPower = 1250;
    public float playerDownPower = 750;
	private float X;
	private float Y;
	public bool isGrounded;
	public GameObject playerScoreUI;

	// Update is called once per frame
	void Update () { 
		playerScoreUI.gameObject.GetComponent<Text> ().text = (ScoreSystem.playerScore.ToString());
		PlayerMovement ();
		//anim = GetComponent<Animator> (); could do this to make it simpler on myself, but eh
	}

	void PlayerMovement() {

		//PLayer Controls
		X = Input.GetAxis("Horizontal");
		Jump ();

        //Triggers the Player Animations when the circumstances are met
        if (X != 0)
		{
            GetComponent<Animator>().SetBool("isMoving", true);
        }
        else 
		{
            GetComponent<Animator> ().SetBool("isMoving", false);
        }

		if(Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Animator>().SetTrigger("Scare");
			ScareNearHuman ();
		}

        //Player Direction. Flips the Player sprite picture
        if (X < 0.0f) 
		{ 
			GetComponent<SpriteRenderer> ().flipX = false;
		} 
		else if (X > 0.0f) 
		{
			GetComponent<SpriteRenderer> ().flipX = true;
		}
		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(X * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}


	//Allows player to jump
	void Jump() {
		
		if (Input.GetKeyDown(KeyCode.W) && gameObject.transform.position.y < -1.2f) { 
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
		}
		else if(Input.GetKeyDown(KeyCode.S)){
			GetComponent<Rigidbody2D>().AddForce(Vector2.down * playerDownPower);
		}
			
	}

    //Detects the nearest Human and if they're within scaring distance. If so and player scares them, trigger Human RunAway animation then add 100 score
	void ScareNearHuman()
	{
		Human[] allHumans = GameObject.FindObjectsOfType<Human> ();

		foreach (Human currentHuman in allHumans) 
		{
			if (this.transform.position.x - currentHuman.transform.position.x <= 5 && this.transform.position.x - currentHuman.transform.position.x >= -5) {
				currentHuman.GetComponent<Animator> ().SetTrigger ("RunAway");
				ScoreSystem.playerScore += 100;
				   
			}

		}
	}
}