using UnityEngine;

public class Heart_Decrease : MonoBehaviour {

    HeartManager HM;

    private void Start()
    {
        HM = FindObjectOfType<HeartManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_foot")
        {
            HM.SendMessage("DecHeart", null);
        }
    }

}
