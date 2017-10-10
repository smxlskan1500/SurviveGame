using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour {

    int count = 0;
    Image[] hearts;

    TimeManager TM;
    
    void Start () {
        hearts = GameObject.Find("Hearts").GetComponentsInChildren<Image>();
        TM = FindObjectOfType<TimeManager>();
	}

    //하트 감소
    void DecHeart()
    {
        hearts[count].enabled = false;
        count++;
        if (count >= hearts.Length)
            TM.SendMessage("setTextGameOver", null);
    }

    //하트 증가
    void InHeart()
    {
        if (count > 0) {
            count--;
            hearts[count].enabled = true;
        }
    }
}
