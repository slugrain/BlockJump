using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;
public class PlayerMove_Tutorial_Stage : MonoBehaviour
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
        if(isDead)return;

        transform.Rotate(0, 0, -720 * Time.deltaTime);

        if (dash == true) 
        {
            if (Input.GetMouseButtonUp(1))// W�L�[�i�O���ړ��j
            {
                rb.AddForce(new Vector3(70, 0, 0), ForceMode.VelocityChange);
                spark.Stop();
                sE_Manager.Play(1);
                tutorial_Dash_Icon.CTuse();
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

        if (goal == true)// W�L�[�i�O���ړ��j
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
            if (Input.GetMouseButton(0))// W�L�[�i�O���ړ��j
            {
                Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
                Vector3 force = new Vector3(0, 30, 0);    // �͂�ݒ�
                rb.AddForce(force);  // �͂�������
                sE_Manager3.Play(0);
            }
        }
        if (move_Right == true)
        {
            if (Input.GetKey(KeyCode.D))// W�L�[�i�O���ړ��j
            {
                Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
                Vector3 force = new Vector3(7, 0, 0);    // �͂�ݒ�
                rb.AddForce(force);  // �͂�������
            }      
        }

        if (move_Left == true)
        {
            if (Input.GetKey(KeyCode.A))// A�L�[�i���ړ�
            {
                Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
                Vector3 force = new Vector3(-7, 0, 0);    // �͂�ݒ�
                rb.AddForce(force);  // �͂�������
            }
        }
    }
    void OnCollisionEnter(Collision collision)// �̕ǂɏՓ˂����ۂ̔�������
    {
        if (collision.gameObject.CompareTag("Bule_Wall_Side"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionX
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("�̕ǂ̑��ʂɓ�������");
          
        }

        if (collision.gameObject.CompareTag("Bule_Wall_Top"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionY
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("�̕ǂ̏�ʂɓ�������");
        }

        if (collision.gameObject.CompareTag("Bule_Wall_Under"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezePositionY
            | RigidbodyConstraints.FreezeRotationY;
            Debug.Log("�̕ǂ̉��ʂɓ�������");
        }

        if (collision.gameObject.CompareTag("Red_Wall_Side"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            sE_Manager2.Play(8);
            textUI.fontSize = 90;
            textUI.text = "�`���[�g���A���̂݁A�Q�[���I�[�o�[�ɂȂ�܂���B�{�Ԃł͋C�����ĂˁI";
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("�Ԃ̕ǂ̑��ʂɓ�������");

        }

        if (collision.gameObject.CompareTag("Red_Wall_Top"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            sE_Manager2.Play(8);
            textUI.fontSize = 90;
            textUI.text = "�`���[�g���A���̂݁A�Q�[���I�[�o�[�ɂȂ�܂���B�{�Ԃł͋C�����ĂˁI";
            explosion.Play();
            Invoke("Destroy", 0.1f);

            Debug.Log("�Ԃ̕ǂ̏�ʂɓ�������");
        }

        if (collision.gameObject.CompareTag("Red_Wall_Under"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            sE_Manager2.Play(8);
            textUI.fontSize = 90;
            textUI.text = "�`���[�g���A���̂݁A�Q�[���I�[�o�[�ɂȂ�܂���B�{�Ԃł͋C�����ĂˁI";
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("�Ԃ̕ǂ̉��ʂɓ�������");
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
            goal = true;
            Invoke("GoalFade", 6f);
            goalspark.Play();
           // goal_Camera.GoalCamera();
            Debug.Log("�W�����v�p�b�h�I");
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
        if (other.CompareTag("Voice_Jump_Tutorial"))// �ڐG�����I�u�W�F�N�g�̃^�O��"Voice_Jump_Tutorial"�̂Ƃ�
        {
            jump_Tutorial_Toggle.isOn = true;
            textUI.fontSize = 140;            
            sE_Manager.Play(11);
            textUI.text = "OK!!";
            jump_Tutorial.SetActive(false);
            Invoke("TutorialVoice", 4f);
        }

        if (other.CompareTag("Voice_move_Right_Tutorial"))// �ڐG�����I�u�W�F�N�g�̃^�O��"Voice_move_Right_Tutorial"�̂Ƃ�
        {
            move_Right_Tutorial_Toggle.isOn = true;
            textUI.fontSize = 140;
            sE_Manager.Play(11);
            textUI.text = "OK!!";
            move_R_Tutorial.SetActive(false);
            Invoke("TutorialVoice2", 4f);
        }

        if (other.CompareTag("Voice_move_Left_Tutorial"))// �ڐG�����I�u�W�F�N�g�̃^�O��"Voice_move_Left_Tutorial"�̂Ƃ�
        {
            move_Left_Tutorial_Toggle.isOn = true;
            textUI.fontSize = 140;
            sE_Manager.Play(11);
            textUI.text = "OK!!";
            move_L_Tutorial.SetActive(false);
            block_Wall.SetActive(false);
            Invoke("TutorialVoice3", 4f);
        }

        if (other.CompareTag("Voice_Red_Wall"))// �ڐG�����I�u�W�F�N�g�̃^�O��"Voice_Red_Wall"�̂Ƃ�
        {            
            sE_Manager.Play(12);      
            redWall_Tutorial.SetActive(false);
            TutorialVoice4();
        }

        if (other.CompareTag("Voice_Blue_Wall"))// �ڐG�����I�u�W�F�N�g�̃^�O��"Voice_Blue_Wall"�̂Ƃ�
        {
            sE_Manager.Play(12);
            blueWall_Tutorial.SetActive(false);
            TutorialVoice6();
        }

        if (other.CompareTag("Voice_Dash_Tutorial"))// �ڐG�����I�u�W�F�N�g�̃^�O��"Voice_Dash_Tutorial"�̂Ƃ�
        {
            //textUI.fontSize = 140;
            sE_Manager.Play(12);
            dash_Tutorial.SetActive(false);
            TutorialVoice8();
        } 
        
        if (other.CompareTag("Voice_Dash_Tutorial2"))// �ڐG�����I�u�W�F�N�g�̃^�O��"Voice_Dash_Tutorial2"�̂Ƃ�
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
        textUI.text = "�܂��̓}�E�X�̍��N���b�N�𒷉������āA��ԏ�܂ŏ㏸���Ă݂܂��傤�I";
        jump = true;
    }
    public void TutorialVoice()
    {
        jump = false;
        move_Right = true;
        textUI.fontSize = 90;
        sE_Manager2.Play(2);
        textUI.text = "�����ẮA�L�[�{�[�h��\"D\"�L�[�������āA�E�ɓ����Ă݂܂��傤�I";
        //Invoke("StartVoice2", 5.7f);
    }
    public void TutorialVoice2()
    {       
        move_Right = false;
        move_Left = true;
        textUI.fontSize = 90;
        sE_Manager2.Play(3);
        textUI.text = "���́A�L�[�{�[�h��\"A\"�L�[�������āA���ɓ����Ă݂܂��傤�I";
        //Invoke("StartVoice2", 5.7f);
    }

    public void TutorialVoice3()
    {
        move_Right = true;
        jump = true;
        textUI.fontSize = 90;
        sE_Manager2.Play(4);
        textUI.text = "����ł́A���̑������g���āA�㕔�ɂ��铹�����ɐi��ł݂܂��傤�I";
        //Invoke("StartVoice2", 5.7f);
    }

    public void TutorialVoice4()
    {
        textUI.fontSize = 60;
        redWall_Camera.RedWallCamera();
        rb.constraints = RigidbodyConstraints.FreezePosition;
        sE_Manager2.Play(5);
        textUI.text = "�����ƁA�Ԃ��u���b�N������܂��ˁB�Ԃ��u���b�N�ɐG���ƃQ�[���I�[�o�[�ɂȂ��Ă��܂��܂��B�G��Ȃ��悤�ɐi��ōs���܂��傤!";
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
        textUI.text = "���u���b�N�������܂��ˁB���u���b�N�ɐG��Ă���Ԃ́A�G��Ă�������ɒ���t���܂��B���S�ɒʍs���������ɕ֗��ł���I";    
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
        textUI.text = "�Ō�ɁA�_�b�V���ɂ��Đ������܂��B�_�b�V���́A�}�E�X�̉E�N���b�N�Ŏg�p�ł��܂��B�������A�_�b�V���̓N�[���^�C��������̂ŘA���ł͎g���܂���B�����̃A�C�R�������Ȃ���A�^�C�~���O�悭�g���܂��傤�I";
        dash = true;
        Invoke("TutorialVoice7", 17f);
    }

    public void TutorialVoice9()
    {
        textUI.fontSize = 60;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        sE_Manager2.Play(9);
        textUI.text = "�ȏ�Ń`���[�g���A�����I�����܂��B���͖{�Ԃł��B�撣���ĉ������I";
        Invoke("Fade", 6f);
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
    public void Fade()
    {
        fadeOut.toStageFadeOut = true;
    }
}
