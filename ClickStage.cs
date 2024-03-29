﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cameraにMainCameraタグをアサイン忘れるな
//もしくはcameraをpublic経由でアサインする
public class ClickStage : MonoBehaviour {
	GameObject ground;			//tapしたオブジェクト入れる用
	GameObject gameController;	//検索したオブジェクト入れる用
	public GameObject ballObject = null;//ballプレハブ
	private Vector3 targetPosition;		//生成する位置
	private float timeElapsed = 0.0f;	//連射間隔カウント用
	public float timeOut;				//連射間隔の時間
	public bool isTouch;				//Touch flag

	void Start () {
		gameController = GameObject.FindWithTag ("GameController");	//GameControllerオブジェクトを探す
		isTouch = false;	//初期化
	}
	
	void Update () {
		//タップした判定
 		if(Input.GetMouseButtonDown(0)){
			Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit)){
				targetPosition = hit.point;		//タッチposition取得
//				Debug.Log("p.x : " + targetPosition.x);
				ground = hit.collider.gameObject;	//tapしたobject取得
			}else{
				ground = null;						//ground以外をタッチした扱い
			}

			//Groundがタッチされた時判定。error対策
			if(ground != null){
				//gcって仮の変数にGameControllerのコンポーネントを入れる
				GameController gc = gameController.GetComponent<GameController>();
				if(isTouch == false && gc.isPlay == true && gc.isDialog == false){
					//Groundをtapしたら
					if(ground.tag == "Ground"){
						Debug.Log("name : " + ground.transform.name);
						gc.touchNum ++;
						gc.touchNumMax --;
						//弾を生成する
						Instantiate( ballObject, targetPosition, transform.rotation);
						isTouch = true;
					}
				}
			}
		}

		//タッチcooltime
		if(isTouch){
			timeElapsed += Time.deltaTime;
			if(timeElapsed >= timeOut) {
				isTouch = false;
				timeElapsed = 0.0f;
			}
		}
	}
}
