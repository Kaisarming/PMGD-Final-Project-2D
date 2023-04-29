using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBtn : MonoBehaviour
{
    public Sprite clickedSprite; // Sprite yang akan digunakan ketika tombol di klik
    public string mainMenuSceneName; // Nama scene menu utama

    private Image buttonImage; // Komponen Image dari tombol
    //public GameObject splashscreen;
    //public SplashLoader splashOff;

    private void Start()
    {
        buttonImage = GetComponent<Image>(); // Mengambil komponen Image dari tombol
    }

    public void OnButtonClick()
    {
        buttonImage.sprite = clickedSprite; // Mengubah sprite tombol menjadi sprite yang di klik

        Invoke("LoadMainMenu", 0.5f); // Memanggil fungsi LoadMainMenu setelah 0.5 detik

    }

    public void LoadMainMenu()
    {
        //splashOff.GetComponent<SplashLoader>().enabled = false;
        //splashscreen.SetActive(false);
        SceneManager.LoadScene(mainMenuSceneName); // Memuat scene menu utama
    }
}
