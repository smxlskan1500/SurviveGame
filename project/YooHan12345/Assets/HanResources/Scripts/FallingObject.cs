using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingObject : MonoBehaviour {


	GameObject player;

	HeartManager HeartManager;
	CircleCollider2D circol; //접근감지
	CapsuleCollider2D capcol; //충돌감지


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		HeartManager = FindObjectOfType<HeartManager>();

		circol = gameObject.GetComponent<CircleCollider2D> ();
		capcol = gameObject.GetComponent<CapsuleCollider2D> ();
		circol.enabled = true;
		capcol.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Player") {

			if (capcol.enabled == false) { //캐릭터가 범위에 들어왔을때
				capcol.enabled = true;
				circol.enabled = false;
				fall ();
			} else { //캐릭터와 오브젝트 직접 충돌
				capcol.enabled = false;
				HeartManager.SendMessage("DecHeart", null);
			}
		}
	}


	void fall() {
		Vector3 playerPos = player.transform.position;

		if (playerPos.x < transform.position.x) {
			transform.rotation = Quaternion.Euler (0, 0, 90f);
			transform.position = new Vector3 (transform.position.x - 0.32f, transform.position.y - 0.32f, 0);
		} else {
			transform.rotation = Quaternion.Euler (0, 0, -90f);
			transform.position = new Vector3 (transform.position.x + 0.32f, transform.position.y - 0.32f, 0);
		}
	}

}
