using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Floor : MonoBehaviour
{
    
    private Rigidbody rb;
    private bool upMax;
    //�擾�Ə�����
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upMax = true;
    }
    //�������œ�����
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
    /// �ő�l�E�ŏ��l
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
