using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel1Btn : MonoBehaviour
{
    public string level;
    public void RestartGame()
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
}
