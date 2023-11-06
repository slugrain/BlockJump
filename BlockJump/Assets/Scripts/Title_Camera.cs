using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Camera : MonoBehaviour
{
    /// <summary>
    /// インスペクターから参照
    /// </summary>
    [SerializeField]
    private Animator animator;
    Rigidbody rb;
    public Title_Move_Player title_move;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject canvas_Text;
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
            canvas_Text.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }
    }
}
