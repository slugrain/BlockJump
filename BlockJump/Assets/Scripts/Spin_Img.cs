using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_Img : MonoBehaviour
{
    // 画像を回転させる
    void Update()
    {
        transform.Rotate(0, 0, -60 * Time.deltaTime);
    }
}
