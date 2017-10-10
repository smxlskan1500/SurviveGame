using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//아이템 목록 : 피자, 도넛, 푸딩, 햄버거, 쥬스, 주먹밥, 김밥, 초밥, 사과, 컵케익 - 체력 회복 아이템들 관리

public class ItemSpawnManager : MonoBehaviour {

    public Sprite[] tempimage;

    GameObject[] items;
    float spawntime = 0.0f;
    float min, max;

    private void Awake()
    {

    }

    void Start () {
        if (gameObject.name == "ItemSpawn")
        {
            items = GameObject.FindGameObjectsWithTag("Heartup");
            min = 1.00f;
            max = 2.66f;
        }
        else if (gameObject.name == "ItemSpawn2")
        {
            items = GameObject.FindGameObjectsWithTag("Heartup2");
            min = 3.5f;
            max = 10.5f;
        }

        for (int i=0; i<items.Length; i++)
        {
            items[i].GetComponent<SpriteRenderer>().sprite = tempimage[(int)Random.Range(0.0f, 9.9f)];
            items[i].SetActive(false);
        }
    }

    private void Update()
    {
        spawntime += Time.deltaTime;
        if (spawntime >= Random.Range(30.0f, 50.0f))    //초마다 생성
        {
            spawnitem();
            spawntime = 0.0f;
        }
    }

    void spawnitem()
    {
        int idx = (int)Random.Range(0.0f, items.Length);
        int spawnnum = (int)Random.Range(min , max);  //1~2개 생성
        while(spawnnum > 0)
        {
            idx = (int)Random.Range(0.0f, items.Length);
            items[idx].SetActive(true);
            spawnnum--;
        }
    }
}
