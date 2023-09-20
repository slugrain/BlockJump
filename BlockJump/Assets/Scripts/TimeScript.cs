using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�@�\�������Ƃ��ɒǋL����

public class TimeScript : MonoBehaviour
{
    public Fade_Out fade_Out;
    [SerializeField]
    private GameObject timeUpCanvas;
    public Text leftTimeText;
    float leftTime = 94;
    public SE_Manager2 sE_Manager2;
    private bool se = true;
    void Update()
    {
        //1�b��1�b�����炵�Ă���
        leftTime -= Time.deltaTime;
        //�}�C�i�X�͕\�����Ȃ�
        if (leftTime < 0) leftTime = 0;
        leftTimeText.text = "�c�莞�ԁF" + ((int)leftTime).ToString();

        if (leftTime == 0 && se == true)
        {
            timeUpCanvas.SetActive(true);
            Invoke("GameOver", 3f);
            se = false;
            sE_Manager2.Play(1);
            Debug.Log("GameOver");           
        }
    }

    public void GameOver()
    {
        fade_Out.GameOverFadeTrue();
    }
}