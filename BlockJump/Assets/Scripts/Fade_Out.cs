using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fade_Out : MonoBehaviour
{
    public GameObject Panelfade;
    Image fadealpha;                //   fadePanel の読み込み

    private float alpha;           //   パネルのアルファ値
    private string sceneName;

    public bool toStageFadeOut;    //   シーン遷移先に応じた bool型
    public bool toTitleFadeOut;
    public bool toTutorialFadeOut;
    public bool toGameOverFadeOut;
    public bool toClearFadeOut;

    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); // パネルの取得
        alpha = fadealpha.color.a;                   // パネルのアルファ値の取得

        toStageFadeOut = false;                      // 全条件をオフに
        toTitleFadeOut = false;
        toTutorialFadeOut = false;
        toGameOverFadeOut = false;
        toClearFadeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  各シーンに応じて sceneName を設定
        if (toStageFadeOut == true)
        {
            sceneName = "Stage1";
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
    /// フェードアウトさせる処理
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

    //  シーン遷移先に応じた実行フラグ
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
