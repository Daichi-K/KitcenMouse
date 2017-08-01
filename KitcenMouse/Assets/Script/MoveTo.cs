// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour {

	public Transform[] targetPos;	//ランダム歩行用ターゲット

	public Transform playerPos;	//ランダム歩行用ターゲット

	public GameObject dengerUI;	//追われているときのＵＩ(オブジェ)
	public Image dengerImage;	//追われているときのＵＩ(イメージ)
	Color alpha;	//透明度

	bool isChase = false;		//プレイヤーを追っているか

	NavMeshAgent agent;

	int inteval = 10;	//ターゲットからターゲットへの時間  

	int oldTargetRand = 0;	//被り防止の変数
	public int targetRand = 0;		//ターゲットを選ぶためのランダム変数

	public int timer = 0;

	void Start () {
		timer = 0;
		isChase = false;
		alpha = dengerImage.color;

		NavMeshAgent agent = GetComponent<NavMeshAgent>();

		//最初ランダムターゲットを追わせる
		targetRand = Random.Range (0, targetPos.Length);
		agent.destination = targetPos[targetRand].position; 
	}

	void Update () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		dengerImage.color = alpha; 		//追われているときのＵＩ

		if (IsRendered.isRend) {		//プレイヤーが視界内のとき

			//プレイヤーを追う
			isChase = true;
			agent.destination = playerPos.position; 
			timer = -3;
			alpha.a = 0.7f;

		} else {							//プレイヤーが視界外のとき
		timer++;
		//インターバル毎にターゲットを変える
			if (timer >= inteval * 60) {
				timer = 0;
				isChase = false;

				alpha.a = 0;		//UIのalphaを0にする

				oldTargetRand = targetRand;	

				//被っているかぎりランダムまわす
				while (oldTargetRand == targetRand) {
					targetRand = Random.Range (0, targetPos.Length);
				}

				agent.destination = targetPos [targetRand].position; 
			}
		}

		//プレイヤーが視界外で追われているとき
		if (timer <= inteval && !IsRendered.isRend) {
			
			alpha.a -= 0.05f;
		}
	}
}