using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //[SerializeField]
    //private GameObject FadeCanvas;
    private Fade_Out FadeOut;
    public BGM_Manager BGM_Manager;
    void Start()
    {
        BGM_Manager.Play(0);
        FadeOut = GetComponent<Fade_Out>();
    }


    public void OnRetryClick()
    {
        FadeOut.ToTitleFadeTrue();
    }

    public void OnTitleClick()
    {
        FadeOut.toGameOverFadeOut = true;
    }
}
