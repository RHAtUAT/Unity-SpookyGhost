using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

	private GameObject player;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;


	//Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
    //Sets a minimum and maximum distance the camera can follow for
	void Update () {
		float x = Mathf.Clamp (player.transform.position.x, xMin, xMax);
		float y = Mathf.Clamp (player.transform.position.y, yMin, yMax);
		gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);
	}

//
//	public GameObject player;
//	private Vector3 offset;
//
//	void Start()
//	{
//		offset = transform.position - player.transform.position;
//	}
//
//	void LateUpdate()
//	{
//		transform.position = player.transform.position + offset;
//	}
//
}
