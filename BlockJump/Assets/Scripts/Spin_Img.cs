using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_Img : MonoBehaviour
{
    // �摜����]������
    void Update()
    {
        transform.Rotate(0, 0, -60 * Time.deltaTime);
    }
}
