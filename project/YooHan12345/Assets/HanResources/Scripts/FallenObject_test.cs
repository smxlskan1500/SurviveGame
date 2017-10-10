using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenObject_test : MonoBehaviour {

    public HeartManager HeartManager;
	public int fallentype;
    
    CircleCollider2D circol;
	BoxCollider2D boxcol;

	// Use this for initialization
	void Start () {
		circol = gameObject.GetComponent<CircleCollider2D> ();
		boxcol = gameObject.GetComponent<BoxCollider2D> ();
		boxcol.enabled = false;
		circol.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.gameObject.tag == "Player") {
			
			Debug.Log ("enter-other");

			if (boxcol.enabled == false) { //캐릭터가 범위에 들어왔을때
				boxcol.enabled = true;
				circol.enabled = false;
				fall ();
			} else { //캐릭터와 오브젝트 직접 충돌
				boxcol.enabled = false;
				HeartManager.SendMessage("DecHeart", null);
			}
		}
	}



	public void fall() {

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

		//Remove Object
		Destroy (gameObject, 0.6f);
	}		
}
