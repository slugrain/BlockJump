using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Floor2 : MonoBehaviour
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
            rb.AddForce(0, 50f, 0f);
            Invoke("MaxUp", 2f);
        }
        else
        {
            rb.AddForce(0, -2, 0f);
            Invoke("MaxDown",4f);
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
