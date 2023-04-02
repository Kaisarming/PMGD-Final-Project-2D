using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeLimit : MonoBehaviour
{
    public float timeRemaining = 180f; // Waktu mundur selama 3 menit
    public Text timerText; // Komponen teks untuk menampilkan waktu

    private bool isTimerRunning = false; // Flag untuk mengetahui apakah timer sedang berjalan

    private void Start()
    {
        isTimerRunning = true; // Mengaktifkan timer ketika game dimulai
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; // Mengurangi waktu mundur
                UpdateTimerText(); // Memperbarui teks timer
            }
            else
            {
                isTimerRunning = false; // Menonaktifkan timer ketika waktu habis
                DetermineOutcome(false); // Menentukan hasil kekalahan
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f); // Menghitung menit
        int seconds = Mathf.FloorToInt(timeRemaining % 60f); // Menghitung detik

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Memformat teks timer
    }

    public void OnGoalReached()
    {
        isTimerRunning = false; // Menonaktifkan timer ketika tujuan dicapai
        DetermineOutcome(true); // Menentukan hasil kemenangan
    }

    private void DetermineOutcome(bool hasWon)
    {
        if (hasWon)
        {
            Debug.Log("Player wins!");
        }
        else
        {
            Debug.Log("Player loses!");
        }

        // Menampilkan layar kemenangan atau kekalahan atau kembali ke menu utama
        // (tidak termasuk dalam contoh script ini)
    }
}
