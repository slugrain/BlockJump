using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Manager3 : MonoBehaviour
{
    public static SE_Manager3 Instance { get => _instance; } //インスタンスを定義

    static SE_Manager3 _instance; //インスタンスを定義

    public AudioClip[] Audio_Clip_SE; //AudioClipを定義

    public AudioSource Audio_Source_SE; //AudioClipを定義

    private void Start()
    {
        _instance = this; //インスタンスを代入
    }

    public void Play(int clip) //効果音を再生
    {
        Audio_Source_SE.volume = 1;
        Audio_Source_SE.clip = Audio_Clip_SE[clip];
        Audio_Source_SE.Play();
    }
}

