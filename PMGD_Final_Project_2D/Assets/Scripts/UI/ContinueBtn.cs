using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueBtn : MonoBehaviour
{
    public GameObject pausePanel;

    private void Start()
    {
        // Sembunyikan panel saat permainan dimulai
        pausePanel.SetActive(false);
    }

    public void ResumeGame()
    {
        // Aktifkan kembali waktu pada permainan
        Time.timeScale = 1;

        // Sembunyikan panel
        pausePanel.SetActive(false);
    }
}
