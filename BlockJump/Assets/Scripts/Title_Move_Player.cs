using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Move_Player : MonoBehaviour
{
    /// <summary>
    /// �C���X�y�N�^�[����Q��
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
        //�v���C���[����]
        transform.Rotate(0, 0, -720 * Time.deltaTime);
        
        if (up == true)
        {
            //������Ɉړ�
            Vector3 force = new Vector3(0, 30, 0);    // �͂�ݒ�
            rb.AddForce(force);  // �͂�������
        }
    }
    //�x������
    public void UpMax()
    {
        up = true;
        sE_Manager.Play(1);
        
    }
    //�x������
    public void DownMax()
    {
        sE_Manager.Play(0);
        Invoke("UpMax", 1.5f);
        Invoke("Fade", 4f);
        Debug.Log("a");
    }
    //�t�F�[�h��������
    public void Fade()
    {
        fade_Out.ToTutorialFadeTrue();
    }
}
