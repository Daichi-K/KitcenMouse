using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScrpt : MonoBehaviour {
	public Text scoreText; //Text用変数
	public static float score = 0; //スコア計算s用変数		他から参照

	void Start (){
		scoreText.text = "Score:XXXX"; 
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score:" + score;
	}
}
