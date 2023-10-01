using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�@�\�������Ƃ��ɒǋL����

public class TimeScript : MonoBehaviour
{
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

    void Start()
    {
        leftTime = 90;

        fadePanel = GameObject.Find("Fade_Canvas");
        fadeOut = fadePanel.GetComponent<Fade_Out>();

        player = GameObject.Find("Player");
        playerMove = player.GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (playerMove.isGoal) return;
        if(Input.GetKey(KeyCode.Q))return;
        
        //1�b��1�b�����炵�Ă���
        leftTime -= Time.deltaTime;
        //�}�C�i�X�͕\�����Ȃ�
        if (leftTime < 0) leftTime = 0;
        leftTimeText.text = "�c�莞�ԁF" + ((int)leftTime).ToString();

        if (leftTime == 0 && se == true)
        {
            timeUpCanvas.SetActive(true);
            Debug.Log("GameOver");
            //  0908�ύX�_
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