using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Camera : MonoBehaviour
{
    /// <summary>
    /// �C���X�y�N�^�[����Q��
    /// </summary>
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject goalCamera;

    //�S�[��������J������؂�ւ��鏈��
    public void GoalCamera()
    {
        mainCamera.SetActive(false); 
        goalCamera.SetActive(true);
    }
}
