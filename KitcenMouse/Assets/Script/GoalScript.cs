using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider collider){
		//フードタグオブジェクトが入っていたら
		if (collider.gameObject.tag == "Food") {
			ScoreTextScrpt.score += 100;	//スコア+100
			Destroy (collider.gameObject);
		}
	}
}
