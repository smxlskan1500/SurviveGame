using UnityEngine;

public class Escape : MonoBehaviour {

    public GUIManager GUIManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player_foot")
        {
            GUIManager.SendMessage("set_intrigger_true");
            GUIManager.SendMessage("setTagName", "escape");
			GUIManager.SendMessage("ChatOpen");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player_foot")
        {
            GUIManager.SendMessage("set_intrigger_false");
        }
    }
}
