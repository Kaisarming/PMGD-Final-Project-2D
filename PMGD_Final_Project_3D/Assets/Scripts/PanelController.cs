using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // GameObject panel yang ingin ditampilkan
    public Button buttonShow; // Tombol yang akan dipasang onClick untuk menampilkan panel
    public Button buttonHide; // Tombol yang akan dipasang onClick untuk menyembunyikan panel

    private void Start()
    {
        panel.SetActive(false); // Menghilangkan panel saat game dimulai
        buttonShow.onClick.AddListener(ShowPanel); // Menambahkan listener untuk onClick event pada buttonShow
        buttonHide.onClick.AddListener(HidePanel); // Menambahkan listener untuk onClick event pada buttonHide
    }

    private void ShowPanel()
    {
        panel.SetActive(true); // Menampilkan panel saat tombolShow diklik
    }

    private void HidePanel()
    {
        panel.SetActive(false); // Menyembunyikan panel saat tombolHide diklik
    }
}
