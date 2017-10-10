using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipObject : MonoBehaviour {

    public GUIManager GUIManager;
    public GameObject surprise;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player_foot")
        {
            GUIManager.SendMessage("set_intrigger_true");
            GUIManager.SendMessage("setColName", gameObject.name);
            GUIManager.SendMessage("setTagName", "Tip");
            surprise.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player_foot")
        {
            GUIManager.SendMessage("set_intrigger_false");
            surprise.SetActive(false);
        }
    }
}
