using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White_Wall : MonoBehaviour
{
    /// <summary>
    /// �C���X�y�N�^�[����Q��
    /// </summary>
    private Rigidbody rb;
    public SE_Manager manager;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //�@���ɓ���������ǂ�j�󂷂鏈��
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))//�@�Փ˂����ۂ̃^�O��"Star"���������̔���
        {
            rb.AddForce(0, 0f, -400f);
            manager.Play(10);
            Debug.Log("Wall_Destry");
        }
    }
}
