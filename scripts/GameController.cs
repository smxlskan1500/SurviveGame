using System.Collections;
using System.Collections.Generic;
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
    CameraShake CameraShake;
    TimeManager TimeManager;

    GameObject AutoTileMap;
    public GameObject StateText;
    public PlayerMovement PlayerMovement;
    public Animator PlayerAnimator;

    private void Awake()
    {
        AutoTileMap = GameObject.Find("AutoTileMap");
        CameraShake = GetComponent<CameraShake>();
        TimeManager = GetComponent<TimeManager>();
    }

    // Use this for initialization
    void Start() {
        AutoTileMap.SetActive(false);
        Ready();
    }

    //게임의 스테이트마다 이벤트를 감시
    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                //탭하면 시작
                if (Input.GetButtonDown("Fire1")) GameStart();
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
        
        StateText.SetActive(true);
        StateText.GetComponentInChildren<Text>().text = "Ready\n<size=18>'touch'</size>";
        PlayerAnimator.enabled = false;
        PlayerMovement.enabled = false;
        TimeManager.enabled = false;
    }

    public void GameStart()
    {
        state = State.Play;
        
        PlayerMovement.enabled = true;
        PlayerAnimator.enabled = true;
        TimeManager.enabled = true;
        StateText.SetActive(false);

    }

    //게임 오버 됐을 때
    public void GameOver()
    {
        state = State.GameOver;
        
        PlayerAnimator.enabled = false;
        PlayerMovement.enabled = false;
        CameraShake.enabled = false;
        TimeManager.enabled = false;
        StateText.SetActive(true);
        StateText.GetComponentInChildren<Text>().text = "GameOver\n<size=18>'touch'</size>";
    }
}
