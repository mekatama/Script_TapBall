using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public int touchNum;	//touch回数
	public int touchNumMax;	//touch可能回数
	public int totalScore;	//score
	public bool isPlay;	//Play flag	

	//ゲームステート
	enum State{
		GameStart,	//
		Demo,		//
		Play,		//
		Clear,		//不要かも
	}
	State state;

	void Start () {
		GameStart();					//初期ステート
	}

	void LateUpdate () {
		//ステートの制御
		switch(state){
			case State.GameStart:
				Demo();		//ステート移動		
				break;
			case State.Demo:
				isPlay = true;
				Play();		//ステート移動
				break;
			case State.Play:
				//clear判定
				if(touchNumMax == 0){
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
		Debug.Log("touchMax : " + touchNumMax);		
//		Debug.Log("totalScore : " + totalScore);		
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
}
