using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	private int SmallStarPoint = 5;		//小さい星の得点
	private int LargeStarPoint = 20;	//大きい星の得点
	private int SmallCloudPoint = 15;	//小さい雲の得点
	private int LargeCloudPoint = 50;   //大きい雲の得点

	//総得点を格納する
	private int ScorePoint = 0;

	//得点を表示するテキスト
	private GameObject score_Text;

	// Use this for initialization
	void Start () {
		//シーン中のScorePointTextオブジェクトを取得
		this.score_Text = GameObject.Find("ScorePointText");
	}
	
	// Update is called once per frame
	void Update () {

	}


	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision collision)
    {
		//総得点に加点する
		if(collision.gameObject.tag == "SmallStarTag")
        {
			this.ScorePoint = this.ScorePoint + this.SmallStarPoint;
		}
		else if (collision.gameObject.tag == "LargeStarTag")
        {
			this.ScorePoint = this.ScorePoint + this.LargeStarPoint;
        }else if (collision.gameObject.tag == "SmallCloudTag")
        {
			this.ScorePoint = this.ScorePoint + this.SmallCloudPoint;
        }else if (collision.gameObject.tag == "LargeCloudTag")
        {
			this.ScorePoint = this.ScorePoint + this.LargeCloudPoint;
        }

		//総得点を表示する
		this.score_Text.GetComponent<Text>().text = "Score:" + ScorePoint;
	}

}
