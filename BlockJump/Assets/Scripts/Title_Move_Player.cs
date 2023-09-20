using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Move_Player : MonoBehaviour
{
    private bool up;
    private bool down;
    Rigidbody rb;
    public SE_Manager sE_Manager;
    public BGM_Manager bGM_Manager;
    public Fade_Out fade_Out;
   
    void Start()
    {
        bGM_Manager.Play(1);
        up = false;
        down = false;    
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        transform.Rotate(0, 0, -720 * Time.deltaTime);
        
        if (up == true)
        {
            
            Vector3 force = new Vector3(0, 30, 0);    // óÕÇê›íË
            rb.AddForce(force);  // óÕÇâ¡Ç¶ÇÈ
        }
    }

    public void UpMax()
    {
        up = true;
        sE_Manager.Play(1);
        
    }

    public void DownMax()
    {
        sE_Manager.Play(0);
        Invoke("UpMax", 1.5f);
        Invoke("Fade", 4f);
        Debug.Log("a");
    }
    public void Fade()
    {
        fade_Out.TitleFadeTrue();
    }
}
