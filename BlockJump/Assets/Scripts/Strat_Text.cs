using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Strat_Text : MonoBehaviour
{
    public SE_Manager2 manager;
    public Text textUI;
    public GameObject canvas_Obj;
    void Start()
    {
        Invoke("Ready_Go", 3f);
    }

    public void Ready_Go()
    {
        manager.Play(0);
        textUI.text = "GO!!";
        Invoke("Destroy", 2f);
    }
    public void Destroy()
    {
        canvas_Obj.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
