using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionStopAction : MonoBehaviour
{
    public Fade_Out fadeOut;
    private void OnParticleSystemStopped()
    {
        fadeOut.Stage2FadeTrue();
        Debug.Log("パーティクルの再生が終了したよ！");
    }
}
