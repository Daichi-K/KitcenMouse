using UnityEngine;
using System.Collections;

public class IsRendered : MonoBehaviour {

	//メインカメラに付いているタグ名
	private const string ENEMY_CAMERA_TAG_NAME = "EnemyCamera";

	//カメラに表示されているか(他スクリプトから参照されてる)
	private bool _isRendered = false;
	public static bool isRend = false;

	//Homeの中に入っているか
	private bool inHome = false;

	void Start () {
		
	}

	private void Update () {
		//Homeにはいっていなければ
		if (!inHome) {  
			//カメラに写ったとき
			if (_isRendered) {
				isRend = true;
			} else {
				isRend = false;
			}

			_isRendered = false;
		} else {
			isRend = false;
		}
	}

	//カメラに映ってる間に呼ばれる
	private void OnWillRenderObject(){
		//敵カメラに映った時だけ_isRenderedを有効に
		if(Camera.current.tag == ENEMY_CAMERA_TAG_NAME){
			_isRendered = true;
		}
	}

	//ホームに入っているか
	void OnTriggerStay(Collider collider){
		if (collider.gameObject.tag == "UnHome") {
			//ホーム以外のものにぶつかったら	ホームの出口に適当なオブジェをおいとく
			inHome = false;
		}
		if (collider.gameObject.tag == "Home") {
			inHome = true;
		} 
	}

}