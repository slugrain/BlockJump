using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Change : MonoBehaviour
{
    public Fade_Out fade_out;
    public SE_Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Fade_Change", 8f);
        Invoke("Start_Voice", 1.5f);
        Invoke("Start_Voice2", 5f);
        
    }

    public void Fade_Change()
    {
        fade_out.TutorialFadeTrue();
    }
    public void Start_Voice()
    {
        manager.Play(0);
    }
    public void Start_Voice2()
    {
        manager.Play(1);
    }

}
