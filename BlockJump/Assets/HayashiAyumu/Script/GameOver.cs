using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //[SerializeField]
    //private GameObject FadeCanvas;
    private Fade_Out FadeOut;
    public BGM_Manager bGM_Manager;
    void Start()
    {
        bGM_Manager.Play(0);
        FadeOut = GetComponent<Fade_Out>();
    }


    public void OnRetryClick()
    {
        FadeOut.Stage2FadeTrue();
    }

    public void OnTitleClick()
    {
        FadeOut.gameoverFadeOut = true;
    }
}
