using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade_In_Start : MonoBehaviour
{
    public GameObject Panelfade;   //フェードパネルの取得

    Image fadealpha;               //フェードパネルのイメージ取得変数

    private float alpha;             //パネルのalpha値取得変数

    private bool fadein = false;          //フェードインのフラグ用変数

    
    // Use this for initialization
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;               //パネルのalpha値を取得
        Invoke("FadeTrue", 3f);                        //シーン読み込み時にフェードインさせる
    }

    // Update is called once per frame
    void Update()
    {
        if (fadein == true)
        {
            FadeIn();
        }
    }

    public void FadeIn()
    {
        alpha -= 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha <= 0)
        {
            fadein = false;
            Panelfade.SetActive(false);
            Debug.Log("fade");
        }
    }
    public void FadeTrue()
    {
        fadein = true;
    }
}
