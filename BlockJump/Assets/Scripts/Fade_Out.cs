using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fade_Out : MonoBehaviour
{
    public GameObject Panelfade;   //フェードパネルの取得

    Image fadealpha;               //フェードパネルのイメージ取得変数

    private float alpha;           //パネルのalpha値取得変数

    private bool titlefadeout;          //フェードアウトのフラグ変数

    private bool stagefadeout;


    // Use this for initialization
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;                 //パネルのalpha値を取得
        titlefadeout = false;                             //シーン読み込み時にフェードインさせる
        stagefadeout = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (titlefadeout == true)
        {
            TitleFadeOut();
        }
        if (stagefadeout == true)
        {
            Stage2FadeOut();
        }
    }

    public void TitleFadeOut()
    {
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            titlefadeout = false;
            SceneManager.LoadScene("Stage2");
        }
    }
    public void Stage2FadeOut()
    {
        Debug.Log("RunTest");
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            stagefadeout = false;
            SceneManager.LoadScene("Title");
            Debug.Log("test");
        }
    }
    public void TitleFadeTrue()
    {
        titlefadeout = true;
    }
    public void Stage2FadeTrue()
    {
        stagefadeout = true;
    }
}
