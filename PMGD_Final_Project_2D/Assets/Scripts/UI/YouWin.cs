using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YouWin : MonoBehaviour
{
    public GameObject winPanel;

    void Start()
    {
        winPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek jika collider yang di-tabrak oleh player adalah destinasi
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Win!");
            // Hentikan waktu pada permawinan
            Time.timeScale = 0;

            // Tampilkan panel "You Win"
            winPanel.SetActive(true);
        }
    }
}
