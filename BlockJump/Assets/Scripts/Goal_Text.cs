using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Text : MonoBehaviour
{
    private bool goal = false; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goal == false)
        {
            transform.Rotate(0, 1, 0 * Time.deltaTime);
        }
        if (goal == true)
        {
            transform.Rotate(720, 720, -720 * Time.deltaTime);
        }
    }
}
