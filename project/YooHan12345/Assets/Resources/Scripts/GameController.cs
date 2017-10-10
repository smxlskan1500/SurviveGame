﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    enum State
    {
        Ready,
        Play,
        GameOver,
    }

    State state;
    CameraShake CS;
    TimeManager TimeManager;
    ItemSpawnManager ItemSM;

    GameObject Set;
    GameObject AutoTileMap;
    GameObject surprise;

    public GameObject StateText;
    public PlayerMovement PlayerMovement;
    public Animator PlayerAnimator;

    private void Awake()
    {
        Set = GameObject.Find("Set");
        surprise = GameObject.Find("!");
        CS = GetComponent<CameraShake>();
        ItemSM = GameObject.Find("ItemSpawn").GetComponent<ItemSpawnManager>();
        TimeManager = GetComponent<TimeManager>();
    }

    // Use this for initialization
    void Start() {
        surprise.SetActive(false);
        Ready();
    }

    //게임의 스테이트마다 이벤트를 감시
    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                //탭하면 시작
                if (Input.GetButtonDown("Fire1")) StartCoroutine(GameStart());
                break;
            case State.Play:
                break;
            case State.GameOver:
                //탭하면 씬 리로드
                if (Input.GetButtonDown("Fire1")) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }
    }
    
    public void Ready()
    {
        state = State.Ready;

        Set.SetActive(false);
        surprise.SetActive(false);
        StateText.SetActive(true);
        StateText.GetComponentInChildren<Text>().text = "Ready\n<size=18>'touch'</size>";
        PlayerAnimator.enabled = false;
        PlayerMovement.enabled = false;
        TimeManager.enabled = false;
        ItemSM.enabled = false;
    }
    
    IEnumerator GameStart()
    {
        state = State.Play;
        StateText.SetActive(false);

        yield return StartCoroutine(_GameStart());

        Set.SetActive(true);
        surprise.SetActive(false);
        PlayerMovement.enabled = true;
        PlayerAnimator.enabled = true;
        TimeManager.enabled = true;
        ItemSM.enabled = true;
    }

    IEnumerator _GameStart()
    {
        CS.SendMessage("setShake", 3);
        surprise.SetActive(true);
        yield return new WaitForSeconds(3);
    }

    //게임 오버 됐을 때
    public void GameOver()
    {
        state = State.GameOver;

        Set.SetActive(false);
        
        PlayerAnimator.enabled = false;
        PlayerMovement.enabled = false;
        ItemSM.enabled = false;
        CS.enabled = false;
        TimeManager.enabled = false;
        StateText.SetActive(true);
        StateText.GetComponentInChildren<Text>().text = "GameOver\n<size=18>'touch'</size>";
    }
}
