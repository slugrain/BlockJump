using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Move_Player : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照
    /// </summary>
    private bool up;
    Rigidbody rb;
    public SE_Manager sE_Manager;
    public BGM_Manager bGM_Manager;
    public Fade_Out fade_Out;
   
    void Start()
    {
        bGM_Manager.Play(1);
        up = false;
        // down = false;    
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //プレイヤーを回転
        transform.Rotate(0, 0, -720 * Time.deltaTime);
        
        if (up == true)
        {
            //上方向に移動
            Vector3 force = new Vector3(0, 30, 0);    // 力を設定
            rb.AddForce(force);  // 力を加える
        }
    }
    //遅延処理
    public void UpMax()
    {
        up = true;
        sE_Manager.Play(1);
        
    }
    //遅延処理
    public void DownMax()
    {
        sE_Manager.Play(0);
        Invoke("UpMax", 1.5f);
        Invoke("Fade", 4f);
        Debug.Log("a");
    }
    //フェードをさせる
    public void Fade()
    {
        fade_Out.ToTutorialFadeTrue();
    }
}
