using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojyama : MonoBehaviour
{
    public bool isRotation; //回転flag
    public int rot_x;       //回転値
    public int rot_y;       //
    public int rot_z;       //
    public bool isMove;     //移動flag
	private bool isMoveGo;	//移動進むflag
	private bool isMoveTuru;//移動戻るflag
	public float mov_x;     //移動値
    public float mov_y;     //移動値
    public float mov_z;     //移動値
    public float moveTime;  //片道移動時間
	private float timeElapsed = 0.0f;	//カウント

	void Start () {
		isMoveGo = true;	//初期化
	}

    void Update(){
		//回転
        if(isRotation){
    		transform.Rotate(new Vector3(rot_x, rot_y, rot_z) * Time.deltaTime);
        }
		//往復移動
		if(isMove){
			//往路
			if(isMoveGo && isMoveTuru == false){
				timeElapsed += Time.deltaTime;
				transform.position += new Vector3 (mov_x, mov_y, mov_z);
				if(timeElapsed >= moveTime) {
					timeElapsed = 0.0f;
					isMoveGo = false;
					isMoveTuru = true;
				}
			}
			//復路
			if(isMoveGo == false && isMoveTuru){
				timeElapsed += Time.deltaTime;
				transform.position += new Vector3 (-mov_x, -mov_y, -mov_z);
				if(timeElapsed >= moveTime) {
					timeElapsed = 0.0f;
					isMoveGo = true;
					isMoveTuru = false;
				}
			}
		}
    }
}