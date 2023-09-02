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

        if (Input.GetMouseButtonUp(1))// W�L�[�i�O���ړ��j
        {
            rb.AddForce(new Vector3(60, 0, 0), ForceMode.VelocityChange);
            spark.Stop();
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

    
    void FixedUpdate()
    {
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
        if (Input.GetKeyDown(KeyCode.Space))// W�L�[�i�O���ړ��j
        {
            //FreezePositionXYZ�S�Ă��I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //FreezeRotationY���I���ɂ���
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            Debug.Log("�̕ǂ��痣�ꂽ");
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
            explosion.Play();
            Invoke("Destroy", 1f);
            Debug.Log("�̕ǂ̑��ʂɓ�������");

        }

        if (collision.gameObject.CompareTag("Red_Wall_Top"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            explosion.Play();
            Invoke("Destroy", 0.5f);

            Debug.Log("�̕ǂ̏�ʂɓ�������");
        }

        if (collision.gameObject.CompareTag("Red_Wall_Under"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            explosion.Play();
            Invoke("Destroy", 1f);
            Debug.Log("�̕ǂ̉��ʂɓ�������");
        }

        if (collision.gameObject.CompareTag("Jamp_Pad"))//�@�Փ˂����ۂ̕ǂ�"Bule_Wall"�^�O���������̔���
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ
          | RigidbodyConstraints.FreezePositionY
          | RigidbodyConstraints.FreezeRotationY;
            rb.AddForce(new Vector3(60, 0, 0), ForceMode.VelocityChange);
            Debug.Log("�W�����v�p�b�h�I");
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

    public void Destroy()
    {
        //player.SetActive(false);
        isDead = true;
    }
}
