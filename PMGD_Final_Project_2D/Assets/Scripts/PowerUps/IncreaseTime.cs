using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTime : MonoBehaviour
{
    public float addedTime = 10f;
    private GameTimeLimit gameTimeLimit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameTimeLimit = GameObject.FindObjectOfType<GameTimeLimit>();
            // tambahkan waktu pada timer
            gameTimeLimit.timeRemaining += addedTime;
            gameTimeLimit.UpdateTimerText();

            // hapus game object power-up
            Destroy(gameObject);
        }
    }
}
