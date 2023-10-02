using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Manager3 : MonoBehaviour
{
    public static SE_Manager3 Instance { get => _instance; } //�C���X�^���X���`

    static SE_Manager3 _instance; //�C���X�^���X���`

    public AudioClip[] Audio_Clip_SE; //AudioClip���`

    public AudioSource Audio_Source_SE; //AudioClip���`

    private void Start()
    {
        _instance = this; //�C���X�^���X����
    }

    public void Play(int clip) //���ʉ����Đ�
    {
        Audio_Source_SE.volume = 1;
        Audio_Source_SE.clip = Audio_Clip_SE[clip];
        Audio_Source_SE.Play();
    }
}

