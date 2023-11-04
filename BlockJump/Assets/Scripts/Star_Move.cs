using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Move : MonoBehaviour
{
    // インスペクターから参照
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
    /// <summary>
    /// スターの制御
    /// </summary>
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
    /// <summary>
    /// 星が取得されたら
    /// </summary>
    public void StarGet()
    {
        manager.Play(12);
        targetPosition = new Vector3(-35, 20, 10);
        acceleration =true;
        Invoke("DelayStar", 2f);
    }
    //遅延用の関数
    public void DelayStar()
    {
        get = true;
    }
    // 星を消す
    public void DelayStarDestry()
    {
        star.SetActive(false);
    }
    // Key_Wallに衝突した際の処理
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Key_Wall"))//　衝突した際のタグが"Key_Wall"だった時の判定
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
