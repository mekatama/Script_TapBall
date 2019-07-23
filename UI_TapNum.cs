using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TapNum : MonoBehaviour{
	public GameObject gameController;	//GameController取得
	public Text tapNumText;				//Textコンポーネント取得用

    void Update(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//最大tap数表示
	    tapNumText.text = "nokori tap num : " + gc.touchNumMax.ToString("000");
    }
}
