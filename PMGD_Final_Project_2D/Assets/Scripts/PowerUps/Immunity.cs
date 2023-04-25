using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immunity : MonoBehaviour
{
    public float powerUpDuration; // waktu kekebalan dari serangan musuh
    public GameObject effect; // efek visual power up

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PowerUpCoroutine(other)); // memulai Coroutine untuk menjalankan power up
        }
    }

    IEnumerator PowerUpCoroutine(Collider2D player)
    {
        //MainCar playerController = player.GetComponent<MainCar>();

        //playerController.isInvincible = true; // membuat karakter menjadi kebal dari serangan musuh
        Instantiate(effect, transform.position, transform.rotation); // membuat efek visual pada posisi power up
        GetComponent<SpriteRenderer>().enabled = false; // menyembunyikan power up agar tidak terlihat lagi

        yield return new WaitForSeconds(powerUpDuration); // menunggu sebelum mematikan kekebalan

       // playerController.isInvincible = false; // mematikan kekebalan dari serangan musuh
        Destroy(gameObject); // menghancurkan power up setelah selesai digunakan
    }
}
