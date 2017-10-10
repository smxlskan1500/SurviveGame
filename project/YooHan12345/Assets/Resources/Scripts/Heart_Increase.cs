using UnityEngine;

public class Heart_Increase : MonoBehaviour {

    HeartManager HM;
    Transform Item;
    Transform Player;

	void Start () {
        HM = FindObjectOfType<HeartManager>();
        Item = gameObject.transform;
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        if (Player.position.y > Item.position.y) Item.position = new Vector3(Item.position.x, Item.position.y, 0.0f);
        else Item.position = new Vector3(Item.position.x, Item.position.y, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_foot")
        {
            HM.SendMessage("InHeart", null);
            gameObject.SetActive(false);
        }
    }
}
