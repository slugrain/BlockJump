using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
public class PlayerMove_Tutorial_Stage : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照と初期化
    /// </summary>
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
    private GameObject fade;
    [SerializeField]
    private GameObject block_Wall;
    [SerializeField]
    private GameObject jump_Tutorial;
    [SerializeField]
    private GameObject move_R_Tutorial;
    [SerializeField]
    private GameObject move_L_Tutorial;
    [SerializeField]
    private GameObject redWall_Tutorial;
    [SerializeField]
    private GameObject blueWall_Tutorial;
    [SerializeField]
    private GameObject dash_Tutorial;
    [SerializeField]
    private GameObject dash_Tutorial2;
    [SerializeField]
    private Toggle jump_Tutorial_Toggle;
    [SerializeField]
    private Toggle move_Right_Tutorial_Toggle;
    [SerializeField]
    private Toggle move_Left_Tutorial_Toggle;
    [SerializeField]
    private Toggle dash_Tutorial_Toggle;

    public RedWall_Camera redWall_Camera;
    Fade_Out fadeOut;

    public Text textUI;
    private GUIStyle font_Size;
    public GameObject canvasObj;
    public GameObject goalObj;
    // public GameObject voiceText;
    Vector3 targetPosition;

    public Tutorial_Dash_Icon tutorial_Dash_Icon;
    public float upjumpPower;
    public float diagonaljumpPower;
    private bool isJumping = false;
    private bool diagonalJamp = false;
    private float xPos;
    public bool goal = false;
    public bool isDead = false;
    public bool dash = false;
    public bool jump = false;
    public bool move_Right = false;
    public bool move_Left = false;
    public SE_Manager sE_Manager;
    public SE_Manager2 sE_Manager2;
    public SE_Manager3 sE_Manager3;
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
        if (isDead) return;

        transform.Rotate(0, 0, -720 * Time.deltaTime);

        if (dash == true)
        {
            if (Input.GetMouseButtonUp(1))// Wキー（前方移動）
            {
                rb.AddForce(new Vector3(70, 0, 0), ForceMode.VelocityChange);
                spark.Stop();
                sE_Manager.Play(1);
                tutorial_Dash_Icon.CTuse();
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

        if (jump == true)
        {
            if (Input.GetMouseButton(0))// Wキー（前方移動）
            {
                Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
                Vector3 force = new Vector3(0, 30, 0);    // 力を設定
                rb.AddForce(force);  // 力を加える
                sE_Manager3.Play(0);
            }
        }
        if (move_Right == true)
        {
            if (Input.GetKey(KeyCode.D))// Wキー（前方移動）
            {
                Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
                Vector3 force = new Vector3(7, 0, 0);    // 力を設定
                rb.AddForce(force);  // 力を加える
            }
        }

        if (move_Left == true)
        {
            if (Input.GetKey(KeyCode.A))// Aキー（左移動
            {
                Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
                Vector3 force = new Vector3(-7, 0, 0);    // 力を設定
                rb.AddForce(force);  // 力を加える
            }
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
            sE_Manager2.Play(8);
            textUI.fontSize = 90;
            textUI.text = "チュートリアルのみ、ゲームオーバーになりません。本番では気をつけてね！";
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("赤の壁の側面に当たった");

        }

        if (collision.gameObject.CompareTag("Red_Wall_Top"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            sE_Manager2.Play(8);
            textUI.fontSize = 90;
            textUI.text = "チュートリアルのみ、ゲームオーバーになりません。本番では気をつけてね！";
            explosion.Play();
            Invoke("Destroy", 0.1f);

            Debug.Log("赤の壁の上面に当たった");
        }

        if (collision.gameObject.CompareTag("Red_Wall_Under"))//　衝突した際の壁が"Bule_Wall"タグだった時の判定
        {
            sE_Manager2.Play(8);
            textUI.fontSize = 90;
            textUI.text = "チュートリアルのみ、ゲームオーバーになりません。本番では気をつけてね！";
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("赤の壁の下面に当たった");
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
            // goal_Camera.GoalCamera();
            Debug.Log("ジャンプパッド！");
            canvasObj.SetActive(false);
            goalObj.SetActive(true);
            //voiceText.SetActive(false);
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
        if (other.CompareTag("Voice_Jump_Tutorial"))// 接触したオブジェクトのタグが"Voice_Jump_Tutorial"のとき
        {
            jump_Tutorial_Toggle.isOn = true;
            textUI.fontSize = 140;
            sE_Manager.Play(11);
            textUI.text = "OK!!";
            jump_Tutorial.SetActive(false);
            Invoke("TutorialVoice", 4f);
        }

        if (other.CompareTag("Voice_move_Right_Tutorial"))// 接触したオブジェクトのタグが"Voice_move_Right_Tutorial"のとき
        {
            move_Right_Tutorial_Toggle.isOn = true;
            textUI.fontSize = 140;
            sE_Manager.Play(11);
            textUI.text = "OK!!";
            move_R_Tutorial.SetActive(false);
            Invoke("TutorialVoice2", 4f);
        }

        if (other.CompareTag("Voice_move_Left_Tutorial"))// 接触したオブジェクトのタグが"Voice_move_Left_Tutorial"のとき
        {
            move_Left_Tutorial_Toggle.isOn = true;
            textUI.fontSize = 140;
            sE_Manager.Play(11);
            textUI.text = "OK!!";
            move_L_Tutorial.SetActive(false);
            block_Wall.SetActive(false);
            Invoke("TutorialVoice3", 4f);
        }

        if (other.CompareTag("Voice_Red_Wall"))// 接触したオブジェクトのタグが"Voice_Red_Wall"のとき
        {
            sE_Manager.Play(12);
            redWall_Tutorial.SetActive(false);
            TutorialVoice4();
        }

        if (other.CompareTag("Voice_Blue_Wall"))// 接触したオブジェクトのタグが"Voice_Blue_Wall"のとき
        {
            sE_Manager.Play(12);
            blueWall_Tutorial.SetActive(false);
            TutorialVoice6();
        }

        if (other.CompareTag("Voice_Dash_Tutorial"))// 接触したオブジェクトのタグが"Voice_Dash_Tutorial"のとき
        {
            //textUI.fontSize = 140;
            sE_Manager.Play(12);
            dash_Tutorial.SetActive(false);
            TutorialVoice8();
        }

        if (other.CompareTag("Voice_Dash_Tutorial2"))// 接触したオブジェクトのタグが"Voice_Dash_Tutorial2"のとき
        {
            dash_Tutorial_Toggle.isOn = true;
            textUI.fontSize = 140;
            sE_Manager.Play(11);
            textUI.text = "OK!!";
            dash_Tutorial2.SetActive(false);
            Invoke("TutorialVoice9", 4f);
        }
    }
    public void Destroy()
    {
        //player.SetActive(false);
        sE_Manager.Play(5);
    }
    public void StartVoice()
    {
        sE_Manager2.Play(0);
        Invoke("StartVoice2", 5.7f);
    }

    public void StartVoice2()
    {
        sE_Manager2.Play(1);
        textUI.text = "まずはマウスの左クリックを長押しして、一番上まで上昇してみましょう！";
        jump = true;
    }
    public void TutorialVoice()
    {
        jump = false;
        move_Right = true;
        textUI.fontSize = 90;
        sE_Manager2.Play(2);
        textUI.text = "続いては、キーボードの\"D\"キーを押して、右に動いてみましょう！";
        //Invoke("StartVoice2", 5.7f);
    }
    public void TutorialVoice2()
    {
        move_Right = false;
        move_Left = true;
        textUI.fontSize = 90;
        sE_Manager2.Play(3);
        textUI.text = "次は、キーボードの\"A\"キーを押して、左に動いてみましょう！";
        //Invoke("StartVoice2", 5.7f);
    }

    public void TutorialVoice3()
    {
        move_Right = true;
        jump = true;
        textUI.fontSize = 90;
        sE_Manager2.Play(4);
        textUI.text = "それでは、今の操作を駆使して、上部にある道から先に進んでみましょう！";
        //Invoke("StartVoice2", 5.7f);
    }

    public void TutorialVoice4()
    {
        textUI.fontSize = 60;
        redWall_Camera.RedWallCamera();
        rb.constraints = RigidbodyConstraints.FreezePosition;
        sE_Manager2.Play(5);
        textUI.text = "おっと、赤いブロックがありますね。赤いブロックに触れるとゲームオーバーになってしまいます。触れないように進んで行きましょう!";
        Invoke("TutorialVoice5", 9.5f);
    }

    public void TutorialVoice5()
    {
        redWall_Camera.MainCameraBack();
        rb.constraints = RigidbodyConstraints.FreezePositionZ
        | RigidbodyConstraints.FreezeRotationX
        | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationZ;
    }

    public void TutorialVoice6()
    {
        textUI.fontSize = 60;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        sE_Manager2.Play(6);
        textUI.text = "青いブロックが見えますね。青いブロックに触れている間は、触れている方向に張り付きます。安全に通行したい時に便利ですよ！";
        Invoke("TutorialVoice7", 10f);
    }

    public void TutorialVoice7()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionZ
        | RigidbodyConstraints.FreezeRotationX
        | RigidbodyConstraints.FreezeRotationY
        | RigidbodyConstraints.FreezeRotationZ;
    }

    public void TutorialVoice8()
    {
        textUI.fontSize = 60;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        sE_Manager2.Play(7);
        textUI.text = "最後に、ダッシュについて説明します。ダッシュは、マウスの右クリックで使用できます。ただし、ダッシュはクールタイムがあるので連続では使えません。左下のアイコンを見ながら、タイミングよく使いましょう！";
        dash = true;
        Invoke("TutorialVoice7", 17f);
    }

    public void TutorialVoice9()
    {
        textUI.fontSize = 60;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        sE_Manager2.Play(9);
        textUI.text = "以上でチュートリアルを終了します。次は本番です。頑張って下さい！";
        Invoke("Fade", 6f);
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
    public void Fade()
    {
        fadeOut.toStageFadeOut = true;
    }
}
