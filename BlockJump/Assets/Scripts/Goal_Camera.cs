using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Camera : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照
    /// </summary>
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject goalCamera;

    //ゴールしたらカメラを切り替える処理
    public void GoalCamera()
    {
        mainCamera.SetActive(false); 
        goalCamera.SetActive(true);
    }
}
