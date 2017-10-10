using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

    public CreativeSpore.RpgMapEditor.AutoTileset tileset;
    public CreativeSpore.RpgMapEditor.AutoTileMapData mapdata;
    
    public GameObject chatCanvas;
    public Text notice;
    public bool intrigger;  //트리거 안에 있는가
    public bool chatOpen;   //채팅창이 열려있는가

    public PlayerMovement PlayerMovement;
    public Animator PlayerAnimator;

    GameObject Coll2;
    GameObject ATM;
	GameObject Col_outside;
	GameObject Fallenobj;

	TimeManager TimeManger;
	int score;

    bool[] FindTip = { false, false, false, false, false, false, false, false, false };
    int tapNum = 0;
    int idx = 0;
    string tagName = "";
    string colName = "";
    string[] context =
    {
        "지진 발생 중 책상 아래로 몸을 피합니다.",			//tip1
        "지진 발생 중 쿠션이나 베개로 머리를 보호합니다.",	//tip2
        "유리창으로부터 떨어져 있도록 합니다.",				//tip3
        "차단기(두꺼비집)를 내려줍니다.",					//tip4
        "가스 밸브를 잠그도록 합니다.",						//tip5
        "피난 정보를 입수합니다.",							//tip6
        "대피 가능한 출구를 확보합니다.",					//tip7
        "깨진 유리조각을 조심합니다.",						//tip8
        "넘어진 가구를 조심합니다."							//tip9
    };
    private void Awake()
    {
        Coll2 = GameObject.Find("Colliders_out");
        ATM = GameObject.Find("AutoTileMap");
		Col_outside = GameObject.Find("Colliders_outside");
		Fallenobj = GameObject.Find ("FallenObject_outside");;
		TimeManger = FindObjectOfType<TimeManager>();
    }
    // Use this for initialization
    void Start() {
        Coll2.SetActive(false);
        chatOpen = false;
        intrigger = false;
        chatCanvas.SetActive(false);
        ATM.SetActive(false);

		Col_outside.SetActive (false);
		Fallenobj.SetActive (false);
    }

    // Update is called once per frame
    void Update() {

    }

    //대화창이 필요한 오브젝트의 영역에 "들어갔을 때" 어떤 오브젝트를 구별할 수 있는 tag 저장
    public void setTagName(string tagName)
    {
        this.tagName = tagName;
    }
    
	//몇번 tip인지 구별
    public void setColName(string colName)
    {
        this.colName = colName;
        idx = int.Parse(colName.Substring(3)) - 1;
    }

    public void set_intrigger_true()
    {
        intrigger = true;
    }

    public void set_intrigger_false()
    {
        intrigger = false;
        this.colName = null;
    }

    //Controll 버튼 눌렀을 때 
	public void ChatOpen() {
        //채팅창이 닫혀있는 상태 && 대화 오브젝트의 영역 안일 때
        if (chatOpen == false && intrigger == true) {
            //캐릭터가 멈추고 채팅창이 열린다.
            chatCanvas.SetActive(true);
            PlayerMovement.enabled = false;
            PlayerAnimator.enabled = false;

            //어떤 오브젝트인지 구별해주는 tagName에 따라 채팅창의 내용과 기능이 달라진다.
            switch (tagName) {
                //Tip오브젝트의 영역일 경우
                case "Tip":
				switch (tapNum)
				{
				case 0:
					notice.text = "\'" + colName + "\'을 발견했다!";
					tapNum++;
					break;
				case 1:
					notice.text = colName + " - " + context [idx];
					FindTip [idx] = true;
					if (idx == 0) {
						tapNum++;
					}else {
						chatOpen = true;
						tapNum = 0;
					}
					break;
				case 2:
					GameObject.FindGameObjectWithTag ("Player_foot").GetComponent<SpriteRenderer> ().enabled = false;
					chatCanvas.SetActive (false);
					GameObject.Find ("!").GetComponent<SpriteRenderer> ().enabled = false;
					chatOpen = true;
					tapNum = 0;
					break;
				}
				break;
                
                //현관문에서 탈출 여부를 정하는 영역일 경우
                case "escape":
                    escape();
                    break;
				case "Arrive":
					switch (tapNum)
					{
					case 0:
						score = (int)TimeManger.time;
						notice.text = "와우~! " + score + "초만에 도착하셨네요!";
						
						string posturl = "http://13.124.60.15/yoohan/Compare.php";
						
						WWWForm form = new WWWForm ();
						form.AddField ("id", PlayerPrefs.GetString ("ID"));
						form.AddField ("score", score);

						StartCoroutine (_compare (posturl, form));
						tapNum++;
						break;
					case 1:
						notice.text = "메인화면으로 돌아갑시다~";
						tapNum++;
						break;
					case 2:
						SceneManager.LoadScene ("main");
						break;
				}
				break;
            }
        }
        else {
			chatOpen = false;
			chatCanvas.SetActive(false);
            PlayerAnimator.enabled = true;
            PlayerMovement.enabled = true;
			if (tagName == "Tip") {
				GameObject.Find ("!").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.FindGameObjectWithTag("Player_foot").GetComponent<SpriteRenderer>().enabled = true;
			}
        }
	}

	IEnumerator _compare(string url, WWWForm form){
		WWW www;

		www = new WWW(url, form);
		yield return www;
	}
		

    public void escape()
    {
        int count = 0;  //Tip을 몇개 찾았는지

        for (int i = 0; i < FindTip.Length; i++)
            if (FindTip[i] == true)
                count++;

        //Tip 총 9개 다 찾았을 경우
        if (count > 3)
        {
            switch (tapNum)
            {
                case 0:
                    notice.text = "가정집에서의 모든 지진 대피 요령 TIP을 모두 모았어요.";
                    tapNum++;
                    break;
                case 1:
                    notice.text = "위험한 집에서 벗어나 가까운 피난처로 이동해요!";
                    tapNum++;
                    break;
                case 2:
                    chatOpen = true;
                    tapNum = 0;
                    set_intrigger_false();
                    StartCoroutine(_transition());  //집을 나온다는 채팅이 끝난 후 맵 전환!
                    break;
            }
        }
        //Tip을 다 찾지 못한 경우
        else
        {
			notice.text = "지진 대피 요령 Tip이 아직 모자라요! 5개 이상 찾아주세요! ( "+ count + "/9 )";
            chatOpen = true;
        }
    }

	//맵 바꾸기
    IEnumerator _transition()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("Colliders_house").SetActive(false);
        ATM.SetActive(true);
        ATM.GetComponent<CreativeSpore.RpgMapEditor.AutoTileMap>().SendMessage("setMD", mapdata);
        ATM.GetComponent<CreativeSpore.RpgMapEditor.AutoTileMap>().SendMessage("setTS", tileset);
        ATM.SetActive(false);
        Coll2.SetActive(true);
		Col_outside.SetActive (true);
		Fallenobj.SetActive (true);
        GameObject.Find("Player").transform.position = new Vector3(15.2f, -24.16f, -1.5f);
    }
}

    
