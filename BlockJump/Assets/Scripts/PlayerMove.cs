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
    // public GameObject voiceText;
    Vector3 targetPosition;
    public Star_Move star_move;
    public Dash_Icon dash_icon;
    public float upjumpPower;
    public float diagonaljumpPower;
    //private bool isJumping = false;
    //private bool diagonalJamp = false;
    //private float xPos;
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
        if(isDead)return;

        transform.Rotate(0, 0, -720 * Time.deltaTime);

        if (dash == true) 
        {
            if (Input.GetMouseButtonUp(1))// W�L�[�i�O���ړ��j
            {
                rb.AddForce(new Vector3(70, 0, 0), ForceMode.VelocityChange);
                spark.Stop();
                sE_Manager.Play(1);
                dash_icon.CTuse();
                Debug.Log("Dash");
            }

            if (Input.GetMouseButton(1))// W�L�[�i�O���ړ��j
            {
                transform.Rotate(0, 0, -360 * Time.deltaTime);
                //spark.Play();
                //Debug.Log("SpinUp");
            }

            if (Input.GetMouseButtonDown(1))// W�L�[�i�O���ړ��j
            {
                transform.Rotate(0, 0, -360 * Time.deltaTime);
                spark.Play();
                Debug.Log("SpinUp");
            }
        }

        if (isGoal == true)// W�L�[�i�O���ړ��j
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.Rotate(0, 0, -720 * Time.deltaTime);
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
        if (collision.gameObject.CompareTag("Bule_Wall_Side"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁の側面に当たった");

        }

        if (collision.gameObject.CompareTag("Bule_Wall_Under") ||
            collision.gameObject.CompareTag("Bule_Wall_Top"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionY
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("青の壁の下面に当たった");
        }
        if (collision.gameObject.CompareTag("Red_Wall_Side"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("�̕ǂ̑��ʂɓ�������");
            isDead = true;
            Physics.autoSimulation = false;
        }

        if (collision.gameObject.CompareTag("Red_Wall_Top"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("�̕ǂ̏�ʂɓ�������");
            isDead = true;
            Physics.autoSimulation = false;
        }

        if (collision.gameObject.CompareTag("Red_Wall_Under"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("�̕ǂ̉��ʂɓ�������");
            isDead = true;
            Physics.autoSimulation = false;
        }
        

        if (collision.gameObject.CompareTag("Key_Wall"))//�@�Փ˂����ۂ̕ǂ�"Key_Wall"�^�O���������̔���
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY
            | RigidbodyConstraints.FreezeRotationZ;
            Debug.Log("�ʂ�Ȃ��I");
        }

        if (collision.gameObject.CompareTag("Jamp_Pad"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
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

        if (collision.gameObject.CompareTag("Star"))//�@�Փ˂����ۂ̃^�O��"Star"���������̔���
        {
            star_move.StarGet();
            Debug.Log("Star Get");
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

    void OnCollisionExit(Collision collision)// �̕ǂ��痣�ꂽ�ۂ̔�������
    {
        if (collision.gameObject.CompareTag("Bule_Wall_Side"))//�@���ꂽ�ǂ�"Bule_Wall"�^�O���������̔���
        {
            //FreezePositionXYZ�S�Ă��I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationY���I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("�̕ǂ��痣�ꂽ");
        }
        if (collision.gameObject.CompareTag("Bule_Wall_Top"))//�@���ꂽ�ǂ�"Bule_Wall"�^�O���������̔���
        {
            //FreezePositionXYZ�S�Ă��I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationY���I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("�̕ǂ��痣�ꂽ");
        }
        if (collision.gameObject.CompareTag("Bule_Wall_Under"))//�@���ꂽ�ǂ�"Bule_Wall"�^�O���������̔���
        {
            //FreezePositionXYZ�S�Ă��I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationY���I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("�̕ǂ��痣�ꂽ");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        //�ڐG�����I�u�W�F�N�g�̃^�O��"Voice"�̂Ƃ�
        if (other.CompareTag("Voice"))
        {
            sE_Manager.Play(3);
            textUI.text = "壁を伝って下っていきましょう。";
        }
        //�ڐG�����I�u�W�F�N�g�̃^�O��"Voice2"�̂Ƃ�
        if (other.CompareTag("Voice2"))
        {
            sE_Manager.Play(4);
            textUI.text = "天井を伝ってすばやく移動！";
        }
        //�ڐG�����I�u�W�F�N�g�̃^�O��"Voice_Goal"�̂Ƃ�
        if (other.CompareTag("Voice_Goal"))
        {
            sE_Manager.Play(6);
            textUI.text = "ゴーーール!";
        }

        //�ڐG�����I�u�W�F�N�g�̃^�O��"Voice_Star"�̂Ƃ�
        if (other.CompareTag("Voice_Star"))
        {
            sE_Manager.Play(8);
            textUI.text = "壁があるね…星が怪しい感じ…？";
        }
        //�ڐG�����I�u�W�F�N�g�̃^�O��"Voice_Saka"�̂Ƃ�
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
        Debug.Log("�S�[�����o");
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
        Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
        Vector3 force = new Vector3(moveForceX, moveForceY, 0);    // �͂�ݒ�
        rb.AddForce(force);  // �͂�������
    }
}
