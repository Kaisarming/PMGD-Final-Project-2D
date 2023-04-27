using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Immunity : MonoBehaviour
{
    public float duration;

    private float timer;

    public GameObject player;

    private HealthManager healthManager;
    private LifeCount lifeCount;
    public GameObject txtFromUnity;
    public GameObject powerUp;

    void Start()
    {

    }

    void Update()
    {
        timer = timer - Time.deltaTime < 0 ? 0 : timer - Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerUp.SetActive(false);
        timer = duration;
        StartCoroutine(Blinking());
        DeactivateCollider();
    }

    private void DeactivateCollider()
    {
        healthManager = GameObject.FindObjectOfType<HealthManager>();
        healthManager.currentHealth = 999;
        txtFromUnity.GetComponent<Text>().text = healthManager.currentHealth.ToString();
        player.GetComponent<Collider2D>().enabled = false;
    }

    private void ActivateCollider()
    {
        player.GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator Blinking()
    {
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
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
