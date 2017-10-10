using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainManager : MonoBehaviour {

    public Button play;
    public Button rank;
    public Button exit;

	void Start () {
        play.onClick.AddListener(_play);
        rank.onClick.AddListener(_rank);
        exit.onClick.AddListener(_exit);
	}

    void _play()
    {
        SceneManager.LoadScene("house");
    }

    void _rank()
    {
        SceneManager.LoadScene("Rank");
    }

    void _exit()
    {
        Application.Quit();
    }
}
