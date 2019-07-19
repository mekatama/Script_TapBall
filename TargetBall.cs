using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBall : MonoBehaviour {
	public GameObject gameController;	//検索したオブジェクト入れる用

	void Start () {
		
	}
	
	void Update () {

	}
	//他のオブジェクトとの当たり判定
	void OnTriggerEnter( Collider other) {
		if(other.tag == "Hole"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			gc.touchNumMax ++;		//touchNum回復
			gc.totalScore ++;		//totalScore加算
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
		}
		if(other.tag == "Trap"){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
			GameController gc = gameController.GetComponent<GameController>();
			gc.touchNumMax --;		//touchNum減る
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
		}	}
}
