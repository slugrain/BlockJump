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
    [SerializeField]
    private SphereCollider sphereCollider;
    [SerializeField]
    private MeshRenderer meshRenderer;

    public Goal_Camera goal_Camera;
    Fade_Out fadeOut;

    public Text textUI;

    public GameObject canvasObj;
    public GameObject goalObj;
    Vector3 targetPosition;
    public Star_Move star_move;
    public Dash_Icon dash_icon;
    public float upjumpPower;
    public float diagonaljumpPower;
    public bool isGoal = false;
    public bool isDead = false;
    public bool isDashCoolDown = true;
    public SE_Manager sE_Manager;
    public BGM_Manager bGM_Manager;

    //1002追加分
    private Vector3 moveForce = Vector3.zero;
    private int moveForceX;
    private int moveForceY;

    void Start()
    {
        //  開始時にBGMを流し始める処理
        bGM_Manager.Play(0);
        Invoke("StartVoice", 5f);

        rb = GetComponent<Rigidbody>();
        fadeOut = fade.GetComponent<Fade_Out>();
        targetPosition = new Vector3(1000, 3.1f, -18);
        sphereCollider.GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();

        Physics.autoSimulation = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    void Update()
    {
        //  死亡時は操作を受け付けない
        if(isDead)return;
        //  常に回転するように
        transform.Rotate(0, 0, -720 * Time.deltaTime);

        //  ダッシュがクールタイム中なら使えない
        if (isDashCoolDown == true) 
        {
            if (Input.GetMouseButtonDown(1))        // 左クリックをし始めたらエフェクト再生
            {
                spark.Play();
            }

            if (Input.GetMouseButton(1))        // 押し続けている時に高速回転し続ける
            {
                transform.Rotate(0, 0, -360 * Time.deltaTime);
            }

            if (Input.GetMouseButtonUp(1))      // クリックを離したら
            {
                //  右に吹っ飛ばす
                rb.AddForce(new Vector3(70, 0, 0), ForceMode.VelocityChange);
                //  エフェクトを止める
                spark.Stop();
                //  SEを再生する
                sE_Manager.Play(1);

                dash_icon.CTuse();
            }
        }

        //  ゴールしたら動きを止めて、3秒後にアニメーションを再生
        if (isGoal == true)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.Rotate(0, 0, -720 * Time.deltaTime);
            Invoke("GoalAnim", 3f);
        }
    }

    
    void FixedUpdate()
    {
        //  死亡していたら操作を受け付けない
        if (isDead) return;

        if (Input.GetMouseButton(0))// クリックで浮上
        {
            moveForceY = 30;
            MoveForce();

            moveForceY = 0;
        }

        if (Input.GetKey(KeyCode.D))// 右に移動
        {
            moveForceX = 7;
            MoveForce();

            moveForceX = 0;
        }
        
        if (Input.GetKey(KeyCode.A))// 左に移動
        {
            moveForceX = -7;
            MoveForce();

            moveForceX = 0;
        }
    }
    void OnCollisionEnter(Collision collision)// 物体に触れたとき
    {
        //　衝突した際の壁が"Bule_Wall"タグだった時の判定
        if (collision.gameObject.CompareTag("Bule_Wall_Side"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁の側面に当たった");

        }

        if (collision.gameObject.CompareTag("Bule_Wall_Under") ||
            collision.gameObject.CompareTag("Bule_Wall_Top"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionY
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁の下面に当たった");
        }

        if (collision.gameObject.CompareTag("Red_Wall"))// 衝突した際の壁が"Red_Wall"タグだった時の判定
        {
            explosion.Play();
            Invoke("Destroy", 0.1f);
            isDead = true;
            Physics.autoSimulation = false;
        }

        if (collision.gameObject.CompareTag("Key_Wall"))// 星で破壊できる壁にめり込んで無理やり進めないようにする
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ;
        }

        if (collision.gameObject.CompareTag("Jamp_Pad"))// ゴールに触れたとき
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
          | RigidbodyConstraints.FreezeRotationY;
            isGoal = true;
            Invoke("GoalFade", 6f);
            goalspark.Play();
            goal_Camera.GoalCamera();
            //  UIを消して、Goalテキストを出す
            canvasObj.SetActive(false);     
            goalObj.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Star"))// 星に触れたとき
        {
            star_move.StarGet();
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
        | RigidbodyConstraints.FreezeRotationX
        | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void OnCollisionExit(Collision collision)// 青壁から離れる時の処理
    {
        if (collision.gameObject.CompareTag("Bule_Wall_Side") ||
            collision.gameObject.CompareTag("Bule_Wall_Under") ||
            collision.gameObject.CompareTag("Bule_Wall_Top"))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
        }
    }

    //  ボイス再生制御
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Voice"))
        {
            sE_Manager.Play(3);
            textUI.text = "壁を伝って下っていきましょう。";
        }
        if (other.CompareTag("Voice2"))
        {
            sE_Manager.Play(4);
            textUI.text = "天井を伝ってすばやく移動！";
        }
        if (other.CompareTag("Voice_Goal"))
        {
            sE_Manager.Play(6);
            textUI.text = "ゴーーール!";
        }
        if (other.CompareTag("Voice_Star"))
        {
            sE_Manager.Play(8);
            textUI.text = "壁があるね…星が怪しい感じ…？";
        }
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
        meshRenderer.enabled = false;
        isDead = true;
        sE_Manager.Play(5);      
    }
    public void StartVoice()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionZ
        | RigidbodyConstraints.FreezeRotationX
        | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationZ;
        sE_Manager.Play(7);
    }
    public void GoalAnim()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionZ
       | RigidbodyConstraints.FreezePositionY
       | RigidbodyConstraints.FreezeRotationY;
        transform.position =
          Vector3.MoveTowards(transform.position, targetPosition, 0.2f);
    }
    public void GoalFade()
    {
        fadeOut.toClearFadeOut = true;
    }

    /// <summary>
    /// プレイヤーを移動させるためのAddForce操作
    /// </summary>
    void MoveForce()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 force = new Vector3(moveForceX, moveForceY, 0);
        rb.AddForce(force);
    }
}
