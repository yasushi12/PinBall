using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;


	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent <HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
			SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
			SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーをもとに戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
			SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
			SetAngle(this.defaultAngle);
        }



		//発展課題（マルチタップ操作の追加）

		//タップ情報をmyTouchesへ格納する
		Touch[] myTouches = Input.touches;

		//画面の真ん中より左側でタップした時左フリッパーを動かす
		if (Input.touchCount == 1 && myTouches[0].phase == TouchPhase.Began && myTouches[0].position.x <= Screen.width / 2 && tag == "LeftFripperTag")
		//if条件（１．タップ数、２．タップ状態、３．タップ座標、４．タグ名）
		{
			SetAngle(this.flickAngle);
		}
		//画面の真ん中より右側でタップした時右フリッパーを動かす
		if (Input.touchCount == 1 && myTouches[0].phase == TouchPhase.Began && myTouches[0].position.x >= Screen.width / 2 && tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);
		}

		//左右で同時にタップした時左右のフリッパーを動かす
		//最初に左タップした場合
		if (Input.touchCount == 2 && myTouches[0].phase != TouchPhase.Ended && myTouches[1].phase != TouchPhase.Ended && myTouches[0].position.x <= Screen.width / 2 && myTouches[1].position.x >= Screen.width / 2 && tag == "LeftFripperTag")
			//if条件（１．タップ数、２．タップ状態（右側、左側）、３．タップ座標（左側、右側）、４．タグ名）
		{
			SetAngle(this.flickAngle);	//左フリッパーを動かす
		}
		if (Input.touchCount == 2 && myTouches[0].phase != TouchPhase.Ended && myTouches[1].phase != TouchPhase.Ended && myTouches[0].position.x <= Screen.width / 2 && myTouches[1].position.x >= Screen.width / 2 && tag == "RightFripperTag")
		{
			SetAngle(this.flickAngle);	//右フリッパーを動かす
		}
		//最初に右タップした場合
		if (Input.touchCount == 2 && myTouches[0].phase != TouchPhase.Ended && myTouches[1].phase != TouchPhase.Ended && myTouches[0].position.x >= Screen.width / 2 && myTouches[1].position.x <= Screen.width / 2 && tag == "RightFripperTag")
			//if条件（１．タップ数、２．タップ状態（右側、左側）、３．タップ座標（左側、右側）、４．タグ名）
		{
			SetAngle(this.flickAngle);	//右フリッパーを動かす
		}
		if (Input.touchCount == 2 && myTouches[0].phase != TouchPhase.Ended && myTouches[1].phase != TouchPhase.Ended && myTouches[0].position.x >= Screen.width / 2 && myTouches[1].position.x <= Screen.width / 2 && tag == "LeftFripperTag")
		{
			SetAngle(this.flickAngle);	//左フリッパーを動かす
		}


		//タップが終わった時フリッパーをもとに戻す
		//1タップの場合
		if (Input.touchCount == 1 && myTouches[0].phase == TouchPhase.Ended && tag == "LeftFripperTag")
		{
			SetAngle(this.defaultAngle);
		}
		if (Input.touchCount == 1 && myTouches[0].phase == TouchPhase.Ended  && tag == "RightFripperTag")
		{
			SetAngle(this.defaultAngle);
		}

		//2タップの場合
		//1タップ目が左タップのとき
		if (Input.touchCount == 2 && myTouches[0].phase == TouchPhase.Ended && myTouches[0].position.x <= Screen.width / 2 && tag == "LeftFripperTag")
			//if条件（１．タップ数、２．タップ状態（左側）、３．タップ座標（左側）、４．タグ名）
		{
			SetAngle(this.defaultAngle);
		}
		if (Input.touchCount == 2 && myTouches[1].phase == TouchPhase.Ended && myTouches[1].position.x >= Screen.width / 2 && tag == "RightFripperTag")
			//if条件（１．タップ数、２．タップ状態（右側）、３．タップ座標（右側）、４．タグ名）
		{
			SetAngle(this.defaultAngle);
		}
		//1タップ目が右タップのとき
		if (Input.touchCount == 2 && myTouches[0].phase == TouchPhase.Ended && myTouches[0].position.x >= Screen.width / 2 && tag == "RightFripperTag")
			//if条件（１．タップ数、２．タップ状態（右側）、３．タップ座標（右側）、４．タグ名）
		{
			SetAngle(this.defaultAngle);
		}
		if (Input.touchCount == 2 && myTouches[1].phase == TouchPhase.Ended && myTouches[1].position.x <= Screen.width / 2 && tag == "LeftFripperTag")
			//if条件（１．タップ数、２．タップ状態（左側）、３．タップ座標（左側）、４．タグ名）
		{
			SetAngle(this.defaultAngle);
		}


	}

	//フリッパーの傾きを設定
	public void SetAngle(float angle)
	{
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}
