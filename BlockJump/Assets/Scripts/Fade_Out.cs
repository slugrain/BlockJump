using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fade_Out : MonoBehaviour
{
    public GameObject Panelfade;   //�t�F�[�h�p�l���̎擾

    Image fadealpha;               //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�

    private float alpha;           //�p�l����alpha�l�擾�ϐ�

    private bool titlefadeout;          //�t�F�[�h�A�E�g�̃t���O�ϐ�

    private bool stagefadeout;


    // Use this for initialization
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;                 //�p�l����alpha�l���擾
        titlefadeout = false;                             //�V�[���ǂݍ��ݎ��Ƀt�F�[�h�C��������
        stagefadeout = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (titlefadeout == true)
        {
            TitleFadeOut();
        }
        if (stagefadeout == true)
        {
            Stage2FadeOut();
        }
    }

    public void TitleFadeOut()
    {
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            titlefadeout = false;
            SceneManager.LoadScene("Stage2");
        }
    }
    public void Stage2FadeOut()
    {
        Debug.Log("RunTest");
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            stagefadeout = false;
            SceneManager.LoadScene("Title");
            Debug.Log("test");
        }
    }
    public void TitleFadeTrue()
    {
        titlefadeout = true;
    }
    public void Stage2FadeTrue()
    {
        stagefadeout = true;
    }
}
