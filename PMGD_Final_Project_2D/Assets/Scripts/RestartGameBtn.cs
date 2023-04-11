using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameBtn : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1;
    }
}
