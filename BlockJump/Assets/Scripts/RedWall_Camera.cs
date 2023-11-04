using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWall_Camera : MonoBehaviour
{
    /// <summary>
    /// �C���X�y�N�^�[����Q��
    /// </summary>
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject redWallCamera;

    //  �Ԃ��ǂɂ����瓮���J����
    public void RedWallCamera()
    {
        mainCamera.SetActive(false);
        redWallCamera.SetActive(true);
    }
    // ���C���J�����ɖ߂�
    public void MainCameraBack()
    {
        mainCamera.SetActive(true);
        redWallCamera.SetActive(false);
    }
}
