using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEffect : MonoBehaviour {

	public Sprite change = null;
	public bool isfalling = false;
	public float fallingTime = 0f;
	public float fallingSpd = -2f;

	// Update is called once per frame
	void Update () {
		if (isfalling) {
			gameObject.transform.Translate(new Vector3(0f, Time.deltaTime*fallingSpd ,0f));
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			isfalling = true;
			StartCoroutine(_change());
		}
	}

	IEnumerator _change(){
		yield return new WaitForSeconds(fallingTime);

		if (change != null) {
			isfalling = false;
			gameObject.GetComponentInChildren<SpriteRenderer>().sprite = change;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player" )
		{
			gameObject.GetComponent<Collider2D> ().enabled = false;
		}
	}
}