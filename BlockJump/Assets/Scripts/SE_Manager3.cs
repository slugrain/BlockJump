using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_Manager3 : MonoBehaviour
{
    public static SE_Manager3 Instance { get => _instance; }

    static SE_Manager3 _instance;

    public AudioClip[] Audio_Clip_SE;

    public AudioSource Audio_Source_SE;

    // private bool isWalking = false;


    private void Start()
    {
        _instance = this;
    }

    public void Play(int clip)
    {
        Audio_Source_SE.volume = 0.2f;
        Audio_Source_SE.clip = Audio_Clip_SE[clip];
        Audio_Source_SE.Play();
    }

    public void Stop()
    {
        //  StartCoroutine(FadeVolume());
    }
    /*
        private IEnumerator FadeVolume()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.01f);
                Audio_Source_SE.volume -= 0.01f;
                if (Audio_Source_SE.volume <= 0)
                    break;
            }
            Audio_Source_SE.Stop();
        }
    */
    private void Update()
    {    
       
      
    }
}

