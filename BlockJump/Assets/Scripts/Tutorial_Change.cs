using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Change : MonoBehaviour
{
    /// <summary>
    /// �C���X�y�N�^�[����Q��
    /// </summary>
    public Fade_Out fade_out;
    public SE_Manager manager;
    // Start is called before the first frame update

    //�֐��������^�C�~���O�𒲐�
    void Start()
    {
        Invoke("Fade_Change", 8f);
        Invoke("Start_Voice", 1.5f);
        Invoke("Start_Voice2", 5f);
        
    }

    //Fade_Change�̊֐����g�p
    public void Fade_Change()
    {
        fade_out.ToStageFadeTrue();
    }
    // �{�C�X�𗬂�
    public void Start_Voice()
    {
        manager.Play(0);
    }
    // �{�C�X�𗬂�
    public void Start_Voice2()
    {
        manager.Play(1);
    }

}
