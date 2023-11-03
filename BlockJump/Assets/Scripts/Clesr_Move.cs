using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clesr_Move : MonoBehaviour
{
    //インスペクターから参照
    public BGM_Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        //SE再生
        manager.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーを回転させる
        transform.Rotate(0, 0, -720 * Time.deltaTime);
    }
}
