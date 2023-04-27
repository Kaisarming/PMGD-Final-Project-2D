using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immunity : MonoBehaviour
{
    public float powerUpDuration; // waktu kekebalan dari serangan musuh
    public GameObject imun;
    public GameObject gm;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PowerUpCoroutine(other)); // memulai Coroutine untuk menjalankan power up
        }
    }

    IEnumerator PowerUpCoroutine(Collider2D player)
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(powerUpDuration);
        imun.GetComponent<HealthManager>().enabled = false;
        gm.GetComponent<GameManager>().enabled = false;
    }
}
