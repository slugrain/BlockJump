using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Change : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照
    /// </summary>
    public Fade_Out fade_out;
    public SE_Manager manager;
    // Start is called before the first frame update

    //関数が動くタイミングを調整
    void Start()
    {
        Invoke("Fade_Change", 8f);
        Invoke("Start_Voice", 1.5f);
        Invoke("Start_Voice2", 5f);
        
    }

    //Fade_Changeの関数を使用
    public void Fade_Change()
    {
        fade_out.ToStageFadeTrue();
    }
    // ボイスを流す
    public void Start_Voice()
    {
        manager.Play(0);
    }
    // ボイスを流す
    public void Start_Voice2()
    {
        manager.Play(1);
    }

}
