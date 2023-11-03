using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Move : MonoBehaviour
{
    Vector3 targetPosition;
    private bool get = false;
    private bool acceleration = false;
    private bool move = false;
    Rigidbody rb;
    public ParticleSystem ep;
    public GameObject star;
    public SE_Manager manager;

    private void Start()
    {
        ep.Stop();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    void Update()
    {
        
        if (get == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f);
        }
        if (acceleration == true)
        {
            transform.Rotate(0, 0, -720 * Time.deltaTime);
        }
        if (move == false)
        {
            transform.Rotate(0, 0, -360 * Time.deltaTime);
        }
    }

    public void StarGet()
    {
        manager.Play(12);
        targetPosition = new Vector3(-35, 20, 10);
        acceleration =true;
        Invoke("DelayStar", 2f);
    }
    public void DelayStar()
    {
        get = true;
    }
    public void DelayStarDestry()
    {
        star.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key_Wall"))//Å@è’ìÀÇµÇΩç€ÇÃÉ^ÉOÇ™"Star"ÇæÇ¡ÇΩéûÇÃîªíË
        {
            var renderer = gameObject.GetComponent<Renderer>();
            renderer.enabled = false;
            var collider = gameObject.GetComponent<Collider>();
            renderer.enabled = false;
            move = true;
            acceleration = false;
            ep.Play();
            rb.constraints = RigidbodyConstraints.FreezeAll;
            Invoke("DelayStarDestry", 2f);
            manager.Play(5);
            Debug.Log("Key_Wall_Destry");
        }
    }

}
