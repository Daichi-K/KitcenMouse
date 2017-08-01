using UnityEngine;
using System.Collections;

public class Grounding : MonoBehaviour {

	//他スクリプトからの参照用
	public static bool isJumping = false;

	// Use this for initialization
	void Start () {
		isJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//地面についていれば
	void OnCollisionStay(Collision Collision) {
		isJumping = false;
	}

	//地面から晴れた
	void OnCollisionExit(Collision Collision) {
		isJumping = true;
	}

	//猫とねずみがついたゲームオーヴァー
	void OnTriggerStay(Collider collider) {
		if (collider.gameObject.tag == "Enemy") {
			Application.LoadLevel ("Result");
		}
	}
}
