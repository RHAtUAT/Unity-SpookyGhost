using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int walkSpeed;
    public bool isWalking;
    public float walkTime;
    public float walkCounter;
    public float waitTime;
    public float waitCounter;
    public int walkDirection;
    public int X;
    private Rigidbody2D myRigidbody;
    public GameObject Col1;

    //Use this for initialization
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

    }

    //Create a timer to make the enemy wait before moving, create a timer to set how long the enemy moves for
    // Update is called once per frame
    void Update () {
        Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), Col1.GetComponent<Collider2D>(), true);

		if (isWalking) {
            walkCounter -= Time.deltaTime;

            if (walkCounter < 0){
                isWalking = false;
				GetComponent<Animator> ().SetBool("isWalking", false);
                waitCounter = waitTime;
               
            }
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(X, 0) * walkSpeed;

        }
        else {
            waitCounter -= Time.deltaTime;

            if(waitCounter < 0)
            {
                Flip();
            }
        }
	}

    //Flips the enemy sprite so it faces the direction its walking
	void Flip() {
		
		if(X > 0){
			X = -1;
            GetComponent<SpriteRenderer>().flipX = false;
            isWalking = true;
			GetComponent<Animator> ().SetBool("isWalking", true);
            walkCounter = walkTime;
        }
        else {
			X = 1;
            GetComponent<SpriteRenderer>().flipX = true;
			GetComponent<Animator> ().SetBool("isWalking", true);
            isWalking = true;
            walkCounter = walkTime;
        }
    }
}
