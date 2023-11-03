using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Floor : MonoBehaviour
{
    
    private Rigidbody rb;
    private bool upMax;
    //æ“¾‚Æ‰Šú‰»
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upMax = true;
    }
    //°‚ğˆê’è‚Å“®‚©‚·
    void FixedUpdate()
    {
        if (upMax == true)
        {
            rb.AddForce(0, 5, 0f);
            Invoke("MaxUp", 3f);
        }
        else
        {
            rb.AddForce(0, -2, 0f);
            Invoke("MaxDown", 2f);
        }
        
    }
    /// <summary>
    /// Å‘å’lEÅ¬’l
    /// </summary>
    void MaxUp()
    {
        upMax = false;
    }
    void MaxDown()
    {
        upMax = true;
    }
}
