using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dash_Icon : MonoBehaviour
{
    /// <summary>
    /// ダッシュにクールタイムをつけるソースコード
    /// </summary>
    public Image image;// fillの画像
    public bool dash_Cool_Time = false;// クールタイムの判定
    public float countTime = 5.0f;// クールタイムの時間
    public float cool_Time = 0f;// クールタイムのアイコン内に表示する用の時間
    public PlayerMove playerMove;// playerのboolを参照
    public Text cool_Time_Text;//クールタイムの秒数表示用
    /// <summary>
    /// マウス入力を受け取ったらfillAmountが戻る関数
    /// </summary>
    void Update()
    {
        cool_Time_Text.text = cool_Time.ToString("n1");// クールタイムの現在の秒数を表示、("n1")は小数点第一位まで表示という意味
        if (dash_Cool_Time == true)// ダッシュをしたかの判定
        {
            image.fillAmount += 1.0f / countTime * Time.deltaTime;// 毎秒1秒ずつカウントし、fillAmountを増加させる
            cool_Time -= Time.deltaTime;// 1秒間につき1ずつcool_Timeを減らしていく
            if (cool_Time < 0)
            {
                cool_Time = 0;// マイナスを表示させない
            }
  
            if (image.fillAmount == 1f)// fillAmountが1になるかの判定
            {
                playerMove.dash = true;// PlayerMoveのdashをtrueにして再度ダッシュ可能にする
                Debug.Log("Cool_Time_Back");
            }
        }
    }
    /// <summary>
    /// ダッシュ時にfillAmountを0にし、クールタイムを開始する関数
    /// </summary>
    public void CTuse()
    {
        cool_Time = 5.0f; // アイコン内のクールタイムの時間を代入する
        image.fillAmount = 0f;// fillの初期化
        dash_Cool_Time = true;// クールタイムを開始させる
        playerMove.dash = false;// ダッシュを一定時間禁止させる
        Debug.Log("public void CTuse");
    }
}
