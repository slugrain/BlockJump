using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWall_Camera : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照
    /// </summary>
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject redWallCamera;

    //  赤い壁についたら動くカメラ
    public void RedWallCamera()
    {
        mainCamera.SetActive(false);
        redWallCamera.SetActive(true);
    }
    // メインカメラに戻す
    public void MainCameraBack()
    {
        mainCamera.SetActive(true);
        redWallCamera.SetActive(false);
    }
}
