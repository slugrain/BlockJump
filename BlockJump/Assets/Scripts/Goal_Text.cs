using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Text : MonoBehaviour
{
<<<<<<< HEAD
    private bool goal = false; 
=======
>>>>>>> 3ae9e68a9b396a46a9bf6d4a63f5c81f16f238b2
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (goal == false)
        {
            transform.Rotate(0, 1, 0 * Time.deltaTime);
        }
        if (goal == true)
        {
            transform.Rotate(720, 720, -720 * Time.deltaTime);
        }

=======
        transform.Rotate(0, 0, -720 * Time.deltaTime);
>>>>>>> 3ae9e68a9b396a46a9bf6d4a63f5c81f16f238b2
    }


}
