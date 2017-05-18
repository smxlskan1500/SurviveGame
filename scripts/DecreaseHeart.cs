using UnityEngine;

public class DecreaseHeart : MonoBehaviour {

    HeartManager HM;

    private void Start()
    {
        HM = FindObjectOfType<HeartManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HM.SendMessage("DecHeart", null);
        }
    }

}
