using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Strat_Text : MonoBehaviour
{
    /// <summary>
    /// �C���X�y�N�^�[����Q��
    /// </summary>
    public SE_Manager2 manager;
    public Text textUI;
    public GameObject canvas_Obj;
    void Start()
    {
        // �֐���x�����Ďg�p
        Invoke("Ready_Go", 3f);
    }
    /// <summary>
    /// �X�^�[�g��UI�\��
    /// </summary>
    public void Ready_Go()
    {
        manager.Play(0);
        textUI.text = "GO!!";
        Invoke("Destroy", 2f);
    }
    // �I�u�W�F�N�g�̔j��
    public void Destroy()
    {
        canvas_Obj.SetActive(false);
    }
}
