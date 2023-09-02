using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    //float speed = 1f;
    [SerializeField] 
    private ParticleSystem spark;
    [SerializeField]
    private ParticleSystem explosion;
    public GameObject player;
    public float upjumpPower;
    public float diagonaljumpPower;
    private bool isJumping = false;
    private bool diagonalJamp = false;
    private float xPos;

    public bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        transform.Rotate(0, 0, -720 * Time.deltaTime);

        if (Input.GetMouseButtonUp(1))// Wキー（前方移動）
        {
            rb.AddForce(new Vector3(60, 0, 0), ForceMode.VelocityChange);
            spark.Stop();
            Debug.Log("Dash");
        }

        if (Input.GetMouseButton(1))// Wキー（前方移動）
        {
            transform.Rotate(0, 0, -360 * Time.deltaTime);
            //spark.Play();
            //Debug.Log("SpinUp");
        }

        if (Input.GetMouseButtonDown(1))// Wキー（前方移動）
        {
            transform.Rotate(0, 0, -360 * Time.deltaTime);
            spark.Play();
            Debug.Log("SpinUp");
        }
    }

    
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))// Wキー（前方移動）
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector3 force = new Vector3(0, 30, 0);    // 力を設定
            rb.AddForce(force);  // 力を加える
        }

        if (Input.GetKey(KeyCode.D))// Wキー（前方移動）
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector3 force = new Vector3(7, 0, 0);    // 力を設定
            rb.AddForce(force);  // 力を加える
        }
        
        if (Input.GetKey(KeyCode.A))// Aキー（左移動
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
            Vector3 force = new Vector3(-7, 0, 0);    // 力を設定
            rb.AddForce(force);  // 力を加える
        }
        if (Input.GetKeyDown(KeyCode.Space))// Wキー（前方移動）
        {
            //FreezePositionXYZ全てをオンにする
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationYをオンにする
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁から離れた");
        }

    }
    void OnCollisionEnter(Collision collision)// 青の壁に衝突した際の判定を取る
    {
        if (collision.gameObject.CompareTag("Bule_Wall_Side"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁の側面に当たった");
          
        }

        if (collision.gameObject.CompareTag("Bule_Wall_Top"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionY
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁の上面に当たった");
        }

        if (collision.gameObject.CompareTag("Bule_Wall_Under"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionY
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁の下面に当たった");
        }

        if (collision.gameObject.CompareTag("Red_Wall_Side"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            explosion.Play();
            Invoke("Destroy", 1f);
            Debug.Log("青の壁の側面に当たった");

        }

        if (collision.gameObject.CompareTag("Red_Wall_Top"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            explosion.Play();
            Invoke("Destroy", 0.5f);

            Debug.Log("青の壁の上面に当たった");
        }

        if (collision.gameObject.CompareTag("Red_Wall_Under"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            explosion.Play();
            Invoke("Destroy", 1f);
            Debug.Log("青の壁の下面に当たった");
        }

        if (collision.gameObject.CompareTag("Jamp_Pad"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
          | RigidbodyConstraints.FreezePositionY
          | RigidbodyConstraints.FreezeRotationY;
            rb.AddForce(new Vector3(60, 0, 0), ForceMode.VelocityChange);
            Debug.Log("ジャンプパッド！");
        }

        if (collision.gameObject.CompareTag("Walp_Point"))
        {
            
            Debug.Log("yuka");
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            //FreezePositionXYZ全てをオンにする
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationYをオンにする
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("yuka");
        }
    }

    void OnCollisionExit(Collision collision)// 青の壁から離れた際の判定を取る
    {
        if (collision.gameObject.CompareTag("Bule_Wall_Side"))//　離れた壁が"Bule_Wall"タグだった時の判定
        {
            //FreezePositionXYZ全てをオンにする
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationYをオンにする
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁から離れた");
        }
        if (collision.gameObject.CompareTag("Bule_Wall_Top"))//　離れた壁が"Bule_Wall"タグだった時の判定
        {
            //FreezePositionXYZ全てをオンにする
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationYをオンにする
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁から離れた");
        }
        if (collision.gameObject.CompareTag("Bule_Wall_Under"))//　離れた壁が"Bule_Wall"タグだった時の判定
        {
            //FreezePositionXYZ全てをオンにする
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationYをオンにする
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁から離れた");
        }

    }

    public void Destroy()
    {
        //player.SetActive(false);
        isDead = true;
    }
}
