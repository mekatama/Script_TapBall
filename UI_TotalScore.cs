using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TotalScore : MonoBehaviour{
	public GameObject gameController;	//GameController取得
	public Text totalScoreText;			//Textコンポーネント取得用

    void Update(){
		//gcって仮の変数にGameControllerのコンポーネントを入れる
		GameController gc = gameController.GetComponent<GameController>();
		//最大tap数表示
	    totalScoreText.text = "score : " + gc.totalScore.ToString("000000");
    }
}
