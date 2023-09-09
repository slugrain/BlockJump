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
    private string sceneName;

    public bool toStageFadeOut;          //フェードアウトのフラグ変数
    public bool toTitleFadeOut;
    public bool toTutorialFadeOut;
    public bool toGameOverFadeOut;
    public bool toClearFadeOut;

    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;                 //パネルのalpha値を取得
        toStageFadeOut = false;                             //シーン読み込み時にフェードインさせる
        toTitleFadeOut = false;
        toTutorialFadeOut = false;
        toGameOverFadeOut = false;
        toClearFadeOut = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (toStageFadeOut == true)
        {
            sceneName = "Stage2";
            FadeOut();
        }
        if (toTitleFadeOut == true)
        {
            sceneName = "Title";
            FadeOut();
        } 
        if (toTutorialFadeOut == true)
        {
            sceneName = "Tutorial";
            FadeOut();
        }
        if(toGameOverFadeOut == true)
        {
            sceneName = "GameOver"; 
            FadeOut();
        }
        if(toClearFadeOut == true)
        {
            sceneName = "Clear";
            FadeOut();
        }
    }
    
    public void FadeOut()
    {

        alpha += 0.1f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            toClearFadeOut = false;
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ToTitleFadeTrue()
    {
        toTitleFadeOut = true;
    }
    public void ToStageFadeTrue()
    {
        toStageFadeOut = true;
    }
    public void ToTutorialFadeTrue()
    {
        toTutorialFadeOut = true;
    }
    public void ToGameOverFadeTrue()
    {
        toGameOverFadeOut = true;
    }
    public void ToClearFadeTrue()
    {
        toClearFadeOut = true;
    }
}
