using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fade_Out : MonoBehaviour
{
    public GameObject Panelfade;   // フェードパネルの取得

    Image fadealpha;               // 透明度の制御用

    private float alpha;           // アルファ値の変数
    
    private string sceneName;      // 移行したいシーンの名前

    public bool toStageFadeOut;          // シーン遷移を他スクリプトから使うためのbool型変数
    public bool toTitleFadeOut;
    public bool toTutorialFadeOut;
    public bool toGameOverFadeOut;
    public bool toClearFadeOut;

    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>();
        alpha = fadealpha.color.a;
        toStageFadeOut = false;
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
            sceneName = "Tutorial_Stage";
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
    
    /// <summary>
    /// フェードアウトの処理。変数sceneNameに遷移先のシーンの名前を代入する。
    /// </summary>
    public void FadeOut()
    {
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            toClearFadeOut = false;
            SceneManager.LoadScene(sceneName);
        }
    }

    //  ここから各フェードのbool処理
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
