using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White_Wall : MonoBehaviour
{
    private Rigidbody rb;
    public SE_Manager manager;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))//@Õ“Ë‚µ‚½Û‚Ìƒ^ƒO‚ª"Star"‚¾‚Á‚½‚Ì”»’è
        {
            rb.AddForce(0, 0f, -400f);
            manager.Play(10);
            Debug.Log("Wall_Destry");
        }
    }
}
