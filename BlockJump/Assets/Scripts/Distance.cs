using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Distance : MonoBehaviour
{
    public Transform player;     // プレイヤーオブジェクトのTransform
    public Transform goal;       // ゴールオブジェクトのTransform
    public Text distanceText;    // 距離を表示するUIテキスト
    public Slider distanceSlider; // スライダー参照

    void Start()
    {
        //スライダー取得
        distanceSlider = GetComponent<Slider>();
        //ゴールの距離を設定
        float goalDistance = 172f;
        //スライダーの最大値の設定
        distanceSlider.maxValue = goalDistance;
    }
    public void Update()
    {
        // プレイヤーとゴールの位置を取得
        Vector3 playerPosition = player.position;
        Vector3 goalPosition = goal.position;

        // プレイヤーとゴールの位置の差を計算
        float distanceToGoal = Vector3.Distance(playerPosition, goalPosition);
        // if (distanceToGoal < 0) distanceToGoal = 0;
        // 距離をUIテキストに表示
        
        distanceText.text = "ゴールまで残り" + ((int)distanceToGoal) + "メートル!";

        //スライダーの現在値の設定
        distanceSlider.value = distanceToGoal;
    }
}
