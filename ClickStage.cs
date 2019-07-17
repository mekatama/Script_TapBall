using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//cameraにMainCameraタグをアサイン忘れるな
//もしくはcameraをpublic経由でアサインする
public class ClickStage : MonoBehaviour {
//	GameObject ground;			//tapしたオブジェクト入れる用
	public GameObject ballObject = null;//ballプレハブ
	private Vector3 targetPosition;		//生成する位置

	void Start () {
		
	}
	
	void Update () {
		//タップした判定
 		if(Input.GetMouseButtonDown(0)){
			//gcって仮の変数にGameControllerのコンポーネントを入れる
//			GameController gc = gameController.GetComponent<GameController>();
			Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast(ray, out hit)){
				targetPosition = hit.point;		//タッチposition取得
//				Debug.Log("p.x : " + targetPosition.x);
//				ground = hit.collider.gameObject;	//tapしたobject取得
//				Debug.Log("name : " + ground.transform.name);

				//弾を生成する
				Instantiate( ballObject, targetPosition, transform.rotation);

			}else{
//				ground = null;						//zombie以外をタッチした扱い
			}
		}
	}
}
