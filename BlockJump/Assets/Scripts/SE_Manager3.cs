using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Manager3 : MonoBehaviour
{
    /// <summary>
    /// 参照と取得
    /// </summary>
    public static SE_Manager3 Instance { get => _instance; }

    static SE_Manager3 _instance;

    public AudioClip[] Audio_Clip_SE;

    public AudioSource Audio_Source_SE;


    private void Start()
    {
        _instance = this;
    }
    /// <summary>
    /// SEを流す処理
    /// </summary>
    /// <param name="clip"></param>
    public void Play(int clip)
    {
        Audio_Source_SE.volume = 0.2f;
        Audio_Source_SE.clip = Audio_Clip_SE[clip];
        Audio_Source_SE.Play();
    }
}

