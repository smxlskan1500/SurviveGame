using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingManager : MonoBehaviour {

	GameObject[] ceiling;
	private int totalnum = 22;
	Vector3 movePosition = new Vector3(0, 1.05f, 0);

	private void Awake()
	{
		ceiling = GameObject.FindGameObjectsWithTag("Ceiling");
		int length;
		length = ceiling.Length;

		foreach (GameObject _obj in ceiling) {
			_obj.transform.position += movePosition;
			_obj.SetActive (false);
		}
	}

	//방해 오브젝트 생성
	void Disturb()
	{
		int randnum = (int)Random.Range(0.0f, totalnum+1);

		if (totalnum > -1 ) {
			ceiling[randnum].SetActive(true);
			swap(ceiling, randnum);
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
