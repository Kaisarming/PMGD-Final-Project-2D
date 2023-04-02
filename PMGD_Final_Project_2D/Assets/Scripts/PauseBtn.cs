using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    public Sprite playSprite; // Sprite yang akan digunakan ketika game sedang diputar
    public Sprite pauseSprite; // Sprite yang akan digunakan ketika game dijeda

    private bool isPaused = false; // Flag untuk mengetahui apakah game sedang dijeda
    private Image buttonImage; // Komponen Image dari tombol
    public GameObject showPanel;

    private void Start()
    {
        buttonImage = GetComponent<Image>(); // Mengambil komponen Image dari tombol
        showPanel.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (isPaused)
        {
            Time.timeScale = 1f; // Mengaktifkan kembali pergerakan game
            buttonImage.sprite = pauseSprite; // Mengubah sprite tombol menjadi sprite jeda
            showPanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f; // Menjeda pergerakan game
            buttonImage.sprite = playSprite; // Mengubah sprite tombol menjadi sprite putar
            showPanel.SetActive(true);
        }

        isPaused = !isPaused; // Mengubah flag isPaused ke nilai yang berlawanan
    }
}
