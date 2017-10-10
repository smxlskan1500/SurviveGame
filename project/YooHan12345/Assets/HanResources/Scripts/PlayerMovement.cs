using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float movePower = 6f;

	public bool inputLeft = false;
	public bool inputRight = false;
	public bool inputUp = false;
	public bool inputDown = false;

	public bool onTrigger = false;
    public GUIManager GUIManager;

	Animator animator;

	Vector3 movement;

	// Use this for initialization
	void Start () {
		animator = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Move ();
	}

	void Move() {

		Vector3 moveVelocity = Vector3.zero;

		if (inputLeft) {
			moveVelocity = Vector3.left;
			animator.SetFloat ("dirX", -1);
			animator.SetFloat ("dirY", 0);
            animator.speed = 1;
        } else if (inputRight) {
			moveVelocity = Vector3.right;
			animator.SetFloat ("dirX", 1);
			animator.SetFloat ("dirY", 0);
            animator.speed = 1;
        } else if (inputUp) {
			moveVelocity = Vector3.up;
			animator.SetFloat ("dirX", 0);
			animator.SetFloat ("dirY", 1);
            animator.speed = 1;
        } else if (inputDown) {
			moveVelocity = Vector3.down;
			animator.SetFloat ("dirX", 0);
			animator.SetFloat ("dirY", -1);
            animator.speed = 1;
        } else {
            animator.speed = 0;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
	}


	void OnTriggerEnter2D (Collider2D other)
    {
		onTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTrigger = false;
    }
}
