using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour
{
    [SerializeField]
    Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text.text = "ó]Ç¡ÇΩéûä‘ÅF" + ((int)TimeScript.leftTime).ToString() + "second!!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
