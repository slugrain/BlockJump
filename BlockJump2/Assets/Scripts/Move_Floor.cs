using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Floor : MonoBehaviour
{
    private Rigidbody rb;
    private bool upMax;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upMax = true;
    }

    
    void Update()
    {
        
    }

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

    void MaxUp()
    {
        upMax = false;
    }
    void MaxDown()
    {
        upMax = true;
    }
}
