using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Camera : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    Rigidbody rb;
    public Title_Move_Player title_move;
    [SerializeField]
    private GameObject canvas;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        //  スペースキーでタイトル遷移
        if (Input.GetKeyDown(KeyCode.Space))
        {

            title_move.DownMax();
            animator.SetTrigger("Point_Up");
            canvas.SetActive(false);
        }
    }
}
