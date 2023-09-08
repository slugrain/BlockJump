using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject goalCamera;
    
    public void GoalCamera()
    {
        mainCamera.SetActive(false); 
        goalCamera.SetActive(true);
    }
}
