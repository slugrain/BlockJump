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

    //float volume;

    private void Start()
    {
        _instance = this;
        //�����ŗ�������
        Play(0);

    }
    public void Play(int clip)
    {
        Audio_Source_BGM.volume = Audio_Clip_BGM_Vol[clip];
        Audio_Source_BGM.clip = Audio_Clip_BGM[clip];
        Audio_Source_BGM.Play();

    }

    public void Stop()
    {

        StartCoroutine(fadeVolue());



    }
    private IEnumerator fadeVolue()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            Audio_Source_BGM.volume -= 0.01f;
            if (Audio_Source_BGM.volume <= 0)
                break;

        }
        Audio_Source_BGM.Stop();
    }
    private void Update()
    {

        //�����~�߂鏈���i�K�v�Ȃ�j
        if (Input.GetKeyUp(KeyCode.X))
        {
            Stop();
        }

    }
}
