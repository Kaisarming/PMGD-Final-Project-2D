using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Immunity : MonoBehaviour
{
    public float duration;

    public GameObject player;

    private HealthManager healthManager;
    public GameObject txtFromUnity;
    public GameObject powerUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerUp.SetActive(false);
        healthManager = GameObject.FindObjectOfType<HealthManager>();
        healthManager.currentHealth = 999999999;
        txtFromUnity.GetComponent<Text>().text = "Infinite";
    }
}
