using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionStopAction : MonoBehaviour
{
    public Fade_Out fadeOut;
    private void OnParticleSystemStopped()
    {
        fadeOut.GameOverFadeTrue();
        Debug.Log("�p�[�e�B�N���̍Đ����I��������I");
    }
}
