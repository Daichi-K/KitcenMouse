using UnityEngine;
using System.Collections;

public class catchScrpit : MonoBehaviour {

	public GameObject catchMeat;		//つかんでいるオブジェ
	public GameObject meat;		//拾うオブジェ

	bool catching = false;		//つかんでいるか

	// Use this for initialization
	void Start () {
		catching = false;
	}
	
	// Update is called once per frame
	void Update () {
		//キャッチしているときの処理
		if (catching) {
			catchMeat.SetActive ( true );

			//つかむボタンを離す
			if (Input.GetKeyUp (KeyCode.Joystick1Button5)) {
				catching = false;
				Instantiate(meat, this.gameObject.transform.position, Quaternion.identity);
			}
		} else {
			catchMeat.SetActive ( false );
		}
	}

	void OnTriggerStay(Collider collider){

		//foodタグオブジェが目の前にある状態でぼたんをおしたら
		if (Input.GetKeyDown(KeyCode.Joystick1Button5)) {
			if (collider.gameObject.tag == "Food") {
				Destroy (collider.gameObject);
				catching = true;
			}
		}
	}
}
