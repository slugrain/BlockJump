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
    public Slider distanceSlider;

    void Start()
    {

        distanceSlider = GetComponent<Slider>();

        float goalDistance = 118f;
        


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
