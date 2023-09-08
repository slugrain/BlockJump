using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    Fade_Out fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        if(fadeOut == null)fadeOut = GetComponent<Fade_Out>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fadeOut.ToTitleFadeTrue();
        }
    }
}
