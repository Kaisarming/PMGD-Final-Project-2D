using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        GameManager.GetInstance();
    }

    public void restart()
    {
        pauseMenu.SetActive(false);
        GameManager.GetInstance().restart();
    }
}
