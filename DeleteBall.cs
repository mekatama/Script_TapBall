using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBall : MonoBehaviour {
//	private float tempScale = 1.0f;

	// Use this for initialization
	void Start () {
		Destroy(gameObject,0.15f);	//オブジェクトの削除
	}

	void Update () {
//		tempScale -= 0.1f;
//		this.transform.localScale = new Vector3(tempScale, tempScale, tempScale);
	}
}
