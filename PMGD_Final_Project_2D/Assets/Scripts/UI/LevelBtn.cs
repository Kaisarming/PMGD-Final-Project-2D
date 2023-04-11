using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    public string sceneName;
    public Sprite clickedImage;

    private Image buttonImage;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void OnButtonClick()
    {
        // Ganti gambar button menjadi clickedImage
        buttonImage.sprite = clickedImage;

        // Pindah scene setelah delay 0.1 detik
        Invoke("ChangeScene", 0.1f);
    }
}
