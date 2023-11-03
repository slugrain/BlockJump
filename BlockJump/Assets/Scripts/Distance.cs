using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Distance : MonoBehaviour
{
    public Transform player;     // �v���C���[�I�u�W�F�N�g��Transform
    public Transform goal;       // �S�[���I�u�W�F�N�g��Transform
    public Text distanceText;    // ������\������UI�e�L�X�g
    public Slider distanceSlider; // �X���C�_�[�Q��

    void Start()
    {
        //�X���C�_�[�擾
        distanceSlider = GetComponent<Slider>();
        //�S�[���̋�����ݒ�
        float goalDistance = 172f;
        //�X���C�_�[�̍ő�l�̐ݒ�
        distanceSlider.maxValue = goalDistance;
    }
    public void Update()
    {
        // �v���C���[�ƃS�[���̈ʒu���擾
        Vector3 playerPosition = player.position;
        Vector3 goalPosition = goal.position;

        // �v���C���[�ƃS�[���̈ʒu�̍����v�Z
        float distanceToGoal = Vector3.Distance(playerPosition, goalPosition);
        // if (distanceToGoal < 0) distanceToGoal = 0;
        // ������UI�e�L�X�g�ɕ\��
        
        distanceText.text = "�S�[���܂Ŏc��" + ((int)distanceToGoal) + "���[�g��!";

        //�X���C�_�[�̌��ݒl�̐ݒ�
        distanceSlider.value = distanceToGoal;
    }
}
