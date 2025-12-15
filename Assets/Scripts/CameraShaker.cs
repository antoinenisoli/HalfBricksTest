using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoSingleton<CameraShaker>
{
    [SerializeField] float shakeForce, shakeDuration;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void Shake()
    {
        cam.DOComplete();
        cam.DOShakePosition(shakeDuration, shakeForce);
    }
}
