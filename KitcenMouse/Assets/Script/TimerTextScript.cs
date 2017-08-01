using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerTextScript : MonoBehaviour {

	public Text timerText; //Text用変数
	private float timer = 0; //タイム計算用変数

	//制限時間　秒
	public float maxTimer = 180; 

	void Start (){
		timerText.text = "X:XX"; 

	}

	void Update (){
		//タイマーが減ってく
		maxTimer-= Time.deltaTime;
		//タイマー表示
		timerText.text = Mathf.Floor(maxTimer / 60) + ":" + Mathf.Floor(maxTimer % 60).ToString("00"); // Mathf.Floorは切捨て		("00")は整数２桁表示

		//タイマーが０になったらゲームオーバー
		if (maxTimer <= 0) {
			Application.LoadLevel ("Result");
		}
	}
}