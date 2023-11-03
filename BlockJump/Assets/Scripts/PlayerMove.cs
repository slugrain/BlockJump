using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照と初期化
    /// </summary>
    Rigidbody rb;
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
    public bool dash = true;
    public SE_Manager sE_Manager;
    public BGM_Manager bGM_Manager;

    //1002追加分
    private Vector3 moveForce = Vector3.zero;
    private int moveForceX;
    private int moveForceY;

    void Start()
    {
        //BGM再生
        bGM_Manager.Play(0);
        //5fに動く関数
        Invoke("StartVoice", 5f);
        //以下取得と初期化
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
        if(isDead)return;
        // プレイヤーを回転させる
        transform.Rotate(0, 0, -720 * Time.deltaTime);

        if (dash == true) 
        {
            //プレイヤーをダッシュさせる
            if (Input.GetMouseButtonUp(1))
            {
                rb.AddForce(new Vector3(70, 0, 0), ForceMode.VelocityChange);
                spark.Stop();
                sE_Manager.Play(1);
                dash_icon.CTuse();
                Debug.Log("Dash");
            }
            if (Input.GetMouseButton(1))
            {
                transform.Rotate(0, 0, -360 * Time.deltaTime);
            }
            // プレイヤーの回転数を上げ、スパークを再生
            if (Input.GetMouseButtonDown(1))
            {
                transform.Rotate(0, 0, -360 * Time.deltaTime);
                spark.Play();
                Debug.Log("SpinUp");
            }
        }
        // プレイヤーがゴールした際の挙動
        if (isGoal == true)
        {
            //プレイヤーの動きを止める
            rb.constraints = RigidbodyConstraints.FreezeAll;
            //プレイヤーの回転数を加速
            transform.Rotate(0, 0, -720 * Time.deltaTime);
            //3f後に関数を使用する
            Invoke("GoalAnim", 3f);

            Debug.Log("go");
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
        if (collision.gameObject.CompareTag("Bule_Wall_Side"))//　衝突した際の壁が"Bule_Wall_Side"タグだった時の判定
        {
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁の側面に当たった");

        }

        if (collision.gameObject.CompareTag("Bule_Wall_Under") ||
            collision.gameObject.CompareTag("Bule_Wall_Top"))//　衝突した際の壁が "Bule_Wall_Top" 及び "Bule_Wall_Under"タグだった時の判定
        {
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionY
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁の下面に当たった");
        }

        if (collision.gameObject.CompareTag("Red_Wall_Top"))//　衝突した際の壁が"Red_Wall_Top"タグだった時の判定
        {
            // プレイヤーを破壊
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("プレイヤーを破壊");
            isDead = true;
            Physics.autoSimulation = false;
        }

        if (collision.gameObject.CompareTag("Key_Wall"))//　衝突した際の壁が"key_Wall"タグだった時の判定
        {
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ;
            Debug.Log("key_Wallに接触");
        }

        if (collision.gameObject.CompareTag("Jamp_Pad"))//　衝突した際の壁が"Jamp_Pad"タグだった時の判定
        {
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezePositionZ
          //| RigidbodyConstraints.FreezePositionY
          | RigidbodyConstraints.FreezeRotationY;
            //isDead = true;
            isGoal = true;
            Invoke("GoalFade", 6f);
            goalspark.Play();
            goal_Camera.GoalCamera();
            Debug.Log("�W�����v�p�b�h�I");
            canvasObj.SetActive(false);     
            goalObj.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Star"))//　衝突した際の壁が"Star"タグだった時の判定
        {
            star_move.StarGet();
            Debug.Log("Star Get");
        }

        if (collision.gameObject.CompareTag("Floor"))//　衝突した際の壁が"Floor"タグだった時の判定
        {
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezePositionZ
        | RigidbodyConstraints.FreezeRotationX
        | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationZ;

            Debug.Log("yuka");
        }
    }

    void OnCollisionExit(Collision collision)// 壁で張りつく処理
    {
        if (collision.gameObject.CompareTag("Bule_Wall_Side"))//衝突した際の壁が"Bule_Wall_Side"タグだった時の判定
        {
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezePosition;
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("張りつく");
        }
        if (collision.gameObject.CompareTag("Bule_Wall_Top"))//衝突した際の壁が"Bule_Wall_Top"タグだった時の判定
        {
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezePosition;
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("張りつく");
        }
        if (collision.gameObject.CompareTag("Bule_Wall_Under"))//衝突した際の壁が"Bule_Wall_Under"タグだった時の判定
        {
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezePosition;
            // プレイヤーの動きを制限
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("張りつく");
        }

    }

    //以下タグに触れたらボイスが流れる処理
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
    //赤い壁に当たって死ぬ処理
    public void Destroy()
    {
        meshRenderer.enabled = false;
        isDead = true;
        sE_Manager.Play(5);      
    }
    /// <summary>
    /// 開始したら流れるボイス
    /// </summary>
    public void StartVoice()
    {
        // プレイヤーの動きを制限
        rb.constraints = RigidbodyConstraints.FreezePositionZ
        | RigidbodyConstraints.FreezeRotationX
        | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationZ;
        sE_Manager.Play(7);
    }
    /// <summary>
    /// ゴールした際の処理
    /// </summary>
    public void GoalAnim()
    {
        // プレイヤーの動きを制限
        rb.constraints = RigidbodyConstraints.FreezePositionZ
       | RigidbodyConstraints.FreezePositionY
       | RigidbodyConstraints.FreezeRotationY;
        transform.position =
          Vector3.MoveTowards(transform.position, targetPosition, 0.2f);
        Debug.Log("ゴール");
    }
    /// <summary>
    /// ゴールした後にフェードをかける
    /// </summary>
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
