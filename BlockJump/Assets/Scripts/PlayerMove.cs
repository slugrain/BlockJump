using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    //float speed = 1f;
    [SerializeField] 
    private ParticleSystem spark;
    [SerializeField]
    private ParticleSystem goalspark;
    [SerializeField]
    private ParticleSystem explosion;
    public GameObject player;
    [SerializeField]
    public GameObject fade;

    public Goal_Camera goal_Camera;
    Fade_Out fadeOut;

    public Text textUI;

    public GameObject canvasObj;
    public GameObject goalObj;
    // public GameObject voiceText;
    Vector3 targetPosition;
    public Star_Move star_move;
    public float upjumpPower;
    public float diagonaljumpPower;
    private bool isJumping = false;
    private bool diagonalJamp = false;
    private float xPos;
    public bool goal = false;
    public bool isDead = false;
    public SE_Manager sE_Manager;
    void Start()
    {
        Invoke("StartVoice", 1.5f);
        rb = GetComponent<Rigidbody>();
        fadeOut = fade.GetComponent<Fade_Out>();
        //isJumping = fadeOut.clearFadeOut;
        targetPosition = new Vector3(1000, 3.1f, -18);
    }

    void Update()
    {
        if(isDead)return;

        transform.Rotate(0, 0, -720 * Time.deltaTime);

        if (Input.GetMouseButtonUp(1))// Wキー（前方移動）
        {
            rb.AddForce(new Vector3(60, 0, 0), ForceMode.VelocityChange);
            spark.Stop();
            sE_Manager.Play(1);
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

        if (goal == true)// Wキー（前方移動）
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.Rotate(0, 0, -720 * Time.deltaTime);
            Invoke("GoalAnim", 3f);
          
            Debug.Log("go");
        }
    }

    
    void FixedUpdate()
    {
        if (isDead) return;

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
            isDead = true;
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("青の壁の側面に当たった");

        }

        if (collision.gameObject.CompareTag("Red_Wall_Top"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            isDead = true;
            explosion.Play();
            Invoke("Destroy", 0.1f);

            Debug.Log("青の壁の上面に当たった");
        }

        if (collision.gameObject.CompareTag("Red_Wall_Under"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            isDead = true;
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("青の壁の下面に当たった");
        }

        if (collision.gameObject.CompareTag("Key_Wall"))//　衝突した際の壁が"Key_Wall"タグだった時の判定
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ;
            Debug.Log("通れない！");
        }

        if (collision.gameObject.CompareTag("Jamp_Pad"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
          //| RigidbodyConstraints.FreezePositionY
          | RigidbodyConstraints.FreezeRotationY;
            //isDead = true;
            goal = true;
            Invoke("GoalFade", 6f);
            goalspark.Play();
            goal_Camera.GoalCamera();
            Debug.Log("ジャンプパッド！");
            canvasObj.SetActive(false);     
            goalObj.SetActive(true);
            //voiceText.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Star"))//　衝突した際のタグが"Star"だった時の判定
        {
            star_move.StarGet();
            Debug.Log("Star Get");
        }

        
        if (collision.gameObject.CompareTag("Walp_Point"))
        {
            
            Debug.Log("yuka");
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
        | RigidbodyConstraints.FreezeRotationX
        | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationZ;

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

    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトのタグが"Voice"のとき
        if (other.CompareTag("Voice"))
        {
            sE_Manager.Play(3);
            textUI.text = "壁を伝って下っていきましょう。";
        }
        //接触したオブジェクトのタグが"Voice2"のとき
        if (other.CompareTag("Voice2"))
        {
            sE_Manager.Play(4);
            textUI.text = "天井を伝ってすばやく移動！";
        }
        //接触したオブジェクトのタグが"Voice_Goal"のとき
        if (other.CompareTag("Voice_Goal"))
        {
            sE_Manager.Play(6);
            textUI.text = "ゴーーール!";
        }

        //接触したオブジェクトのタグが"Voice_Star"のとき
        if (other.CompareTag("Voice_Star"))
        {
            sE_Manager.Play(8);
            textUI.text = "壁があるね…星が怪しい感じ…？";
        }
        //接触したオブジェクトのタグが"Voice_Saka"のとき
        if (other.CompareTag("Voice_Saka"))
        {
            sE_Manager.Play(9);
            textUI.text = "坂道だ！スピード注意！";
        }

        if (other.CompareTag("Voice_Kouhann"))
        {
            sE_Manager.Play(2);
            textUI.text = "さあ、ステージも後半戦です、頑張ってください！";
        }
    }
    public void Destroy()
    {
        //player.SetActive(false);
        isDead = true;
        sE_Manager.Play(5);
    }
    public void StartVoice()
    {
        sE_Manager.Play(7);
    }
    public void GoalAnim()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionZ
       | RigidbodyConstraints.FreezePositionY
       | RigidbodyConstraints.FreezeRotationY;
        transform.position =
          Vector3.MoveTowards(transform.position, targetPosition, 0.2f);
        Debug.Log("ゴール演出");
    }
    public void GoalFade()
    {
        fadeOut.clearFadeOut = true;
    }
}
