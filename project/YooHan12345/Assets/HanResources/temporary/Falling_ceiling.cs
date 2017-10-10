using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_ceiling : MonoBehaviour {

	HeartManager HeartManager;

	float movePower = 1.5f;
	Vector3 moveVelocity = new Vector3(0, -1, 0);
	bool isFalling = true;

	// Use this for initialization
	void Start () {
		HeartManager = FindObjectOfType<HeartManager>();
	
		StartCoroutine ("_fall");
	}

	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		move ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			HeartManager.SendMessage ("DecHeart", null);
			Destroy (gameObject, 0);
		}
	}

	void move () {
		if (isFalling == true) {
			transform.position += moveVelocity * movePower * Time.deltaTime;
		}
	}
		
	IEnumerator _fall () {
		Debug.Log (gameObject.transform.position.y);

		yield return new WaitForSeconds(0.7f);
		isFalling = false;
		Destroy (gameObject, 9);

		Debug.Log (gameObject.transform.position.y);
	}

}
