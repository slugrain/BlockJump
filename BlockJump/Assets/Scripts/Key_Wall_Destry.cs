using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Wall_Destry : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照
    /// </summary>
    public GameObject wall;

    // 星にぶつかったら自らを破壊する
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Star"))//　衝突した際のタグが"Star"だった時の判定
        {
            wall.SetActive(false);
            Debug.Log("Key_Wall_Destry");
        }
    }
}
