using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour {

	GUIManager GUI;

	// Use this for initialization
	void Start () {
		GUI = FindObjectOfType<GUIManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
	
		if (other.gameObject.tag == "Player") {
			GUI.SendMessage ("set_intrigger_true");
			GUI.SendMessage ("setTagName", "Arrive");
		}
	}
}
