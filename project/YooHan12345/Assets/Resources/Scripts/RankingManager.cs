using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour {

    public Text rank4, rank5, rank6;
    public Text name1, name2, name3, name4, name5, name6;
    public Text score1, score2, score3, score4, score5, score6;
    Button BackButton;

	void Start () {
        name5.text = PlayerPrefs.GetString("ID");
        BackButton = FindObjectOfType<Button>();
        BackButton.onClick.AddListener(_back);
        rank();
	}

    void rank()
    {
        string posturl = "http://13.124.60.15/yoohan/Rank123.php";
        StartCoroutine(_rank(posturl));
    }

    IEnumerator _rank(string url)
    {
        WWW www;

        www = new WWW(url);
        yield return www;

        string[] result = www.text.Split('\t');

        rank123(result);
        rank456(result);
    }

    void rank123(string[] result)
    {
        name1.text = result[1];
        score1.text = makeTime(result[2]);
        name2.text = result[4];
        score2.text = makeTime(result[5]);
        name3.text = result[7];
        score3.text = makeTime(result[8]);
    }

    void rank456(string[] result)
    {
        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] == PlayerPrefs.GetString("ID"))
            {
                rank5.text = result[i - 1];
                name5.text = result[i];
                score5.text = makeTime(result[i + 1]);
                if (i == 1)
                {
                    rank4.text = "- -";
                    name4.text = "- -";
                    score4.text = "- -:- -";
                }
                else
                {
                    rank4.text = result[i - 4];
                    name4.text = result[i - 3];
                    score4.text = makeTime(result[i - 2]);
                }
                if(i > result.Length - 4)
                {
                    rank6.text = "- -";
                    name6.text = "- -";
                    score6.text = "- -:- -";
                }
                else
                {
                    rank6.text = result[i + 2];
                    name6.text = result[i + 3];
                    score6.text = makeTime(result[i + 4]);
                }
            }
        }
    }

    void _back()
    {
        SceneManager.LoadScene("main");
    }

    string makeTime(string time)
    {
        string result = "";
        int min, sec, temp;
        temp = int.Parse(time);
        min = temp / 60;
        sec = temp % 60;
        result = min.ToString("00") + ":" + sec.ToString("00");

        return result;
    }
}
