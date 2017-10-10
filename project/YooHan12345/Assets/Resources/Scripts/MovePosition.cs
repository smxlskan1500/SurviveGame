﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePosition : MonoBehaviour {

    public GameObject portal;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player_foot")
        {
            Vector3 anotherfloor = portal.transform.position;
			Vector3 warpPos = new Vector3();
			switch(gameObject.name){
			case "MP_1F":
				warpPos = new Vector3 (anotherfloor.x, anotherfloor.y + 0.5f, anotherfloor.z);
				break;
			case "MP_2F":
				warpPos = new Vector3 (anotherfloor.x, anotherfloor.y - 0.5f, anotherfloor.z);
				break;
			}
            GameObject.FindGameObjectWithTag("Player").transform.position = warpPos;
        }
    }
}
