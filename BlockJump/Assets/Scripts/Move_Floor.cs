using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Floor : MonoBehaviour
{
    
    private Rigidbody rb;
    private bool upMax;
    //取得と初期化
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upMax = true;
    }
    //床を一定で動かす
    void FixedUpdate()
    {
        if (upMax == true)
        {
            rb.AddForce(0, 5, 0f);
            Invoke("MaxUp", 3f);
        }
        else
        {
            rb.AddForce(0, -2, 0f);
            Invoke("MaxDown", 2f);
        }
        
    }
    /// <summary>
    /// 最大値・最小値
    /// </summary>
    void MaxUp()
    {
        upMax = false;
    }
    void MaxDown()
    {
        upMax = true;
    }
}
