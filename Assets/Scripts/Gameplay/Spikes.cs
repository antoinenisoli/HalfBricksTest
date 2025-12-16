using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    private SpriteRenderer m_sprite = null;
    private Color m_defaultColor = new Color();

    void Start()
    {
        m_sprite = transform.GetComponentInChildren<SpriteRenderer>();
        m_defaultColor = m_sprite.color;

        var tween = transform.DOScaleY(1.5f, 0.5f);
        tween.SetLoops(-1, LoopType.Yoyo);
    }

    void Hit()
    {
        CameraShaker.Instance.Shake();
        Player.Instance.Push();
        StartCoroutine(SetColor());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit();
        VFXManager.Instance.PlayVFX("ImpactFX", collision.ClosestPoint(transform.position));
    }

    private IEnumerator SetColor()
    {
        m_sprite.color = new Color(m_defaultColor.r / 2, m_defaultColor.g / 2, m_defaultColor.b / 2, 1);
        yield return new WaitForSeconds(0.2f);
        m_sprite.color = m_defaultColor;
    }
}
