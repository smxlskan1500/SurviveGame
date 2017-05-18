using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    private float time;
    private float waitingTime = 0.0f;
    private float cameraresetTime = 0.0f;
    private float[] RandTime = { 0.0f, 0.0f, 0.0f, 0.0f, 999.0f };
    private int shakeNum = 0;
    
    public Text timelabel;

    // Use this for initialization
    void Start () {
        setRandTime();
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        //시간초과 전 때까지 [TextUI]00:00 표시
        if (time < 100f) timecnt();     //완성용: time < 600f
        //시간 초과하면 [TextUI]GameOver 표시
        else
        {
            setTextGameOver();
        }
        //랜덤한 시간이 되면
        if (time > waitingTime)
        {
            int randnum = (int)Random.Range(1f, 3.9f);
            Debug.Log("바닥에 빵꾸" + randnum + "개 납니다.");

            GetComponent<CameraShake>().SendMessage("setShake", 8.0f);  //카메라 효과
            while (randnum > 0) //바닥에 빵꾸 1~3개 남
            {
                GetComponent<FloorManager>().SendMessage("Disturb", null);
                randnum--;
            }
            waitingTime = RandTime[shakeNum++];         //타이머를 다음 랜덤 시간으로
        }

        //랜덤시간 후 카메라 위치 리셋
        if(time > cameraresetTime)
        {
            GetComponent<CameraShake>().SendMessage("resetCamera", null);
            cameraresetTime = waitingTime + 8f;
        }
    }

    void setTextGameOver()
    {
        timelabel.fontSize = 13;
        timelabel.text = "<size=15><color=#ff0000>GameOver</color></size>";
        GetComponent<GameController>().SendMessage("GameOver", null);
    }

    //[TextUI]시간 표시
    public void timecnt()
    {
        int sec = (int)time;    //초
        int min = 0;            //분

        if (sec >= 60) {
            min = sec / 60;
            sec %= 60;
        }
        if ((int)time >= 85)   //완성용 time >= 570
            timelabel.text = "<color=#ff0000>" + min.ToString("00") + ":" + sec.ToString("00") + "</color>";
        else
            timelabel.text = min.ToString("00") + ":" + sec.ToString("00");
    }

    //랜덤한 시간 생성, 저장
    void setRandTime()
    {
        for (int i = 0; i < 4; i++)
        {
            //RandTime[i] = 90f + ((i) * 120f) + Random.Range(0.0f, 60.0f);  //완성용
            RandTime[i] = 30f + ((i) * 40f) + Random.Range(0.0f, 20.0f);     //데모용
            Debug.Log( i + "번째: " + RandTime[i]);
        }
        waitingTime = RandTime[shakeNum++];
    }
    
}
