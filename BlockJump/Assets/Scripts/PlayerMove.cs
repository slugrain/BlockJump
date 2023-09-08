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
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
    [SerializeField]
    public GameObject fade;
    [SerializeField]
    public GameObject goal_Obj;
=======
    [SerializeField]
    public GameObject fade;

>>>>>>> 3ae9e68a9b396a46a9bf6d4a63f5c81f16f238b2
    public Goal_Camera goal_Camera;
    Fade_Out fadeOut;

    public Text textUI;

    public GameObject canvasObj;
   // public GameObject voiceText;
    Vector3 targetPosition;
    public Star_Move star_move;
<<<<<<< HEAD
>>>>>>> Stashed changes
=======
>>>>>>> 3ae9e68a9b396a46a9bf6d4a63f5c81f16f238b2
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

        if (Input.GetMouseButtonUp(1))// W�L�[�i�O���ړ��j
        {
            rb.AddForce(new Vector3(60, 0, 0), ForceMode.VelocityChange);
            spark.Stop();
            sE_Manager.Play(1);
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

        if (Input.GetMouseButton(0))// W�L�[�i�O���ړ��j
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
            Vector3 force = new Vector3(0, 30, 0);    // �͂�ݒ�
            rb.AddForce(force);  // �͂�������
        }

        if (Input.GetKey(KeyCode.D))// W�L�[�i�O���ړ��j
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
            Vector3 force = new Vector3(7, 0, 0);    // �͂�ݒ�
            rb.AddForce(force);  // �͂�������
        }
        
        if (Input.GetKey(KeyCode.A))// A�L�[�i���ړ�
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbody���擾
            Vector3 force = new Vector3(-7, 0, 0);    // �͂�ݒ�
            rb.AddForce(force);  // �͂�������
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
            isDead = true;
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("�̕ǂ̑��ʂɓ�������");

        }

        if (collision.gameObject.CompareTag("Red_Wall_Top"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            isDead = true;
            explosion.Play();
            Invoke("Destroy", 0.1f);

            Debug.Log("�̕ǂ̏�ʂɓ�������");
        }

        if (collision.gameObject.CompareTag("Red_Wall_Under"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            isDead = true;
            explosion.Play();
            Invoke("Destroy", 0.1f);
            Debug.Log("�̕ǂ̉��ʂɓ�������");
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
            goal_Camera.GoalCamera();
            Debug.Log("�W�����v�p�b�h�I");
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
            canvasObj.SetActive(false);        
            //voiceText.SetActive(false);
            goal_Obj.SetActive(true);
>>>>>>> Stashed changes
=======
            canvasObj.SetActive(false);        
            //voiceText.SetActive(false);
>>>>>>> 3ae9e68a9b396a46a9bf6d4a63f5c81f16f238b2
        }

        if (collision.gameObject.CompareTag("Star"))//�@�Փ˂����ۂ̃^�O��"Star"���������̔���
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
            //FreezePositionXYZ�S�Ă��I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationY���I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
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
            textUI.text = "�ǂ�`���ĉ����Ă����܂��傤�B";
        }
        //�ڐG�����I�u�W�F�N�g�̃^�O��"Voice2"�̂Ƃ�
        if (other.CompareTag("Voice2"))
        {
            sE_Manager.Play(4);
            textUI.text = "�V���`���Ă��΂₭�ړ��I";
        }
        //�ڐG�����I�u�W�F�N�g�̃^�O��"Voice_Goal"�̂Ƃ�
        if (other.CompareTag("Voice_Goal"))
        {
            sE_Manager.Play(6);
            textUI.text = "�S�[�[�[��!";
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
        Debug.Log("�S�[�����o");
    }
    public void GoalFade()
    {
        fadeOut.clearFadeOut = true;
    }
}
