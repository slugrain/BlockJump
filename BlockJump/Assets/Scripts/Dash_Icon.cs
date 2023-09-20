using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dash_Icon : MonoBehaviour
{
    /// <summary>
    /// �_�b�V���ɃN�[���^�C��������\�[�X�R�[�h
    /// </summary>
    public Image image;// fill�̉摜
    public bool dash_Cool_Time = false;// �N�[���^�C���̔���
    public float countTime = 5.0f;// �N�[���^�C���̎���
    public float cool_Time = 0f;// �N�[���^�C���̃A�C�R�����ɕ\������p�̎���
    public PlayerMove playerMove;// player��bool���Q��
    public Text cool_Time_Text;//�N�[���^�C���̕b���\���p
    /// <summary>
    /// �}�E�X���͂��󂯎������fillAmount���߂�֐�
    /// </summary>
    void Update()
    {
        cool_Time_Text.text = cool_Time.ToString("n1");// �N�[���^�C���̌��݂̕b����\���A("n1")�͏����_���ʂ܂ŕ\���Ƃ����Ӗ�
        if (dash_Cool_Time == true)// �_�b�V�����������̔���
        {
            image.fillAmount += 1.0f / countTime * Time.deltaTime;// ���b1�b���J�E���g���AfillAmount�𑝉�������
            cool_Time -= Time.deltaTime;// 1�b�Ԃɂ�1����cool_Time�����炵�Ă���
            if (cool_Time < 0)
            {
                cool_Time = 0;// �}�C�i�X��\�������Ȃ�
            }
  
            if (image.fillAmount == 1f)// fillAmount��1�ɂȂ邩�̔���
            {
                playerMove.dash = true;// PlayerMove��dash��true�ɂ��čēx�_�b�V���\�ɂ���
                Debug.Log("Cool_Time_Back");
            }
        }
    }
    /// <summary>
    /// �_�b�V������fillAmount��0�ɂ��A�N�[���^�C�����J�n����֐�
    /// </summary>
    public void CTuse()
    {
        cool_Time = 5.0f; // �A�C�R�����̃N�[���^�C���̎��Ԃ�������
        image.fillAmount = 0f;// fill�̏�����
        dash_Cool_Time = true;// �N�[���^�C�����J�n������
        playerMove.dash = false;// �_�b�V������莞�ԋ֎~������
        Debug.Log("public void CTuse");
    }
}
