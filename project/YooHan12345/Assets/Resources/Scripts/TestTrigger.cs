using UnityEngine;
using UnityEngine.UI;

public class TestTrigger : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //콜리더에 플레이어가 들어오면 트리거 발동
        if (other.gameObject.tag == "Player")
        {
            //트리거 내용
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //콜리더에 플레이어가 나가면 트리거 발동
        if (other.gameObject.tag == "Player")
        {
            //트리거 내용
        }
    }
}
