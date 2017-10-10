using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEffect : MonoBehaviour {

    private void Start()
    {
        GetComponent<Animation>().Stop();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<Animation>().Play();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            gameObject.GetComponent<Animation>().enabled = false;
			gameObject.GetComponent<Collider2D> ().enabled = false;
        }
    }
}
