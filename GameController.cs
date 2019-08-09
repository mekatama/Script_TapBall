using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public int touchNum;	//touch回数
	public int touchNumMax;	//touch可能回数
	public int totalScore;	//score
	public bool isPlay;		//Play flag	
	public bool isDemoFinish;	//DemoFinish flag	
	float demoTime = 3.0f;		//UIを表示する時間
	float time_UI = 0f;			//UIを表示する時間用の変数
	public Canvas inGameCanvas;	//UI inGame
	public Canvas clearCanvas;	//UI crear
	public Canvas demoCanvas;	//UI demo

	//ゲームステート
	enum State{
		GameStart,	//
		Demo,		//
		Play,		//
		Clear,		//不要かも
	}
	State state;

	void Start () {
		inGameCanvas.enabled = true;	//canvas表示
		clearCanvas.enabled = false;	//canvas非表示
		demoCanvas.enabled = false;		//canvas非表示
		GameStart();					//初期ステート
	}

	void LateUpdate () {
		//ステートの制御
		switch(state){
			case State.GameStart:
				Demo();		//ステート移動		
				break;
			case State.Demo:
				demoCanvas.enabled = true;		//canvas表示
				if(isDemoFinish){
					demoCanvas.enabled = false;	//canvas非表示
					Play();		//ステート移動
				}
				break;
			case State.Play:
				isPlay = true;
				inGameCanvas.enabled = true;	//canvas表示
				//clear判定
				if(touchNumMax == 0){
					inGameCanvas.enabled = false;	//canvas非表示
					clearCanvas.enabled = true;		//canvas表示
					isPlay = false;
					Clear();	//ステート移動
				}
				break;
			//
			case State.Clear:
				Debug.Log("clear");
				break;
		}
	}

	void Update () {
//		Debug.Log("touch : " + touchNum);		
//		Debug.Log("touchMax : " + touchNumMax);		
//		Debug.Log("totalScore : " + totalScore);		

		//demo UIを時間で非表示にする
		if(isDemoFinish == false){
			time_UI += Time.deltaTime;
			if(time_UI > demoTime){
				isDemoFinish = true;
				time_UI = 0f;			//初期化
			}
		}
	}

	void GameStart(){
		state = State.GameStart;
	}
	void Demo(){
		state = State.Demo;
	}
	void Play(){
		state = State.Play;
	}
	void Clear(){
		state = State.Clear;
	}

	//return用の制御関数
	public void ButtonClicked_Return(){
		SceneManager.LoadScene("title");	//シーンのロード
	}
}
