using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI機能を扱うときに追記する

public class TimeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject timeUpCanvas;
    public Text leftTimeText;
    float leftTime = 60;
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))return;

        //1秒に1秒ずつ減らしていく
        leftTime -= Time.deltaTime;
        //マイナスは表示しない
        if (leftTime < 0) leftTime = 0;
        leftTimeText.text = "残り時間：" + ((int)leftTime).ToString();

        if (leftTime == 0)
        {
            timeUpCanvas.SetActive(true);
            Debug.Log("GameOver");
        }
    }
}