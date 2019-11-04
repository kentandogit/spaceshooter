using UnityEngine;
using System.Collections;

public class FiboGameController : MonoBehaviour {

	public TextMesh ScoreText;
	public TextMesh	TimerText;
	public int timer;
	private int prevNum;
	private int currentNum;
	private int targetNum;
	private int goalTime;
	// Use this for initialization
	void Start () {
		TimerText.text = "35";
		prevNum = 1;
		currentNum = 1;
		targetNum = 2;
		ScoreText.text = prevNum + " " + currentNum;
		goalTime = (int) Time.time + timer;
	}
	
	// Update is called once per frame
	void Update () {
		float time = goalTime - Time.time;
		TimerText.text = time.ToString ();
	}
}
