using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Wall_Destry : MonoBehaviour
{
    /// <summary>
    /// �C���X�y�N�^�[����Q��
    /// </summary>
    public GameObject wall;

    // ���ɂԂ������玩���j�󂷂�
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Star"))//�@�Փ˂����ۂ̃^�O��"Star"���������̔���
        {
            wall.SetActive(false);
            Debug.Log("Key_Wall_Destry");
        }
    }
}
