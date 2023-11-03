using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Floor3 : MonoBehaviour
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
        //transform.Rotate(0, 0, 50f * Time.deltaTime);
    }

    
    void FixedUpdate()
    {
        if (upMax == true)
        {
            rb.AddForce(0, 5f, 0f);
            Invoke("MaxUp", 2f);
        }
        else
        {
            rb.AddForce(0, -5, 0f);
            Invoke("MaxDown",4f);
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
