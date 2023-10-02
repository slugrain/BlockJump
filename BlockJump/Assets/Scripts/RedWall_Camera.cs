using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWall_Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject redWallCamera;

    public void RedWallCamera()
    {
        mainCamera.SetActive(false);
        redWallCamera.SetActive(true);
    }

    public void MainCameraBack()
    {
        mainCamera.SetActive(true);
        redWallCamera.SetActive(false);
    }
}
