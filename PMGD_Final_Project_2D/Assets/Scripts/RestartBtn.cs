using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour
{
    public float restartDelay = 1f; // waktu delay sebelum me-restart game

    public void Restart()
    {
        StartCoroutine(RestartCoroutine());
    }

    IEnumerator RestartCoroutine()
    {
        yield return new WaitForSeconds(restartDelay); // menunggu sebelum me-restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // me-restart game
    }
}
