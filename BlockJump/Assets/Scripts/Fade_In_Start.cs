using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fade_In_Start : MonoBehaviour
{
    public GameObject Panelfade;   //�t�F�[�h�p�l���̎擾

    Image fadealpha;               //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�

    private float alpha;             //�p�l����alpha�l�擾�ϐ�

    private bool fadein = false;          //�t�F�[�h�C���̃t���O�p�ϐ�

    
    // Use this for initialization
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;               //�p�l����alpha�l���擾
        Invoke("FadeTrue", 3f);                        //�V�[���ǂݍ��ݎ��Ƀt�F�[�h�C��������
    }

    // Update is called once per frame
    void Update()
    {
        if (fadein == true)
        {
            FadeIn();
        }
    }

    public void FadeIn()
    {
        alpha -= 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha <= 0)
        {
            fadein = false;
            Panelfade.SetActive(false);
            Debug.Log("fade");
        }
    }
    public void FadeTrue()
    {
        fadein = true;
    }
}
