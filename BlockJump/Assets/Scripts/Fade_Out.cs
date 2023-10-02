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
    private string sceneName;

    public bool toStageFadeOut;          //�t�F�[�h�A�E�g�̃t���O�ϐ�
    public bool toTitleFadeOut;
    public bool toTutorialFadeOut;
    public bool toGameOverFadeOut;
    public bool toClearFadeOut;

    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;                 //�p�l����alpha�l���擾
        toStageFadeOut = false;                             //�V�[���ǂݍ��ݎ��Ƀt�F�[�h�C��������
        toTitleFadeOut = false;
        toTutorialFadeOut = false;
        toGameOverFadeOut = false;
        toClearFadeOut = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (toStageFadeOut == true)
        {
            sceneName = "Stage2";
            FadeOut();
        }
        if (toTitleFadeOut == true)
        {
            sceneName = "Title";
            FadeOut();
        } 
        if (toTutorialFadeOut == true)
        {
            sceneName = "Tutorial_Stage";
            FadeOut();
        }
        if(toGameOverFadeOut == true)
        {
            sceneName = "GameOver"; 
            FadeOut();
        }
        if(toClearFadeOut == true)
        {
            sceneName = "Clear";
            FadeOut();
        }
    }
    
    public void FadeOut()
    {

        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            toClearFadeOut = false;
            SceneManager.LoadScene(sceneName);
        }
    }

    public void ToTitleFadeTrue()
    {
        toTitleFadeOut = true;
    }
    public void ToStageFadeTrue()
    {
        toStageFadeOut = true;
    }
    public void ToTutorialFadeTrue()
    {
        toTutorialFadeOut = true;
    }
    public void ToGameOverFadeTrue()
    {
        toGameOverFadeOut = true;
    }
    public void ToClearFadeTrue()
    {
        toClearFadeOut = true;
    }
}
