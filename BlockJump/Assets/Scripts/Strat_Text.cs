using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Strat_Text : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照
    /// </summary>
    public SE_Manager2 manager;
    public Text textUI;
    public GameObject canvas_Obj;
    void Start()
    {
        // 関数を遅延して使用
        Invoke("Ready_Go", 3f);
    }
    /// <summary>
    /// スタートのUI表示
    /// </summary>
    public void Ready_Go()
    {
        manager.Play(0);
        textUI.text = "GO!!";
        Invoke("Destroy", 2f);
    }
    // オブジェクトの破壊
    public void Destroy()
    {
        canvas_Obj.SetActive(false);
    }
}
