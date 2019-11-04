using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

	public string textName;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchEnded()
	{
		GameObject ballonNum = this.transform.Find(textName).gameObject;
		TextMesh tm = ballonNum.GetComponent<TextMesh>();
		tm.text = "havoe";
	}
}
