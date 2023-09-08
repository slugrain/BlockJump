using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI�@�\�������Ƃ��ɒǋL����

public class TimeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject timeUpCanvas;
    public Text leftTimeText;
    float leftTime = 60;
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))return;

        //1�b��1�b�����炵�Ă���
        leftTime -= Time.deltaTime;
        //�}�C�i�X�͕\�����Ȃ�
        if (leftTime < 0) leftTime = 0;
        leftTimeText.text = "�c�莞�ԁF" + ((int)leftTime).ToString();

        if (leftTime == 0)
        {
            timeUpCanvas.SetActive(true);
            Debug.Log("GameOver");
        }
    }
}