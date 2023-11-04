using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TimeScript : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照
    /// </summary>
    public Fade_Out fade_Out;
    [SerializeField]
    private GameObject timeUpCanvas;
    private GameObject fadePanel;
    private Fade_Out fadeOut;
    private GameObject player;
    private PlayerMove playerMove;
    public Text leftTimeText;
    public SE_Manager2 sE_Manager2;
    private bool se = true;
    public static float leftTime;
    /// <summary>
    /// 初期化とコンポーネントの取得
    /// </summary>
    void Start()
    {
        leftTime = 90;

        fadePanel = GameObject.Find("Fade_Canvas");
        fadeOut = fadePanel.GetComponent<Fade_Out>();

        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }
    /// <summary>
    /// 制限時間を実装し、判定をとる。
    /// </summary>
    void Update()
    {
        if (playerMove.isGoal) return;
        if(Input.GetKey(KeyCode.Q))return;
        
  
        leftTime -= Time.deltaTime;
 
        if (leftTime < 0) leftTime = 0;
        leftTimeText.text = "制限時間：" + ((int)leftTime).ToString();

        if (leftTime == 0 && se == true)
        {
            timeUpCanvas.SetActive(true);
            Debug.Log("GameOver");
            playerMove.isDead = true;
            se = false;
            sE_Manager2.Play(1);
            Invoke("GameOver", 3.0f);
        }
    }

    private void GameOver()
    {
        fadeOut.ToGameOverFadeTrue();
    }
}