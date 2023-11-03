using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class White_Wall : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照
    /// </summary>
    private Rigidbody rb;
    public SE_Manager manager;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //　星に当たったら壁を破壊する処理
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))//　衝突した際のタグが"Star"だった時の判定
        {
            rb.AddForce(0, 0f, -400f);
            manager.Play(10);
            Debug.Log("Wall_Destry");
        }
    }
}
