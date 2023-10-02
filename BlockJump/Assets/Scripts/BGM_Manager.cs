using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Manager : MonoBehaviour
{
    public static BGM_Manager Instance { get => _instance; }

    static BGM_Manager _instance;

    public AudioClip[] Audio_Clip_BGM;

    public float[] Audio_Clip_BGM_Vol;

    public AudioSource Audio_Source_BGM;

    private void Start()
    {
        _instance = this;
    }
    public void Play(int clip)
    {
        Audio_Source_BGM.volume = Audio_Clip_BGM_Vol[clip];
        Audio_Source_BGM.clip = Audio_Clip_BGM[clip];
        Audio_Source_BGM.Play();
    }
}
