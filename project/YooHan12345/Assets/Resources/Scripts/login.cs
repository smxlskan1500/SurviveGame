using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour {

    public Button LoginButton;
    public Button JoinButton;
    public Button OkButton;
    public Button BackButton;
    public InputField user_id_Field;
    public InputField password_Field;
    public Text noticeText;
    
    // Use this for initialization
    void Start()
    {
        LoginButton.onClick.AddListener(_login);
        JoinButton.onClick.AddListener(_join);
        BackButton.onClick.AddListener(_back);
        OkButton.onClick.AddListener(_ok);
        
        OkButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);
    }

    void _join()
    {
        JoinButton.gameObject.SetActive(false);
        LoginButton.gameObject.SetActive(false);
        OkButton.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);

        user_id_Field.text = "";
        password_Field.text = "";
        noticeText.text = "<color=#000000>등록할 아이디와 비밀번호를\n입력해주세요</color>";
    }

    void _ok()
    {
        string posturl = "http://13.124.60.15/yoohan/Join.php";

        WWWForm form = new WWWForm();
        form.AddField("id", user_id_Field.text);
        form.AddField("pswd", password_Field.text);

        //유저 아이디, 패스워드 데이터 전송
        StartCoroutine(SendData_join(posturl, form));
    }

    IEnumerator SendData_join(string url, WWWForm form)
    {
        WWW www;

        www = new WWW(url, form);
        yield return www;

        string result = www.text;

        if (result.Equals("success"))
        {
            Debug.Log("Join Success!");
            noticeText.text = "<color=#000000>등록이\n완료 되었습니다</color>";
        }
        else
        {
            Debug.Log("reload");
            noticeText.text = "<color=#FF0000>아이디가\n중복됩니다</color>";
        }
    }

    void _login()
    {
        string posturl = "http://13.124.60.15/yoohan/Login.php";

        WWWForm form = new WWWForm();
        form.AddField("id", user_id_Field.text);
        form.AddField("pswd", password_Field.text);
        
        //유저 아이디, 패스워드 데이터 전송
        StartCoroutine(SendData_login(posturl, form));
    }

    IEnumerator SendData_login(string url, WWWForm form)
    {
        WWW www;

        www = new WWW(url, form);
        yield return www;

        if (www.error == null)
        {
            Debug.Log("(Login)WWW Ok! : " + www.text);
        }
        else
        {
            Debug.Log("(Login)WWW Error : " + www.error);
        }

        string result = www.text;

        if (result.Equals("success"))
        {
            Debug.Log("login start");
            PlayerPrefs.SetString("ID",user_id_Field.text);
            LoginSuccess();
        }
        else
        {
            Debug.Log("reload");
            noticeText.text = "<color=#FF0000>아이디나 비밀번호를\n확인해주세요</color>";
            user_id_Field.text = "";
            password_Field.text = "";
        }
    }

    void _back()
    {
        OkButton.gameObject.SetActive(false);
        BackButton.gameObject.SetActive(false);
        LoginButton.gameObject.SetActive(true);
        JoinButton.gameObject.SetActive(true);

        noticeText.text = "";
        user_id_Field.text = "";
        password_Field.text = "";
    }

    void LoginSuccess()
    {
        SceneManager.LoadScene("main");
    }
}
