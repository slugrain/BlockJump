using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Wall_Destry : MonoBehaviour
{
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Star"))//�@�Փ˂����ۂ̃^�O��"Star"���������̔���
        {
            wall.SetActive(false);
            Debug.Log("Key_Wall_Destry");
        }
    }
}
