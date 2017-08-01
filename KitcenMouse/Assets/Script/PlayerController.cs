using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject angleTarget;
	public GameObject player;
	public GameObject parentPlayer;

	public float power = 10;
	public float dashPower = 15;
	public float cameraSpeed = 10;

	Animator playerAnimator;

	//カメラ移動
	float cameraRotationY = 0;

	//ダッシュしているかどうか
	bool isRunning = false;

	//ジャンプ力
	public float jumpPower = 100.0f;

	//動かない状態が続いているカウント
	int nomalCount = 0;

	//一時的にpowerを入れる変数
	float oldPower;

	Vector3 angleObjectPos;
	float playerPosX = 0;
	float playerPosZ = 0;

	//コントローラー入力値
	float leftHorizontal = 0;
	float leftVertical = 0;
	float rightHorizontal = 0;
	float rightVertical = 0;


	void Start () {
		oldPower = power;

		playerAnimator = player.GetComponent<Animator>();
	}


	void Update () {
		InPutController ( );	//コントローラー入力
		AngleController ();		//向き変更用オブジェクトの座標移動
		PlayerMove( );			//プレイヤーの座標移動
		CameraControll( );		//カメラ移動
		AnimatorControll( );	//アニメーターフラグ調整
		JumpController( );		//ジャンプ処理
	}

	//アニメーターフラグ調整
	void AnimatorControll( ){
		//playerAnimator.SetBool("isItching", true );

		//歩いているか
		if (leftHorizontal != 0 || leftVertical != 0) {
			playerAnimator.SetBool ("isWalking", true);

			//走ったら
			if (isRunning) {
				playerAnimator.SetBool("isRunning", true );
			}

			nomalCount = 0;
		} else {
			playerAnimator.SetBool ("isWalking", false);
			playerAnimator.SetBool("isRunning", false );

			nomalCount++;
		}

		//走ってない
		if (!isRunning) {
			playerAnimator.SetBool("isRunning", false );
		}
			
		//動いていない状態が続いたら
		if (nomalCount >= 300) {
			playerAnimator.SetBool ("isItching", true);
			nomalCount = 0;
		} else {
			playerAnimator.SetBool ("isItching", false);
		}
	}

	//カメラ移動
	void CameraControll( ) {
		//カメラ移動のチカラ調整
		cameraRotationY += rightHorizontal / 10 * cameraSpeed;

		parentPlayer.transform.rotation = Quaternion.Euler(0,cameraRotationY,0);
	}
		

	//プレイヤーの座標移動
	void PlayerMove( ) {
		//チカラ調整
		playerPosX = leftHorizontal / 100 * power;
		playerPosZ = leftVertical / 100 * power;

		//コントローラーＡ押している(ダッシュ)
		if (Input.GetKey(KeyCode.Joystick1Button0)) {
			power = dashPower;
			isRunning = true;
		} else {
			power = oldPower;
			isRunning = false;
		}

		parentPlayer.transform.Translate (playerPosX, 0, playerPosZ);

		//ターゲットをみる
		player.transform.LookAt (angleTarget.transform);
	}

	//向き変更用オブジェクトの座標移動
	void AngleController(){
		//コントローラーからの数字を代入
		angleObjectPos.x = leftHorizontal / 2;
		angleObjectPos.z = leftVertical / 2;
		angleObjectPos.y = 0;

		angleTarget.transform.localPosition = angleObjectPos;

		//ターゲットをみる
		player.transform.LookAt (angleTarget.transform);
	}

	//コントローラー入力
	void InPutController( ) {
		// 左スティックのよこ方向の傾き
		leftHorizontal = Input.GetAxis("Horizontal");
		// 左スティックのたて方向の傾き
		leftVertical = Input.GetAxis("Vertical");
		// 右スティックのよこ方向の傾き
		rightHorizontal = Input.GetAxis("Horizontal2");
		// 右スティックのたて方向の傾き
		rightVertical = Input.GetAxis("Vertical2");
	}

	//ジャンプ処理
	void JumpController( ) {
		if (!Grounding.isJumping) {
			if (Input.GetKeyDown (KeyCode.Joystick1Button2)) {
				parentPlayer.GetComponent<Rigidbody> ().AddForce (0, jumpPower, 0);
			}
		}
	}
}
