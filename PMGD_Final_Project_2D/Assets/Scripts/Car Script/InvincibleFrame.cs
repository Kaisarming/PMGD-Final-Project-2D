using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleFrame : MonoBehaviour
{
    public float duration;
    private float timer;

    void Update()
    {
        timer = timer - Time.deltaTime < 0 ? 0 : timer - Time.deltaTime;
    }

    public void Activate()
    {
        timer = duration;
        StartCoroutine(Blinking());
        DeactivateCollider();
    }

    private void DeactivateCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }

    private void ActivateCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator Blinking()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color defaultColor = sr.color;
        Color hitColor = defaultColor;
        hitColor.a = 0.5f;

        while (timer > 0)
        {
            sr.color = hitColor;
            yield return new WaitForSeconds(0.1f);
            sr.color = default;
            yield return new WaitForSeconds(0.1f);
        }
        sr.color = defaultColor;
        ActivateCollider();
    }
}