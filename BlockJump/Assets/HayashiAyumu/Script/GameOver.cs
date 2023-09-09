using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //[SerializeField]
    //private GameObject FadeCanvas;
    private Fade_Out FadeOut;
    void Start()
    {
     //   FadeCanvas = GetComponent<GameObject>();
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
