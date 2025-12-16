using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dev.ComradeVanti.WaitForAnim;

public class AutoDestroyFX : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(LandingFX());
    }

    IEnumerator LandingFX()
    {
        yield return animator.PlayAndWait("MyAnim");
        Destroy(gameObject);
    }
}
