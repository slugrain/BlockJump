using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clesr_Move : MonoBehaviour
{
    //�C���X�y�N�^�[����Q��
    public BGM_Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        //SE�Đ�
        manager.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[����]������
        transform.Rotate(0, 0, -720 * Time.deltaTime);
    }
}
