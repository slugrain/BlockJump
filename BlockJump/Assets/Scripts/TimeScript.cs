using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI機能を扱うときに追記する

public class TimeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject timeUpCanvas;

    private GameObject fadePanel;
    private Fade_Out fadeOut;
    private GameObject player;
    private PlayerMove playerMove;

    public Text leftTimeText;
    float leftTime = 10;

    void Start()
    {
        fadePanel = GameObject.Find("Fade_Canvas");
        fadeOut = fadePanel.GetComponent<Fade_Out>();

        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }

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
            //  0908変更点
            playerMove.isDead = true;
            Invoke(nameof(hoge), 3.0f);
        }
    }

    private void hoge()
    {
        fadeOut.ToGameOverFadeTrue();
    }
}