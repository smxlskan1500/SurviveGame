using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObject : MonoBehaviour { //간판들

	public int fallentype;

	HeartManager HeartManager;
	CapsuleCollider2D capcol;
	BoxCollider2D boxcol;

	// Use this for initialization
	void Start () {
		HeartManager = FindObjectOfType<HeartManager>();
		capcol = gameObject.GetComponent<CapsuleCollider2D> ();
		boxcol = gameObject.GetComponent<BoxCollider2D> ();
		boxcol.enabled = true;
		capcol.enabled = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Player") {
			if (capcol.enabled == false) { //캐릭터가 범위에 들어왔을때
				capcol.enabled = true;
				boxcol.enabled = false;
				drop ();
			} else { //캐릭터와 오브젝트 직접 충돌
				capcol.enabled = false;
				bump ();
			}
		}
	}



	public void drop() {

		//fall Bouncing
		Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D> ();
		Vector2 fallVelocity = new Vector2(0,0);

		if (fallentype == 0) {
			fallVelocity = new Vector2 (-0.00003f, 0);
		} else if (fallentype == 1) {
			fallVelocity = new Vector2 (0, -0.00003f);
		} else if (fallentype == 2) {
			fallVelocity = new Vector2 (0.00003f, 0);
		}

		rigid.gravityScale = 0.5f;
		rigid.AddForce (fallVelocity, ForceMode2D.Impulse);

		Destroy (gameObject, 1f);
	}

	public void bump() {
		HeartManager.SendMessage("DecHeart", null);
		Destroy (gameObject);
	}
}
