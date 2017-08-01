using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReslutScore : MonoBehaviour {
	public Text scoreText; //Text用変数

	public Text[] rankingText = new Text[5]; //Text用変数

	private float[] highScore = { 0, 0, 0, 0, 0 }; //ハ上位5スコア計算用変数

	//上位5スコアの保存先キー
	private string[] key = {"1st SCORE", "2st SCORE", "3st SCORE", "4st SCORE", "5st SCORE"};


	void Start (){
		scoreText.text = "XXXX"; 

		//保存しておいた上位5スコアをキーで呼び出し取得
		//保存されていなければ0が返る
		for(int i = 0; i < 5; i++ ) {
			highScore[i] = PlayerPrefs.GetFloat(key[i], 0.0f);
		}

		//ランキングの更新と保存
		if (ScoreTextScrpt.score >= highScore[0]) {
			//２位以降を降格
			for (int i = 4; i > 0; i--) {
				highScore[i] = highScore[i - 1];
				PlayerPrefs.SetFloat(key[i], highScore[i]);
			}

			//一位の更新
			highScore[0] = ScoreTextScrpt.score;
			//一位の保存
			PlayerPrefs.SetFloat(key[0], highScore[0]);
		}
		for (int i = 1; i < 5; i++) {
			if (ScoreTextScrpt.score >= highScore[i] && ScoreTextScrpt.score < highScore[i - 1] ) {
				//更新スコア以下降格
				for (int j = 4; j > i; j--) {
					highScore[j] = highScore[j - 1];
					PlayerPrefs.SetFloat(key[j], highScore[j]);
				}

				//2~4の更新
				highScore[i] = ScoreTextScrpt.score;
				//2~4の保存
				PlayerPrefs.SetFloat(key[i], highScore[i]);
			}
		}

		//スコア表示
		for (int i = 0; i < 5; i++) {
			rankingText [i].text = (i + 1) + "位：" + highScore [i].ToString ();
		}


	}

	// Update is called once per frame
	void Update () {
		//スコア表示
		scoreText.text = ScoreTextScrpt.score.ToString();

		//タイトルへ
		GoTiTle ();
	}

	//タイトルに戻る
	public void GoTiTle(){
		if (Input.GetMouseButton(0)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button0)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button1)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button2)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button3)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button4)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button5)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button6)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button7)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button8)) {
			Application.LoadLevel ("Title");
		}
		if (Input.GetKey(KeyCode.Joystick1Button9)) {
			Application.LoadLevel ("Title");
		}



	}
}
