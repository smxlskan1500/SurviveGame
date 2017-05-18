using UnityEngine;
using UnityEngine.UI;

public class FloorManager : MonoBehaviour {

    GameObject[] broken;
    private int totalnum = 11;

    private void Awake()
    {
        broken = GameObject.FindGameObjectsWithTag("Broken");
        int length;
        length = broken.Length;

        foreach (GameObject _obj in broken)
            _obj.SetActive(false);
    }

    //방해 오브젝트 생성
    void Disturb()
    {
        int randnum = (int)Random.Range(0.0f, totalnum+1);

        if (totalnum > -1 ) {
            broken[randnum].SetActive(true);
            swap(broken, randnum);
            totalnum--;
        }
    }

    void swap(GameObject[] arr, int idx)
    {
        GameObject temp = arr[idx];
        arr[idx] = arr[totalnum];
        arr[totalnum] = temp;
    }
}
