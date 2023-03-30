using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    public string sceneName; // Nama Scene yang akan dipindahkan
    public Button button; // Tombol yang akan dipasang onClick

    private void Start()
    {
        button.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
